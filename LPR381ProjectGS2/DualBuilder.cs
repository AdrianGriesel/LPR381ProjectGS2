using System;
using System.Collections.Generic;
using System.Linq;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Analysis
{
    internal class DualBuilder
    {
        // Builds a solver-compatible dual from a primal LP model
        // Assumes primal: max, all <= constraints, all x >= 0
        public static LPModel BuildDual(LPModel primal)
        {
            if (primal == null) return null;
            if (!primal.IsMaximization) return null;
            if (primal.Constraints.Exists(c => c.Type != ConstraintType.LessOrEqual)) return null;
            if (primal.SignRestrictions.Exists(v => v != VariableType.Positive)) return null;

            int m = primal.Constraints.Count;      // primal rows -> dual vars
            int n = primal.NumberOfVariables;      // primal cols -> dual constraints

            var dual = new LPModel
            {
                IsMaximization = true,             // solver expects MAX
                NumberOfVariables = m
            };

            // Objective: -b^T y (negate RHS of primal)
            for (int i = 0; i < m; i++)
                dual.ObjectiveCoefficients.Add(-primal.Constraints[i].RightHandSide);

            // Constraints: (-A^T) y <= -c
            for (int j = 0; j < n; j++)
            {
                var row = new Constraint();

                for (int i = 0; i < m; i++)
                    row.Coefficients.Add(-primal.Constraints[i].Coefficients[j]);

                row.Type = ConstraintType.LessOrEqual;
                row.RightHandSide = -primal.ObjectiveCoefficients[j];

                dual.Constraints.Add(row);
            }

            // y >= 0 because primal constraints are <=
            for (int i = 0; i < m; i++)
                dual.SignRestrictions.Add(VariableType.Positive);

            return dual;
        }
    }
}
