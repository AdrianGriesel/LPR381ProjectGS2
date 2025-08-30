using System;
using System.Collections.Generic;
using System.Linq;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Analysis
{
    internal class DualBuilder
    {
        public static LPModel BuildDualForSolver(LPModel primal)
        {
            if (primal == null) return null;
            if (!primal.IsMaximization) return null;
            if (primal.Constraints.Exists(c => c.Type != ConstraintType.LessOrEqual)) return null;
            if (primal.SignRestrictions.Exists(v => v != VariableType.Positive)) return null;

            int m = primal.Constraints.Count;      // primal rows -> dual variables
            int n = primal.NumberOfVariables;      // primal cols -> dual constraints

            var dual = new LPModel
            {
                IsMaximization = true,             // for solver, must be max
                NumberOfVariables = m
            };

            // dual objective = primal RHS
            for (int i = 0; i < m; i++)
                dual.ObjectiveCoefficients.Add(primal.Constraints[i].RightHandSide);

            // dual constraints = transpose of primal A
            for (int j = 0; j < n; j++)
            {
                var c = new Constraint();
                for (int i = 0; i < m; i++)
                    c.Coefficients.Add(primal.Constraints[i].Coefficients[j]);

                // originally >= because x_j >= 0 in primal
                c.Type = ConstraintType.GreaterOrEqual;

                // rhs = primal objective coefficient
                c.RightHandSide = primal.ObjectiveCoefficients[j];

                // convert >= to <= for solver
                if (c.Type == ConstraintType.GreaterOrEqual)
                {
                    for (int k = 0; k < c.Coefficients.Count; k++)
                        c.Coefficients[k] *= -1;
                    c.RightHandSide *= -1;
                    c.Type = ConstraintType.LessOrEqual;
                }

                dual.Constraints.Add(c);
            }

            // dual variables >= 0
            for (int i = 0; i < m; i++)
                dual.SignRestrictions.Add(VariableType.Positive);

            return dual;
        }
    }
}

