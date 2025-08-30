using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Analysis
{

    // returns a solver-compatible dual:
    // max ( -b^T y )  s.t.  ( -A^T ) y <= ( -c ),  y >= 0
    // this fits the primal solver which expects MAX with <= only

    internal class BuildDual
    {
        public static LPModel DualBuild(LPModel primal)
        {
            if (primal == null) return null;
            // for now support the classroom case: primal is max, <=, x >= 0
            if (!primal.IsMaximization) return null;
            if (primal.Constraints.Exists(c => c.Type != ConstraintType.LessOrEqual)) return null;
            if (primal.SignRestrictions.Exists(v => v != VariableType.Positive)) return null;

            int m = primal.Constraints.Count;      // primal rows -> dual variables
            int n = primal.NumberOfVariables;      // primal cols -> dual constraints

            var dual = new LPModel
            {
                IsMaximization = true,             // we flip min to max by negating objective
                NumberOfVariables = m
            };

            // objective: -b (negate primal rhs)
            for (int i = 0; i < m; i++)
                dual.ObjectiveCoefficients.Add(-primal.Constraints[i].RightHandSide);

            // constraints: (-A^T) y <= (-c)
            for (int j = 0; j < n; j++)
            {
                var row = new Constraint();

                // coefficients are the negated column j of A
                for (int i = 0; i < m; i++)
                    row.Coefficients.Add(-primal.Constraints[i].Coefficients[j]);

                row.Type = ConstraintType.LessOrEqual;
                row.RightHandSide = -primal.ObjectiveCoefficients[j]; // -c_j

                dual.Constraints.Add(row);
            }

            // y >= 0 because primal has <= constraints
            for (int i = 0; i < m; i++)
                dual.SignRestrictions.Add(VariableType.Positive);

            return dual;
        }
    }
}

