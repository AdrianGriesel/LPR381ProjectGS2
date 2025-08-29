
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearProgrammingSolver
{

    using static LPInputParser;
    // numeric helpers

    internal static class EPS
    {
        public const double Feas = 1e-9;
        public const double Opt = 1e-9;
        public static double RoundIfClose(double v)
        {
            if (Math.Abs(v - Math.Round(v)) < 1e-9) return Math.Round(v);
            return v;
        }
    }

    

    internal class ExpandedModel
    {
        public bool IsMaximization = true;
        public int NumVars;                 // total columns (orig + slack + artificials)
        public int NumOrigVars;             // number of original decision variables
        public double[] C = new double[0];  // length = NumVars
        public double[,] A = new double[0, 0]; // m x NumVars
        public double[] B = new double[0];     // RHS length m
        public List<int> IntegerVarIdxOriginal = new List<int>();
        public List<int> BinaryVarIdxOriginal = new List<int>();
        public int[] MapExpandedToOriginal = new int[0];
        public List<int> SlackVarCols = new List<int>();
        public List<int> ArtificialVarCols = new List<int>();
        public string[] VarNames = new string[0];
    }

    internal static class ModelBuilder
    {
        public static ExpandedModel BuildStandardForm(LPModel model)
        {
            // Only support +, int, bin in this version
            for (int i = 0; i < model.SignRestrictions.Count; i++)
            {
                var t = model.SignRestrictions[i];
                if (t == VariableType.Negative || t == VariableType.Unrestricted)
                    throw new NotSupportedException("This solver supports only +, int, bin variable types.");
            }

            int n = model.NumberOfVariables;
            var constraints = new List<Constraint>();
            constraints.AddRange(model.Constraints);

            // Add x <= 1 for binary variables
            for (int i = 0; i < n; i++)
            {
                if (model.SignRestrictions[i] == VariableType.Binary)
                {
                    var coeffs = new List<double>();
                    for (int j = 0; j < n; j++) coeffs.Add(j == i ? 1.0 : 0.0);
                    constraints.Add(new Constraint { Coefficients = coeffs, Type = ConstraintType.LessOrEqual, RightHandSide = 1.0 });
                }
            }

            int m = constraints.Count;

            var colNames = new List<string>();
            for (int i = 0; i < n; i++) colNames.Add("x" + (i + 1));

            var Arows = new List<double[]>();
            var b = new List<double>();
            var slackCols = new List<int>();
            var artificialCols = new List<int>();
            int col = n;

            for (int r = 0; r < m; r++)
            {
                var cstr = constraints[r];
                var row = new double[colNames.Count];
                for (int j = 0; j < n; j++) row[j] = cstr.Coefficients[j];

                if (cstr.Type == ConstraintType.LessOrEqual)
                {
                    double[] tmp = row;
                    Array.Resize(ref tmp, col + 1);
                    row = tmp;
                    row[col] = 1.0;
                    slackCols.Add(col);
                    colNames.Add("s" + slackCols.Count);
                    col++;
                }
                else if (cstr.Type == ConstraintType.GreaterOrEqual)
                {
                    double[] tmp = row;
                    Array.Resize(ref tmp, col + 2);
                    row = tmp;
                    row[col] = -1.0;
                    slackCols.Add(col);
                    colNames.Add("e" + slackCols.Count);
                    col++;
                    row[col] = 1.0;
                    artificialCols.Add(col);
                    colNames.Add("a" + artificialCols.Count);
                    col++;
                }
                else // Equal
                {
                    double[] tmp = row;
                    Array.Resize(ref tmp, col + 1);
                    row = tmp;
                    row[col] = 1.0;
                    artificialCols.Add(col);
                    colNames.Add("a" + artificialCols.Count);
                    col++;
                }

                Arows.Add(row);
                b.Add(cstr.RightHandSide);
            }

            int totalCols = col;
            for (int i = 0; i < Arows.Count; i++)
            {
                if (Arows[i].Length != totalCols)
                {
                    var rr = Arows[i];
                    Array.Resize(ref rr, totalCols);
                    Arows[i] = rr;
                }
            }

            var cvec = new double[totalCols];
            double sign = model.IsMaximization ? 1.0 : -1.0;
            for (int j = 0; j < model.ObjectiveCoefficients.Count; j++) cvec[j] = sign * model.ObjectiveCoefficients[j];

            var em = new ExpandedModel();
            em.IsMaximization = true;
            em.NumVars = totalCols;
            em.NumOrigVars = n;
            em.C = cvec;
            em.A = ToMatrix(Arows);
            em.B = b.ToArray();
            var ints = new List<int>();
            var bins = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (model.SignRestrictions[i] == VariableType.Integer || model.SignRestrictions[i] == VariableType.Binary) ints.Add(i);
                if (model.SignRestrictions[i] == VariableType.Binary) bins.Add(i);
            }
            em.IntegerVarIdxOriginal = ints;
            em.BinaryVarIdxOriginal = bins;
            var map = new int[totalCols];
            for (int j = 0; j < totalCols; j++) map[j] = (j < n ? j : -1);
            em.MapExpandedToOriginal = map;
            em.SlackVarCols = slackCols;
            em.ArtificialVarCols = artificialCols;
            em.VarNames = colNames.ToArray();
            return em;
        }

        private static double[,] ToMatrix(List<double[]> rows)
        {
            int m = rows.Count;
            int n = rows[0].Length;
            var M = new double[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    M[i, j] = rows[i][j];
            return M;
        }
    }


    public class PivotSnapshot
    {
        public int Iteration;
        public int? EnteringIndex;
        public int? LeavingRow;
        public double ObjectiveValue;
        public double[] CurrentSolution = new double[0];
        public double[,] Tableau = new double[0, 0];
        public int[] Basis = new int[0];
    }

    public class SimplexLog
    {
        public List<PivotSnapshot> Snapshots = new List<PivotSnapshot>();
    }

    public enum SimplexStatus { Optimal, Unbounded, Infeasible, IterationLimit }

    public class SimplexResult
    {
        public SimplexStatus Status;
        public double ObjectiveValue;
        public double[] Solution = new double[0];
        public SimplexLog Log = new SimplexLog();
    }

    internal class SimplexSolver
    {
        private readonly ExpandedModel _em;
        private readonly int _m;
        private readonly int _n;
        private const int MaxIter = 10000;

        public SimplexSolver(ExpandedModel em)
        {
            _em = em;
            _m = em.B.Length;
            _n = em.NumVars;
        }

        public SimplexResult Solve(int iterLimit = MaxIter)
        {
            var log = new SimplexLog();
            bool hasArt = (_em.ArtificialVarCols != null && _em.ArtificialVarCols.Count > 0);

            // initial basis
            int[] basis = new int[_m];
            for (int i = 0; i < _m; i++) basis[i] = -1;

            for (int r = 0; r < _m; r++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (Math.Abs(_em.A[r, j] - 1.0) < EPS.Feas)
                    {
                        bool isUnit = true;
                        for (int rr = 0; rr < _m; rr++)
                        {
                            double v = _em.A[rr, j];
                            if (rr == r) { if (Math.Abs(v - 1.0) > EPS.Feas) { isUnit = false; break; } }
                            else { if (Math.Abs(v) > EPS.Feas) { isUnit = false; break; } }
                        }
                        if (isUnit) { basis[r] = j; break; }
                    }
                }
            }

            for (int r = 0; r < _m; r++)
            {
                if (basis[r] == -1)
                {
                    if (_em.ArtificialVarCols != null)
                    {
                        for (int k = 0; k < _em.ArtificialVarCols.Count; k++)
                        {
                            int a = _em.ArtificialVarCols[k];
                            if (Math.Abs(_em.A[r, a] - 1.0) < EPS.Feas) { basis[r] = a; break; }
                        }
                    }
                }
            }

            for (int r = 0; r < _m; r++) if (basis[r] == -1) basis[r] = FallbackUnitColumn(r);

            // Build tableau
            double[,] T = new double[_m + 1, _n + 1];
            for (int i = 0; i < _m; i++)
            {
                for (int j = 0; j < _n; j++) T[i, j] = _em.A[i, j];
                T[i, _n] = _em.B[i];
            }

            // Phase I
            if (hasArt)
            {
                for (int j = 0; j < _n; j++) T[_m, j] = 0.0;
                T[_m, _n] = 0.0;
                for (int k = 0; k < _em.ArtificialVarCols.Count; k++)
                {
                    int a = _em.ArtificialVarCols[k];
                    T[_m, a] = -1.0;
                }

                for (int r = 0; r < _m; r++)
                {
                    int bj = basis[r];
                    bool isArt = false;
                    if (_em.ArtificialVarCols != null)
                    {
                        for (int k = 0; k < _em.ArtificialVarCols.Count; k++)
                        {
                            if (_em.ArtificialVarCols[k] == bj) { isArt = true; break; }
                        }
                    }
                    if (isArt)
                    {
                        double coeff = T[_m, bj];
                        if (Math.Abs(coeff) > EPS.Feas)
                        {
                            for (int j = 0; j <= _n; j++) T[_m, j] -= coeff * T[r, j];
                        }
                    }
                }

                var p1 = RunSimplex(T, basis, 1, iterLimit, log);
                if (p1.Status != SimplexStatus.Optimal || T[_m, _n] < -1e-7)
                {
                    var infeas = new SimplexResult();
                    infeas.Status = SimplexStatus.Infeasible;
                    infeas.Log = log;
                    return infeas;
                }

                // Phase II objective: -c
                for (int j = 0; j < _n; j++) T[_m, j] = -_em.C[j];
                T[_m, _n] = 0.0;
                for (int r = 0; r < _m; r++)
                {
                    int bj = basis[r];
                    double coeff = T[_m, bj];
                    if (Math.Abs(coeff) > EPS.Feas)
                        for (int j = 0; j <= _n; j++) T[_m, j] -= coeff * T[r, j];
                }
            }
            else
            {
                for (int j = 0; j < _n; j++) T[_m, j] = -_em.C[j];
                T[_m, _n] = 0.0;
                for (int r = 0; r < _m; r++)
                {
                    int bj = basis[r];
                    double coeff = T[_m, bj];
                    if (Math.Abs(coeff) > EPS.Feas)
                        for (int j = 0; j <= _n; j++) T[_m, j] -= coeff * T[r, j];
                }
            }

            var p2 = RunSimplex(T, basis, 2, iterLimit, log);

            // Extract original variables
            double[] x = new double[_em.NumOrigVars];
            for (int r = 0; r < _m; r++)
            {
                int bj = basis[r];
                if (bj >= 0 && bj < _em.NumOrigVars) x[bj] = T[r, _n];
            }
            for (int i = 0; i < x.Length; i++) x[i] = Math.Max(0, x[i]);

            var res = new SimplexResult();
            res.Status = p2.Status;
            res.ObjectiveValue = T[_m, _n];
            for (int i = 0; i < x.Length; i++) x[i] = EPS.RoundIfClose(x[i]);
            res.Solution = x;
            res.Log = log;
            return res;
        }

        private SimplexResult RunSimplex(double[,] T, int[] basis, int phase, int iterLimit, SimplexLog log)
        {
            int m = _m;
            int n = _n;
            int iter = 0;

            while (true)
            {
                if (iter++ > iterLimit)
                {
                    var lim = new SimplexResult();
                    lim.Status = SimplexStatus.IterationLimit;
                    lim.Log = log;
                    return lim;
                }

                int entering = -1;
                double mostNeg = -EPS.Opt;
                for (int j = 0; j < n; j++)
                {
                    double cj = T[m, j];
                    if (cj < mostNeg) { mostNeg = cj; entering = j; }
                }

                LogSnapshot(log, T, basis, iter - 1, entering, null);

                if (entering == -1)
                {
                    var opt = new SimplexResult();
                    opt.Status = SimplexStatus.Optimal;
                    opt.Log = log;
                    return opt;
                }

                int leaving = -1;
                double bestRatio = double.PositiveInfinity;
                for (int i = 0; i < m; i++)
                {
                    double aij = T[i, entering];
                    if (aij > EPS.Feas)
                    {
                        double ratio = T[i, n] / aij;
                        if (ratio < bestRatio - 1e-12 || (Math.Abs(ratio - bestRatio) <= 1e-12 && leaving != -1 && basis[i] > basis[leaving]))
                        {
                            bestRatio = ratio; leaving = i;
                        }
                    }
                }

                if (log.Snapshots.Count > 0)
                {
                    var last = log.Snapshots[log.Snapshots.Count - 1];
                    last.LeavingRow = leaving;
                }

                if (leaving == -1)
                {
                    var unb = new SimplexResult();
                    unb.Status = SimplexStatus.Unbounded;
                    unb.Log = log;
                    return unb;
                }

                Pivot(T, leaving, entering);
                basis[leaving] = entering;
            }
        }

        private void Pivot(double[,] T, int pr, int pc)
        {
            int m = T.GetLength(0) - 1;
            int n = T.GetLength(1) - 1;
            double piv = T[pr, pc];
            for (int j = 0; j <= n; j++) T[pr, j] /= piv;
            for (int i = 0; i <= m; i++)
            {
                if (i == pr) continue;
                double factor = T[i, pc];
                if (Math.Abs(factor) < 1e-12) continue;
                for (int j = 0; j <= n; j++)
                {
                    if (j == pc) T[i, j] = 0.0;
                    else T[i, j] -= factor * T[pr, j];
                }
            }
        }

        private void LogSnapshot(SimplexLog log, double[,] T, int[] basis, int iteration, int? entering, int? leaving)
        {
            var snap = new PivotSnapshot();
            snap.Iteration = iteration;
            snap.EnteringIndex = entering;
            snap.LeavingRow = leaving;
            snap.ObjectiveValue = T[_m, _n];

            snap.Basis = new int[basis.Length];
            for (int i = 0; i < basis.Length; i++) snap.Basis[i] = basis[i];

            int R = T.GetLength(0), C = T.GetLength(1);
            var copy = new double[R, C];
            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    copy[i, j] = T[i, j];
            snap.Tableau = copy;

            var x = new double[_em.NumOrigVars];
            for (int r = 0; r < _m; r++)
            {
                int bj = basis[r];
                if (bj >= 0 && bj < _em.NumOrigVars) x[bj] = T[r, _n];
            }
            for (int i = 0; i < x.Length; i++) x[i] = EPS.RoundIfClose(Math.Max(0, x[i]));
            snap.CurrentSolution = x;

            log.Snapshots.Add(snap);
        }

        private int FallbackUnitColumn(int row)
        {
            for (int j = 0; j < _n; j++) if (Math.Abs(_em.A[row, j]) > EPS.Feas) return j;
            return 0;
        }
    }


    // Node class visible to UI (form expects this)
    public class Node
    {
        public int Id;
        public int? ParentId;
        public int Depth;
        public string BranchDescription;
        public string Status;
        public double Bound; // LP relaxation objective (for maximization)
        public double[] VariableAssignments;
        public List<double[,]> Tableaus;
        public List<BranchCut> Cuts;

        public Node(string name, int numVars)
        {
            BranchDescription = name;
            Status = "Open";
            Bound = double.NegativeInfinity;
            VariableAssignments = new double[numVars];
            Tableaus = new List<double[,]>();
            Cuts = new List<BranchCut>();
        }

        public override string ToString()
        {
            return "Node " + Id + " | Bound=" + (double.IsNegativeInfinity(Bound) ? "-" : Bound.ToString("F2"));
        }
    }

    public class BranchCut
    {
        public int VarIndex;
        public bool IsUpper; // true => <= rhs, false => >= rhs
        public double Rhs;
        public BranchCut() { }
        public BranchCut(int varIndex, bool isUpper, double rhs) { VarIndex = varIndex; IsUpper = isUpper; Rhs = rhs; }
        public override string ToString() { return "x" + (VarIndex + 1) + (IsUpper ? " <= " : " >= ") + Rhs; }
    }

    public class BranchAndBoundSolver
    {
        private readonly LPModel _model;
        private readonly ExpandedModel _baseEm;
        private int _nextNodeId = 1;

        public List<Node> AllNodes = new List<Node>();
        public double BestObjective = double.NegativeInfinity;
        public double[] BestSolution; // may be null, check before use

        public BranchAndBoundSolver(LPModel model)
        {
            _model = model;
            _baseEm = ModelBuilder.BuildStandardForm(model);
        }

        public void Solve()
        {
            AllNodes.Clear();
            BestObjective = double.NegativeInfinity;
            BestSolution = null;

            Node root = CreateNode(null, 0, "root", new List<BranchCut>());
            SolveNode(root);
            AllNodes.Add(root);

            var openList = new List<Node>();
            openList.Add(root);

            while (true)
            {
                // collect open nodes
                var candidates = new List<Node>();
                for (int i = 0; i < openList.Count; i++) if (openList[i].Status == "Open") candidates.Add(openList[i]);
                if (candidates.Count == 0) break;

                // best-first by bound
                candidates.Sort((a, b) => b.Bound.CompareTo(a.Bound));
                Node node = candidates[0];

                if (node.Bound <= BestObjective + 1e-9)
                {
                    node.Status = "Pruned_By_Bound";
                    continue;
                }

                if (node.VariableAssignments == null || node.VariableAssignments.Length == 0)
                {
                    node.Status = "Fathomed_Infeasible";
                    continue;
                }

                int fracIdx = FindFirstFractional(node.VariableAssignments, _baseEm.IntegerVarIdxOriginal);
                if (fracIdx == -1)
                {
                    node.Status = "Fathomed_Integral";
                    if (node.Bound > BestObjective)
                    {
                        BestObjective = node.Bound;
                        BestSolution = (double[])node.VariableAssignments.Clone();
                    }
                    continue;
                }

                double v = node.VariableAssignments[fracIdx];
                double fl = Math.Floor(v);
                double ce = Math.Ceiling(v);

                // left child: x <= floor
                var leftCuts = CloneCuts(node.Cuts);
                leftCuts.Add(new BranchCut(fracIdx, true, fl));
                Node left = CreateNode(node.Id, node.Depth + 1, "x" + (fracIdx + 1) + " <= " + fl, leftCuts);
                SolveNode(left);
                AllNodes.Add(left);
                openList.Add(left);

                // right child: x >= ceil
                var rightCuts = CloneCuts(node.Cuts);
                rightCuts.Add(new BranchCut(fracIdx, false, ce));
                Node right = CreateNode(node.Id, node.Depth + 1, "x" + (fracIdx + 1) + " >= " + ce, rightCuts);
                SolveNode(right);
                AllNodes.Add(right);
                openList.Add(right);

                node.Status = "Expanded";

                if (left.Status == "Open" && left.Bound <= BestObjective + 1e-9) left.Status = "Pruned_By_Bound";
                if (right.Status == "Open" && right.Bound <= BestObjective + 1e-9) right.Status = "Pruned_By_Bound";

                if (left.Status == "Fathomed_Integral" && left.Bound > BestObjective)
                {
                    BestObjective = left.Bound;
                    BestSolution = (double[])left.VariableAssignments.Clone();
                }
                if (right.Status == "Fathomed_Integral" && right.Bound > BestObjective)
                {
                    BestObjective = right.Bound;
                    BestSolution = (double[])right.VariableAssignments.Clone();
                }
            }
        }

        private Node CreateNode(int? parentId, int depth, string desc, List<BranchCut> cuts)
        {
            Node node = new Node(desc, _baseEm.NumOrigVars);
            node.Id = _nextNodeId++;
            node.ParentId = parentId;
            node.Depth = depth;
            node.Cuts = cuts;
            node.BranchDescription = desc;
            node.Status = "Open";
            node.Bound = double.NegativeInfinity;
            return node;
        }

        private static List<BranchCut> CloneCuts(List<BranchCut> cuts)
        {
            var list = new List<BranchCut>(cuts.Count);
            for (int i = 0; i < cuts.Count; i++)
            {
                var c = cuts[i];
                list.Add(new BranchCut(c.VarIndex, c.IsUpper, c.Rhs));
            }
            return list;
        }

        private void SolveNode(Node node)
        {
            ExpandedModel em = CloneExpandedModel(_baseEm);

            for (int ci = 0; ci < node.Cuts.Count; ci++)
            {
                BranchCut cut = node.Cuts[ci];
                int newCols = em.NumVars + (cut.IsUpper ? 1 : 2);
                var newA = new double[em.A.GetLength(0) + 1, newCols];
                var newB = new double[em.B.Length + 1];

                // copy
                for (int i = 0; i < em.A.GetLength(0); i++)
                    for (int j = 0; j < em.A.GetLength(1); j++)
                        newA[i, j] = em.A[i, j];
                for (int i = 0; i < em.B.Length; i++) newB[i] = em.B[i];

                var row = new double[newCols];
                for (int j = 0; j < em.NumOrigVars; j++) row[j] = (j == cut.VarIndex ? 1.0 : 0.0);

                if (cut.IsUpper)
                {
                    row[em.NumVars] = 1.0;
                    em.SlackVarCols.Add(em.NumVars);
                    var names = new List<string>(em.VarNames);
                    names.Add("s" + em.SlackVarCols.Count);
                    em.VarNames = names.ToArray();
                    newB[newB.Length - 1] = cut.Rhs;
                }
                else
                {
                    row[em.NumVars] = -1.0;
                    row[em.NumVars + 1] = 1.0;
                    em.SlackVarCols.Add(em.NumVars);
                    em.ArtificialVarCols.Add(em.NumVars + 1);
                    var names = new List<string>(em.VarNames);
                    names.Add("e" + em.SlackVarCols.Count);
                    names.Add("a" + em.ArtificialVarCols.Count);
                    em.VarNames = names.ToArray();
                    newB[newB.Length - 1] = cut.Rhs;
                }

                int oldRows = em.A.GetLength(0);
                for (int j = 0; j < newCols; j++) newA[oldRows, j] = row[j];

                em.A = newA; em.B = newB; em.NumVars = newCols;

                var newC = new double[newCols];
                for (int j = 0; j < em.C.Length; j++) newC[j] = em.C[j];
                em.C = newC;
            }

            var simplex = new SimplexSolver(em);
            var res = simplex.Solve();

            node.Tableaus.Clear();
            if (res != null && res.Log != null && res.Log.Snapshots != null)
            {
                for (int s = 0; s < res.Log.Snapshots.Count; s++)
                    node.Tableaus.Add(res.Log.Snapshots[s].Tableau);
            }

            if (res == null || res.Status == SimplexStatus.Infeasible)
            {
                node.Status = "Fathomed_Infeasible";
                node.Bound = double.NegativeInfinity;
                return;
            }
            if (res.Status == SimplexStatus.Unbounded)
            {
                node.Status = "Fathomed_Unbounded";
                node.Bound = double.PositiveInfinity;
                return;
            }
            if (res.Status == SimplexStatus.Optimal)
            {
                node.VariableAssignments = res.Solution;
                node.Bound = res.ObjectiveValue;
                node.Status = "Open";
                return;
            }

            node.Status = "Fathomed_Infeasible";
            node.Bound = double.NegativeInfinity;
        }

        private int FindFirstFractional(double[] x, List<int> integerIdx)
        {
            for (int i = 0; i < integerIdx.Count; i++)
            {
                int k = integerIdx[i];
                if (k < 0 || k >= x.Length) continue;
                double v = x[k];
                if (Math.Abs(v - Math.Round(v)) > 1e-9) return k;
            }
            return -1;
        }

        private ExpandedModel CloneExpandedModel(ExpandedModel em)
        {
            var clone = new ExpandedModel();
            clone.IsMaximization = em.IsMaximization;
            clone.NumVars = em.NumVars;
            clone.NumOrigVars = em.NumOrigVars;
            clone.C = (double[])em.C.Clone();
            clone.A = (double[,])em.A.Clone();
            clone.B = (double[])em.B.Clone();
            clone.IntegerVarIdxOriginal = new List<int>(em.IntegerVarIdxOriginal);
            clone.BinaryVarIdxOriginal = new List<int>(em.BinaryVarIdxOriginal);
            clone.MapExpandedToOriginal = (int[])em.MapExpandedToOriginal.Clone();
            clone.SlackVarCols = new List<int>(em.SlackVarCols);
            clone.ArtificialVarCols = new List<int>(em.ArtificialVarCols);
            clone.VarNames = (string[])em.VarNames.Clone();
            return clone;
        }
    }

}
