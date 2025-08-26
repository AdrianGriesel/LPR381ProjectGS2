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
            var r = new SensitivityReport();

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
                    bool isBasic = row.Any(rn => rn == vname);
                    r.ReducedCosts[vname] = (rj, isBasic);
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

            return r;
        }

    }
}
