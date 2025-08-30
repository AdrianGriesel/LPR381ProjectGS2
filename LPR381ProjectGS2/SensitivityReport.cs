using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381ProjectGS2.Domain.Analysis
{
    public class SensitivityReport
    {
        public double PrimalObjective { get; set; }
        public double? DualObjective { get; set; }

        public Dictionary<string, double> ShadowPrices { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, (double value, bool isBasic)> ReducedCosts { get; set; } = new Dictionary<string, (double value, bool isBasic)>();

        public Dictionary<string, (double? down, double? up)> ObjectiveCoeffRanges { get; set; } = new Dictionary<string, (double? down, double? up)>();
        public Dictionary<string, (double? down, double? up)> RhsRanges { get; set; } = new Dictionary<string, (double? down, double? up)>();

        public bool WeakDualityHolds { get; set; }
        public bool StrongDualityHolds { get; set; }

        public string Notes { get; set; } = "";

        public SensitivityRange GetVariableRange(string varName)
        {
            if (!_variableValues.ContainsKey(varName)) return new SensitivityRange { Min = 0, Max = 0 };
            double val = _variableValues[varName];
            double perturb = Math.Abs(val) * 0.1;
            return new SensitivityRange { Min = val - perturb, Max = val + perturb };
        }

        public SensitivityRange GetRhsRange(string constraintName)
        {
            if (!_rhsValues.ContainsKey(constraintName)) return new SensitivityRange { Min = 0, Max = 0 };
            double val = _rhsValues[constraintName];
            double perturb = Math.Abs(val) * 0.1;
            return new SensitivityRange { Min = val - perturb, Max = val + perturb };
        }


    }

}
