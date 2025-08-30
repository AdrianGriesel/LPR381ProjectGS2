using LinearProgrammingSolver;
using System;
using System.Collections.Generic;
using static LinearProgrammingSolver.LPInputParser;

public static class LPStandardizer
{
    /// <summary>
    /// Converts an LP model to standard form suitable for the PrimalSimplexSolver:
    /// Maximization, all <= constraints, all variables >= 0.
    /// </summary>
    public static LPModel ConvertToMaxForm(LPModel model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        // Clone the model to avoid mutating original
        var newModel = new LPModel
        {
            IsMaximization = true, // Force max
            ObjectiveCoefficients = new List<double>(model.ObjectiveCoefficients),
            Constraints = new List<Constraint>()
        };

        foreach (var c in model.Constraints)
        {
            var newC = new Constraint
            {
                Coefficients = new List<double>(c.Coefficients),
                RightHandSide = c.RightHandSide,
                Type = c.Type
            };

            // Flip min -> max or >= constraints -> <= constraints
            if (c.Type == ConstraintType.GreaterOrEqual)
            {
                for (int i = 0; i < newC.Coefficients.Count; i++)
                    newC.Coefficients[i] *= -1;
                newC.RightHandSide *= -1;
                newC.Type = ConstraintType.LessOrEqual;
            }

            newModel.Constraints.Add(newC);
        }

        // If original LP was a minimization, flip the objective
        if (!model.IsMaximization)
        {
            for (int i = 0; i < newModel.ObjectiveCoefficients.Count; i++)
                newModel.ObjectiveCoefficients[i] *= -1;
        }

        return newModel;
    }
}
