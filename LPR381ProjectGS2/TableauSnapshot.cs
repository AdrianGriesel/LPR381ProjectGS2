using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381ProjectGS2.Domain.Models
{
    public sealed class TableauSnapshot
    {

            public double[,] Matrix { get; set; }
            public string[] RowLabels { get; set; }
            public string[] ColumnLabels { get; set; }

            // Add this
            public List<string> VariableNames { get; set; } = new List<string>();

            public int IterationNumber { get; set; }
            public int? EnteringColumn { get; set; }
            public int? LeavingRow { get; set; }
        


        public static TableauSnapshot From(
            double[,] Matrix,
            string[] ColumnLabels,
            string[] RowLabels,
            int? EnteringColumn = null,
            int? LeavingRow = null)
        {
            // defensive copies so later mutations dont affect stored snapshots
            var matrixDef = (double[,])Matrix.Clone();
            var ColsDef = (string[])ColumnLabels.Clone();
            var rowsDef = (string[])RowLabels.Clone();

            return new TableauSnapshot
            {
                Matrix = matrixDef,
                ColumnLabels = ColsDef,
                RowLabels = rowsDef,
                EnteringColumn = EnteringColumn,
                LeavingRow = LeavingRow
            };
        }

    }
}
