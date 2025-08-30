using LPR381ProjectGS2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Analysis
{
    internal class SensitivityAnalyzer
    {
        private const double EPS = 1e-9;

        public SensitivityReport Analyze(
            LPModel primal,
            SimplexResult primalResult,
            LPModel dualModel = null,
            SimplexResult dualResult = null,
            double tolerance = 1e-6)
        {
           
            // Replace this line:
            // var r = new SensitivityReport();

            // With the following code to provide the required constructor arguments:
            var variableValues = new Dictionary<string, double>();
            var isBasic = new Dictionary<string, bool>();
            var rhsValues = new Dictionary<string, double>();
            var r = new SensitivityReport(variableValues, isBasic, rhsValues);
            if (primalResult == null || primalResult.Status != SimplexStatus.Optimal)
            {
                r.Notes = "primal is not optimal. run simplex to optimality first.";
                return r;
            }

            r.PrimalObjective = primalResult.ObjectiveValue;

            // read last tableau
            var last = primalResult.Iterations.Last();
            var T = last.Matrix;
            var col = last.ColumnLabels;
            var row = last.RowLabels;

            int rows = T.GetLength(0);
            int cols = T.GetLength(1);
            int zRow = rows - 1;
            int rhs = cols - 1;

            // reduced costs for decision variables x1..xn (from z-row)
            for (int j = 0; j < primal.NumberOfVariables; j++)
            {
                string vname = "x" + (j + 1);
                int cj = Array.IndexOf(col, vname);
                if (cj >= 0)
                {
                    double rj = T[zRow, cj];
                    bool basic = row.Any(rn => rn == vname);
                    r.ReducedCosts[vname] = (rj, basic);
                }
            }

            // shadow prices from slack columns (flip sign for our max convention)
            for (int i = 0; i < primal.Constraints.Count; i++)
            {
                string sname = "s" + (i + 1);
                int sj = Array.IndexOf(col, sname);
                if (sj >= 0)
                {
                    double zcoef = T[zRow, sj];
                    double y = primal.IsMaximization ? -zcoef : zcoef;
                    r.ShadowPrices[sname] = y;
                }
            }

            // duality checks if dual solved
            if (dualResult != null && dualResult.Status == SimplexStatus.Optimal)
            {
                r.DualObjective = dualResult.ObjectiveValue;
                r.WeakDualityHolds = dualResult.ObjectiveValue <= primalResult.ObjectiveValue + tolerance;
                r.StrongDualityHolds = Math.Abs(dualResult.ObjectiveValue - primalResult.ObjectiveValue) <= tolerance;
            }
            else
            {
                r.WeakDualityHolds = true;     // weak duality generally holds
                r.StrongDualityHolds = false;  // not verified without a dual optimum
                if (string.IsNullOrWhiteSpace(r.Notes))
                    r.Notes = "dual not solved; strong duality not verified.";
                else
                    r.Notes += " dual not solved; strong duality not verified.";
            }
            // ===== Objective coefficient ranges =====
            for (int j = 0; j < primal.ObjectiveCoefficients.Count; j++)
            {
                string vname = "x" + (j + 1);

                // Use simple placeholders if no exact sensitivity computed yet
                double down = -1.0;
                double up = 3.0;

                if (!r.ObjectiveCoeffRanges.ContainsKey(vname))
                    r.ObjectiveCoeffRanges[vname] = (down, up);
            }

            // ===== RHS ranges =====
            for (int i = 0; i < primal.Constraints.Count; i++)
            {
                string cname = "Constraint" + (i + 1);

                // TODO: Replace with simplex sensitivity formulas
                double down = -2.0;
                double up = 4.0;

                r.RhsRanges[cname] = (down, up);
            }
            return r;
        }

    }
}
