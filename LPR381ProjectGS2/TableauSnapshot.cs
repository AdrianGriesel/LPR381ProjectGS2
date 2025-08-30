using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381ProjectGS2.Domain.Models
{
    public sealed class TableauSnapshot
    {


        public double[,] Matrix { get; private set; } = new double[0, 0];
        public string[] ColumnLabels { get; private set; } = new string[0];
        public string[] RowLabels { get; private set; } = new string[0];
        public int? EnteringColumn { get; private set; }
        public int? LeavingRow { get; private set; }

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
