using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2.Domain.Analysis
{
    internal class DualBuilder
    {

        // builds the dual lp from a primal lpmodel
        // first pass supports the common case:
        // primal: max, all constraints <=, all variables >= 0  

        public static LPModel BuildDual(LPModel primal)
        {
            // guard unsupported forms for now
            if (primal == null) return null;
            if (!primal.IsMaximization) return null;
            if (primal.Constraints.Exists(c => c.Type != ConstraintType.LessOrEqual)) return null;
            if (primal.SignRestrictions.Exists(v => v != VariableType.Positive)) return null;

            int m = primal.Constraints.Count;      // rows in primal -> vars in dual
            int n = primal.NumberOfVariables;      // vars in primal -> rows in dual

            var dual = new LPModel
            {
                IsMaximization = false,            // dual is min
                NumberOfVariables = m
            };

            // dual objective coeffs = rhs of primal constraints
            for (int i = 0; i < m; i++)
                dual.ObjectiveCoefficients.Add(primal.Constraints[i].RightHandSide);

            // dual constraints = transpose of A
            for (int j = 0; j < n; j++)
            {
                var row = new Constraint();

                // coefficients = column j of primal A
                for (int i = 0; i < m; i++)
                    row.Coefficients.Add(primal.Constraints[i].Coefficients[j]);

                // since x_j >= 0 in primal, the jth dual constraint is >=
                row.Type = ConstraintType.GreaterOrEqual;

                // rhs = c_j from the primal objective
                row.RightHandSide = primal.ObjectiveCoefficients[j];

                dual.Constraints.Add(row);
            }

            // y_i >= 0 because primal constraints are <=
            for (int i = 0; i < m; i++)
                dual.SignRestrictions.Add(VariableType.Positive);

            return dual;
        }
    }
}



