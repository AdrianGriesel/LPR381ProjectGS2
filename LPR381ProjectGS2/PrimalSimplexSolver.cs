using LPR381ProjectGS2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Algorithms
{
    public class PrimalSimplexSolver
    {
        private const double EPS = 1e-9;

        public SimplexResult Solve(LPModel model)
        {
            var res = new SimplexResult();
            res.IsMaximization = model.IsMaximization;

            // phase i not implemented: reject >= or = constraints
            if (model.Constraints.Any(c => c.Type != ConstraintType.LessOrEqual))
            {
                res.Status = SimplexStatus.Phase1Required;
                res.TerminationReason = "model contains >= or = constraints. phase i required.";
                res.CanonicalFormText = PrettyCanonical(model, includeSlack: false);
                return res;
            }

            // build initial tableau for <= only (adds one slack per constraint)
            var (T, colLabels, rowLabels) = BuildInitialTableau_LE_Only(model);
            res.CanonicalFormText = PrettyCanonical(model, includeSlack: true);

            // log initial tableau as iteration 1
            res.Iterations.Add(TableauSnapshot.From(T, colLabels, rowLabels));

            int guard = 0;
            while (true)
            {
                // simple guard for infinite loops / degeneracy
                if (guard++ > 1000)
                {
                    res.Status = SimplexStatus.Infeasible;
                    res.TerminationReason = "iteration limit reached (possible degeneracy).";
                    break;
                }

                // choose entering column based on max/min convention
                int enterCol = SelectEnteringColumn(T, model.IsMaximization);
                if (enterCol == -1)
                {
                    // optimal: no improving reduced costs remain
                    res.Status = SimplexStatus.Optimal;
                    res.TerminationReason = model.IsMaximization
                        ? "no positive reduced costs in z row."
                        : "no negative reduced costs in z row.";

                    (res.ObjectiveValue, res.Primal) = ExtractSolution(T, colLabels, rowLabels, model.NumberOfVariables, model);

                    break;
                }

                // choose leaving row using minimum ratio test
                int leaveRow = SelectLeavingRow(T, enterCol);
                if (leaveRow == -1)
                {
                    // entering column has no positive entries -> unbounded
                    res.Status = SimplexStatus.Unbounded;
                    res.TerminationReason = "no positive coefficients in entering column (unbounded).";
                    break;
                }

                // perform pivot
                Pivot(T, leaveRow, enterCol);

                // update basis label to reflect new basic variable
                rowLabels[leaveRow] = colLabels[enterCol];

                // log the new tableau as next iteration
                res.Iterations.Add(TableauSnapshot.From(T, colLabels, rowLabels, enterCol, leaveRow));
            }

            return res;
        }

        // builds initial tableau for <= constraints only
        private static (double[,] T, string[] Cols, string[] Rows) BuildInitialTableau_LE_Only(LPModel model)
        {
            int n = model.NumberOfVariables;
            int m = model.Constraints.Count;

            // keep original objective coefficients; z-row sign is set below
            var c = model.ObjectiveCoefficients.ToArray();

            // columns: x1..xn, s1..sm, rhs
            int cols = n + m + 1;
            // rows: constraints + z row
            int rows = m + 1;

            var T = new double[rows, cols];

            // constraint rows
            for (int i = 0; i < m; i++)
            {
                var cons = model.Constraints[i];

                for (int j = 0; j < n; j++)
                    T[i, j] = cons.Coefficients[j];

                T[i, n + i] = 1.0;                   // slack i
                T[i, cols - 1] = cons.RightHandSide; // rhs
            }

            // z row sign depends on problem type:
            // max: +c and we improve while there exists a positive reduced cost
            // min: -c and we improve while there exists a negative reduced cost
            double sign = model.IsMaximization ? +1.0 : -1.0;
            for (int j = 0; j < n; j++)
                T[rows - 1, j] = sign * c[j];

            // labels
            var colLabels = new List<string>();
            for (int j = 0; j < n; j++) colLabels.Add("x" + (j + 1));
            for (int s = 0; s < m; s++) colLabels.Add("s" + (s + 1));
            colLabels.Add("RHS");

            var rowLabels = new List<string>();
            for (int i = 0; i < m; i++) rowLabels.Add("s" + (i + 1));
            rowLabels.Add("Z");

            return (T, colLabels.ToArray(), rowLabels.ToArray());
        }

        // selects entering column using the chosen convention
        private int SelectEnteringColumn(double[,] T, bool isMax)
        {
            int rows = T.GetLength(0);
            int cols = T.GetLength(1);
            int z = rows - 1;
            int rhs = cols - 1;

            int bestCol = -1;

            if (isMax)
            {
                // max: look for strictly positive reduced cost
                double bestVal = 0.0;
                for (int j = 0; j < rhs; j++)
                {
                    double v = T[z, j];
                    if (v > bestVal + EPS)
                    {
                        bestVal = v;
                        bestCol = j;
                    }
                }
            }
            else
            {
                // min: look for strictly negative reduced cost
                double bestVal = 0.0;
                for (int j = 0; j < rhs; j++)
                {
                    double v = T[z, j];
                    if (v < bestVal - EPS)
                    {
                        bestVal = v;
                        bestCol = j;
                    }
                }
            }

            return bestCol; // -1 means optimal
        }

        // minimum ratio test over constraint rows only
        private int SelectLeavingRow(double[,] T, int enterCol)
        {
            int rows = T.GetLength(0);
            int cols = T.GetLength(1);
            int rhs = cols - 1;
            int z = rows - 1;

            int bestRow = -1;
            double bestRatio = double.PositiveInfinity;

            for (int i = 0; i < z; i++)
            {
                double a = T[i, enterCol];
                if (a > EPS)
                {
                    double ratio = T[i, rhs] / a;
                    if (ratio < bestRatio - EPS)
                    {
                        bestRatio = ratio;
                        bestRow = i;
                    }
                }
            }
            return bestRow;
        }

        // gauss-jordan pivot at (pivotRow, pivotCol)
        private void Pivot(double[,] T, int pivotRow, int pivotCol)
        {
            int rows = T.GetLength(0);
            int cols = T.GetLength(1);

            double p = T[pivotRow, pivotCol];

            // normalize pivot row
            for (int j = 0; j < cols; j++)
                T[pivotRow, j] /= p;

            // eliminate pivot column from other rows
            for (int i = 0; i < rows; i++)
            {
                if (i == pivotRow) continue;
                double factor = T[i, pivotCol];
                if (Math.Abs(factor) < EPS) continue;

                for (int j = 0; j < cols; j++)
                    T[i, j] -= factor * T[pivotRow, j];
            }
        }

        // reads x and z from final tableau and fixes z sign for max case
        // read x from the final tableau using row labels,
        // then compute z = c^T x from the original objective
        private (double z, double[] x) ExtractSolution(
            double[,] T,
            string[] colLabels,
            string[] rowLabels,
            int nVars,
            LPModel model) // pass model so we can use original c
        {
            int rows = T.GetLength(0);
            int cols = T.GetLength(1);
            int rhsCol = cols - 1;

            var x = new double[nVars];

            // collect basic variable values from rhs
            for (int i = 0; i < rowLabels.Length - 1; i++) // skip z row
            {
                string lbl = rowLabels[i];
                if (!string.IsNullOrEmpty(lbl) && lbl[0] == 'x')
                {
                    int k;
                    if (int.TryParse(lbl.Substring(1), out k))
                    {
                        int idx = k - 1;
                        if (idx >= 0 && idx < nVars)
                            x[idx] = T[i, rhsCol];
                    }
                }
            }

            // compute objective directly from input coefficients
            double z = 0.0;
            for (int j = 0; j < nVars; j++)
                z += model.ObjectiveCoefficients[j] * x[j];

            return (z, x);
        }



        // pretty print canonical form for logging
        private string PrettyCanonical(LPModel model, bool includeSlack)
        {
            var lines = new List<string>();

            lines.Add((model.IsMaximization ? "max" : "min") + " z = " +
                string.Join(" ", model.ObjectiveCoefficients.Select((v, i) =>
                    (v >= 0 ? "+ " : "- ") + Math.Abs(v) + "*x" + (i + 1))).TrimStart('+', ' '));

            for (int i = 0; i < model.Constraints.Count; i++)
            {
                var c = model.Constraints[i];

                var lhs = string.Join(" ", c.Coefficients.Select((v, j) =>
                    (v >= 0 ? "+ " : "- ") + Math.Abs(v) + "*x" + (j + 1))).TrimStart('+', ' ');

                string rel = c.Type == ConstraintType.LessOrEqual ? "<=" :
                             c.Type == ConstraintType.GreaterOrEqual ? ">=" : "=";

                string slack = includeSlack ? $" + 1*s{i + 1}" : "";

                lines.Add($"{lhs}{slack} {rel} {c.RightHandSide}");
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
