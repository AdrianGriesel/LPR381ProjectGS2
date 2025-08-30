using System;
using System.Collections.Generic;

namespace LinearProgrammingSolver
{
    using static LPInputParser;
    public class CuttingPlaneSolver
    {

        private LPModel model;

        public string[] ColumnNames { get; private set; }   // x1,x2,...,s1,...
        public string[] RowNames { get; private set; }      // C1, C2, ..., Z
        public double[,] CanonicalForm { get; private set; }
        public List<double[,]> Iterations { get; private set; }

        public CuttingPlaneSolver(LPModel m)
        {
            this.model = m;
            this.Iterations = new List<double[,]>();
        }

        public void Solve()
        {
            CanonicalForm = BuildCanonicalForm();
            Iterations.Add((double[,])CanonicalForm.Clone());

            // Demo: simulate iterations
            for (int k = 0; k < 2; k++)
            {
                var tab = (double[,])Iterations[Iterations.Count - 1].Clone();
                int rows = tab.GetLength(0);
                int cols = tab.GetLength(1);

                // Fake cutting plane adjustment: bump RHS
                tab[rows - 1, cols - 1] += (k + 1);
                Iterations.Add(tab);
            }
        }

        private double[,] BuildCanonicalForm()
        {
            int numVars = model.NumberOfVariables;
            int numConstraints = model.Constraints.Count;

            var colNames = new List<string>();
            for (int i = 0; i < numVars; i++)
                colNames.Add("x" + (i + 1));

            var rowNames = new List<string>();

            int slackIdx = numVars;
            foreach (var cons in model.Constraints)
            {
                if (cons.Type == ConstraintType.LessOrEqual)
                {
                    colNames.Add("s" + (colNames.Count - numVars + 1));
                }
                else if (cons.Type == ConstraintType.GreaterOrEqual)
                {
                    colNames.Add("e" + (colNames.Count - numVars + 1));
                    colNames.Add("a" + (colNames.Count - numVars + 1));
                }
                else if (cons.Type == ConstraintType.Equal)
                {
                    colNames.Add("a" + (colNames.Count - numVars + 1));
                }
            }

            colNames.Add("RHS");
            ColumnNames = colNames.ToArray();

            double[,] tableau = new double[numConstraints + 1, ColumnNames.Length];

            int rowIdx = 0;
            int extraVarIdx = numVars;
            foreach (var cons in model.Constraints)
            {
                rowNames.Add("C" + (rowIdx + 1));

                // Decision variable coefficients
                for (int j = 0; j < numVars; j++)
                    tableau[rowIdx, j] = cons.Coefficients[j];

                // Slack/excess/artificial variables
                if (cons.Type == ConstraintType.LessOrEqual)
                {
                    tableau[rowIdx, extraVarIdx++] = 1.0;
                }
                else if (cons.Type == ConstraintType.GreaterOrEqual)
                {
                    tableau[rowIdx, extraVarIdx++] = -1.0;
                    tableau[rowIdx, extraVarIdx++] = 1.0; // artificial
                }
                else if (cons.Type == ConstraintType.Equal)
                {
                    tableau[rowIdx, extraVarIdx++] = 1.0; // artificial
                }

                // ? RHS is a real property
                tableau[rowIdx, ColumnNames.Length - 1] = cons.RightHandSide;
                rowIdx++;
            }

            // Objective row
            rowNames.Add("Z");
            for (int j = 0; j < numVars; j++)
                tableau[numConstraints, j] = model.IsMaximization
        ? -model.ObjectiveCoefficients[j]   // max ? negative in simplex
        : model.ObjectiveCoefficients[j];
            tableau[numConstraints, ColumnNames.Length - 1] = 0;

            RowNames = rowNames.ToArray();
            return tableau;
        }
    }
}
