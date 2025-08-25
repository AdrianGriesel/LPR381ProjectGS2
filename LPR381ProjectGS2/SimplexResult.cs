using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2
{
    public enum SimplexStatus
    {
        NotStarted,
        Optimal,
        Infeasible,
        Unbounded,
        Phase1Required

    }

    public sealed class SimplexResult
    {
        public SimplexStatus Status { get; set; } = SimplexStatus.NotStarted;
        public double ObjectiveValue { get; set; }
        public double[] Primal { get; set; } = new double[0];
        public List<TableauSnapshot> Iterations { get; set; } = new List<TableauSnapshot>();
        public string TerminationReason { get; set; } = string.Empty;
        public string CanonicalFormText { get; set; } = string.Empty;
        public bool IsMaximization { get; set; }
    }
}
