using LPR381ProjectGS2.Domain.Analysis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LPR381ProjectGS2.Application
{
    internal class SensitivityWriter
    {
        // writes a simple text sensitivity report

        public static void Write(string path, SensitivityReport r)
        {
            var sb = new StringBuilder();
      
            sb.AppendLine("--- sensitivity report ---");
            sb.AppendLine($"primal objective (z*): {Fmt(r.PrimalObjective)}");
            if (r.DualObjective.HasValue)
                sb.AppendLine($"dual objective (w*): {Fmt(r.DualObjective.Value)}");
            sb.AppendLine($"weak duality: {(r.WeakDualityHolds ? "holds" : "fails")}");
            sb.AppendLine($"strong duality: {(r.StrongDualityHolds ? "holds" : "not verified")}");
            if (!string.IsNullOrWhiteSpace(r.Notes)) sb.AppendLine($"notes: {r.Notes}");
            sb.AppendLine();
            
            sb.AppendLine("shadow prices (y):");
            sb.AppendLine("constraint\tvalue");
            foreach (var kv in r.ShadowPrices)
                sb.AppendLine($"{kv.Key}\t{Fmt(kv.Value)}");
            sb.AppendLine();

            sb.AppendLine("reduced costs:");
            sb.AppendLine("variable\treduced cost\tbasic?");
            foreach (var kv in r.ReducedCosts)
                sb.AppendLine($"{kv.Key}\t{Fmt(kv.Value.value)}\t{(kv.Value.isBasic ? "yes" : "no")}");
            sb.AppendLine();

            if (r.ObjectiveCoeffRanges.Any())
            {
                sb.AppendLine("objective coefficient ranges:");
                sb.AppendLine("variable\tallowable decrease\tallowable increase");
                foreach (var kv in r.ObjectiveCoeffRanges)
                    sb.AppendLine($"{kv.Key}\t{Fmt(kv.Value.down)}\t{Fmt(kv.Value.up)}");
                sb.AppendLine();
            }

            if (r.RhsRanges.Any())
            {
                sb.AppendLine("rhs ranges:");
                sb.AppendLine("constraint\tallowable decrease\tallowable increase");
                foreach (var kv in r.RhsRanges)
                    sb.AppendLine($"{kv.Key}\t{Fmt(kv.Value.down)}\t{Fmt(kv.Value.up)}");
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString());
        }

        private static string Fmt(double v) =>
            v.ToString("0.000", CultureInfo.InvariantCulture);

        private static string Fmt(double? v) =>
            v.HasValue ? v.Value.ToString("0.000", CultureInfo.InvariantCulture) : "-";
    }
}

