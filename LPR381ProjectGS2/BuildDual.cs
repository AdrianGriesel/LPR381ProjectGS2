using System;
using System.Collections.Generic;
using System.Linq;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Analysis
{
    internal class BuildDual
    {
        public static LPModel DualBuild(LPModel primal)
        {
            if (primal == null) return null;

            // Only supports classroom case: max, all <=, all x >= 0
            if (!primal.IsMaximization) return null;
            if (primal.Constraints.Exists(c => c.Type != ConstraintType.LessOrEqual)) return null;
            if (primal.SignRestrictions.Exists(v => v != VariableType.Positive)) return null;

            int m = primal.Constraints.Count;      // primal rows -> dual vars
            int n = primal.NumberOfVariables;      // primal cols -> dual constraints

            var dual = new LPModel
            {
                IsMaximization = true,             // dual is max
                NumberOfVariables = m
            };

            // Assign variable names y1..ym for dual
            dual.VariableNames = Enumerable.Range(1, m).Select(i => "y" + i).ToList();

            // Assign constraint names c1..cn for dual
            dual.ConstraintNames = Enumerable.Range(1, n).Select(i => "c" + i).ToList();

            // Objective: -b (negate primal RHS)
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

            // y >= 0
            for (int i = 0; i < m; i++)
                dual.SignRestrictions.Add(VariableType.Positive);

            return dual;
        }
    }
}

