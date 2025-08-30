using System;
using System.Collections.Generic;
using System.Linq;
using static LinearProgrammingSolver.LPInputParser;

namespace LinearProgrammingSolver
{
    public class CuttingPlaneResult
    {
        public List<IterationResult> Iterations { get; set; }
        public bool IsOptimal { get; set; }
        public bool IsInteger { get; set; }
        public double[] Solution { get; set; }
        public double ObjectiveValue { get; set; }

        public CuttingPlaneResult()
        {
            Iterations = new List<IterationResult>();
        }
    }

    public class IterationResult
    {
        public int Iteration { get; set; }
        public double ObjectiveValue { get; set; }
        public double[] PrimalSolution { get; set; }
        public bool IsOptimal { get; set; }
        public bool IsInteger { get; set; }
        public string Cut { get; set; }
        public SimplexResult SimplexResult { get; set; }
        public ExpandedModel ExpandedModel { get; set; }
        public string TerminationReason { get; set; }
    }

    public class CuttingPlaneSolver
    {
        private LPModel model;
        public int MaxIterations { get; set; } = 50;

        public CuttingPlaneSolver(LPModel m)
        {
            this.model = m;
        }

        public CuttingPlaneResult Solve()
        {
            var result = new CuttingPlaneResult();
            double lastObjectiveValue = double.MinValue;

            for (int i = 0; i < MaxIterations; i++)
            {
                var expandedModel = ModelBuilder.BuildStandardForm(model);
                var simplexSolver = new SimplexSolver(expandedModel);
                var simplexResult = simplexSolver.Solve();

                var iterResult = new IterationResult
                {
                    Iteration = i + 1,
                    ObjectiveValue = simplexResult.ObjectiveValue,
                    PrimalSolution = simplexResult.Solution,
                    IsOptimal = simplexResult.Status == SimplexStatus.Optimal,
                    SimplexResult = simplexResult,
                    ExpandedModel = expandedModel,
                    TerminationReason = simplexResult.TerminationReason
                };

                if (simplexResult.Status != SimplexStatus.Optimal)
                {
                    result.Iterations.Add(iterResult);
                    result.IsOptimal = false;
                    return result;
                }

                if (i > 0 && Math.Abs(simplexResult.ObjectiveValue - lastObjectiveValue) < 1e-6)
                {
                    result.Iterations.Add(iterResult);
                    result.IsOptimal = false; // Not converging
                    return result;
                }
                lastObjectiveValue = simplexResult.ObjectiveValue;

                bool isInteger = true;
                int firstFractionalVarIndex = -1;
                for (int j = 0; j < simplexResult.Solution.Length; j++)
                {
                    if (Math.Abs(simplexResult.Solution[j] - Math.Round(simplexResult.Solution[j])) > 1e-6)
                    {
                        isInteger = false;
                        firstFractionalVarIndex = j;
                        break;
                    }
                }

                iterResult.IsInteger = isInteger;
                result.Iterations.Add(iterResult);

                if (isInteger)
                {
                    result.IsOptimal = true;
                    result.IsInteger = true;
                    result.Solution = simplexResult.Solution;
                    result.ObjectiveValue = simplexResult.ObjectiveValue;
                    return result;
                }

                var finalTableau = simplexResult.Log.Snapshots.Last().Tableau;
                var finalBasis = simplexResult.Log.Snapshots.Last().Basis;
                int cutRowIndex = -1;
                for (int j = 0; j < finalBasis.Length; j++)
                {
                    if (finalBasis[j] == firstFractionalVarIndex)
                    {
                        cutRowIndex = j;
                        break;
                    }
                }

                if (cutRowIndex == -1)
                {
                    return result;
                }

                var cutCoeffs = new double[expandedModel.NumVars];
                for (int j = 0; j < expandedModel.NumVars; j++)
                {
                    double val = finalTableau[cutRowIndex, j];
                    cutCoeffs[j] = -(val - Math.Floor(val));
                }
                double rhs = finalTableau[cutRowIndex, finalTableau.GetLength(1) - 1];
                double cutRhs = -(rhs - Math.Floor(rhs));

                var finalCutCoeffs = new double[model.NumberOfVariables];
                double finalCutRhs = cutRhs;

                for (int j = 0; j < expandedModel.NumVars; j++)
                {
                    double coeff = cutCoeffs[j];
                    if (Math.Abs(coeff) < 1e-6) continue;

                    if (j < model.NumberOfVariables)
                    {
                        finalCutCoeffs[j] += coeff;
                    }
                    else if (expandedModel.SlackVarToConstraintMap.ContainsKey(j))
                    {
                        int constraintIndex = expandedModel.SlackVarToConstraintMap[j];
                        var constraint = expandedModel.Constraints[constraintIndex];

                        if (constraint.Type == ConstraintType.LessOrEqual)
                        {
                            finalCutRhs -= coeff * constraint.RightHandSide;
                            for (int k = 0; k < constraint.Coefficients.Count; k++)
                            {
                                finalCutCoeffs[k] -= coeff * constraint.Coefficients[k];
                            }
                        }
                        else // GreaterOrEqual
                        {
                            finalCutRhs += coeff * constraint.RightHandSide;
                            for (int k = 0; k < constraint.Coefficients.Count; k++)
                            {
                                finalCutCoeffs[k] += coeff * constraint.Coefficients[k];
                            }
                        }
                    }
                }

                var newConstraint = new Constraint
                {
                    Coefficients = finalCutCoeffs.ToList(),
                    Type = ConstraintType.LessOrEqual,
                    RightHandSide = finalCutRhs
                };

                string cutString = "";
                for(int j=0; j<finalCutCoeffs.Length; j++)
                {
                    if(Math.Abs(finalCutCoeffs[j]) > 1e-6)
                        cutString += $" {finalCutCoeffs[j]:F2}x{j + 1}";
                }
                cutString += $" <= {finalCutRhs:F2}";

                iterResult.Cut = cutString.Trim();
                model.Constraints.Add(newConstraint);
            }

            return result;
        }
    }
}
