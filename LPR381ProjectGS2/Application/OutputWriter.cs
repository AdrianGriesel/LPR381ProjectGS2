using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381ProjectGS2
{
    public static class OutputWriter
    {
        public static void WriteToFile(string path, SimplexResult result)
        {
            var sb = new StringBuilder();
            // Canonical form
            sb.AppendLine("--- Canonical Form ---");
            sb.AppendLine(result.CanonicalFormText);
            sb.AppendLine();
            // Iterations
            for (int i = 0; i < result.Iterations.Count; i++)
            {
                sb.AppendLine("--- Iteration " + (i + 1) + " ---");
                DumpTableau(sb, result.Iterations[i], result.IsMaximization); 
                sb.AppendLine();
            }
            // Final result
            sb.AppendLine("--- Final Result ---");
            sb.AppendLine("Status: " + result.Status);
            sb.AppendLine("Termination Reason: " + result.TerminationReason);
            sb.AppendLine("Objective Value: " + Rounder(result.ObjectiveValue));
            if (result.Primal != null && result.Primal.Length > 0)
            {
                for (int i = 0; i < result.Primal.Length; i++)
                    sb.AppendLine($"x{i + 1} = {Rounder(result.Primal[i])}");
            }

            File.WriteAllText(path, sb.ToString());
        }

        // flips only the Z row when displaying a max problem
        private static void DumpTableau(StringBuilder sb, TableauSnapshot snap, bool isMaximization)
        {
            // header
            sb.Append('\t');
            for (int j = 0; j < snap.ColumnLabels.Length; j++)
            {
                sb.Append(snap.ColumnLabels[j]);
                if (j < snap.ColumnLabels.Length - 1) sb.Append('\t');
            }
            sb.AppendLine();

            // rows
            for (int i = 0; i < snap.RowLabels.Length; i++)
            {
                bool isZ = string.Equals(snap.RowLabels[i], "z", StringComparison.OrdinalIgnoreCase);

                sb.Append(snap.RowLabels[i]).Append('\t');

                for (int j = 0; j < snap.ColumnLabels.Length; j++)
                {
                    double val = snap.Matrix[i, j];

                    // display flip only: for max problems, z-row stores -z*, so show +z*
                    if (isMaximization && isZ) val = -val;

                    sb.Append(Rounder(val));
                    if (j < snap.ColumnLabels.Length - 1) sb.Append('\t');
                }
                sb.AppendLine();
            }
        }
        // Rounds to 3 decimal places and ensures 3 decimal digits are always shown
        private static string Rounder(double value)
            => Math.Round(value, 3).ToString("0.000", CultureInfo.InvariantCulture);
    }

}
