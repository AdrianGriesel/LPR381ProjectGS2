using System;
using System.Collections.Generic;
using System.IO;

namespace LinearProgrammingSolver
{
    public class LPInputParser
    {
        // Constraint types for LP model
        public enum ConstraintType
        {
            LessOrEqual,    // <=
            GreaterOrEqual, // >=
            Equal           // =
        }

        // Variable types / sign restrictions
        public enum VariableType
        {
            Positive,       // +
            Negative,       // -
            Unrestricted,   // urs
            Integer,        // int
            Binary          // bin
        }

        // LP model class
        public class LPModel
        {
            public bool IsMaximization { get; set; }  // true if maximization problem
            public List<double> ObjectiveCoefficients { get; set; } = new List<double>();
            public List<Constraint> Constraints { get; set; } = new List<Constraint>();
            public List<VariableType> SignRestrictions { get; set; } = new List<VariableType>();
            public int NumberOfVariables { get; set; }
        }

        // Constraint class
        public class Constraint
        {
            public List<double> Coefficients { get; set; } = new List<double>();
            public ConstraintType Type { get; set; }
            public double RightHandSide { get; set; }
        }

        // Main parser method
        public static LPModel ParseInputFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Input file not found: {filePath}");

            string[] lines = File.ReadAllLines(filePath);

            // Minimum requirement: objective + at least one constraint
            if (lines.Length < 2)
                throw new ArgumentException("Input file must contain at least objective function and one constraint");

            var model = new LPModel();

            try
            {
                // Parse first line as objective function
                ParseObjectiveFunction(lines[0], model);

                // Parse middle lines (all except first and last)
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                        model.Constraints.Add(ParseConstraint(lines[i], model.NumberOfVariables));
                }

                // Handle last line: either constraint or sign restrictions
                string lastLine = lines[lines.Length - 1].Trim();
                if (lastLine.Length == 0 || IsSignRestrictionLine(lastLine))
                {
                    // Last line is sign restrictions (or empty)
                    ParseSignRestrictions(lastLine, model);
                }
                else
                {
                    // Last line is a constraint
                    model.Constraints.Add(ParseConstraint(lastLine, model.NumberOfVariables));

                    // No sign restrictions provided -> default to positive else errorss
                    for (int i = 0; i < model.NumberOfVariables; i++)
                        model.SignRestrictions.Add(VariableType.Positive);
                }

                return model;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error parsing input file: {ex.Message}", ex);
            }
        }

        // Parse objective function (first line)
        private static void ParseObjectiveFunction(string line, LPModel model)
        {
            // Split by spaces or tabs
            var vars = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (vars.Length < 2)
                throw new ArgumentException("Invalid objective function format.");

            // Problem type: max or min
            string problemType = vars[0].ToLower();
            if (problemType == "max") model.IsMaximization = true;
            else if (problemType == "min") model.IsMaximization = false;
            else throw new ArgumentException($"Invalid problem type: {problemType}");

            // Parse coefficients: supports +3, -2, etc.
            for (int i = 1; i < vars.Length; i++)
            {
                double coeff;

                // Try parsing with leading sign
                if (!double.TryParse(vars[i], System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint, null, out coeff))
                    throw new ArgumentException($"Invalid coefficient: {vars[i]}");

                model.ObjectiveCoefficients.Add(coeff);
            }

            model.NumberOfVariables = model.ObjectiveCoefficients.Count;
            if (model.NumberOfVariables == 0)
                throw new ArgumentException("No variables found in objective function");
        }

        // Parse a single constraint line
        private static Constraint ParseConstraint(string line, int expectedVariables)
        {
            // Split by spaces or tabs
            var vars = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            
            if (vars.Length != expectedVariables + 2)
                throw new ArgumentException($"Invalid constraint format: {line}");

            var constraint = new Constraint();

            // Parse coficients
            for (int i = 0; i < expectedVariables; i++)
            {
                double coeff;

                if (!double.TryParse(vars[i], System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint, null, out coeff))
                    throw new ArgumentException($"Invalid coefficient in constraint: {vars[i]}");

                constraint.Coefficients.Add(coeff);
            }

            // Parse relation symbol
            string relation = vars[expectedVariables];
            if (relation == "<=") constraint.Type = ConstraintType.LessOrEqual;
            else if (relation == ">=") constraint.Type = ConstraintType.GreaterOrEqual;
            else if (relation == "=") constraint.Type = ConstraintType.Equal;
            else throw new ArgumentException($"Invalid constraint relation: {relation}");

            // Parse RHS value
            double rhs;
            if (!double.TryParse(vars[expectedVariables + 1], System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint, null, out rhs))
                throw new ArgumentException($"Invalid RHS value: {vars[expectedVariables + 1]}");

            constraint.RightHandSide = rhs;

            return constraint;
        }

        // Parse sign restrictions (last line)
        private static void ParseSignRestrictions(string line, LPModel model)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                // Default all variables to positive if no line provided
                for (int i = 0; i < model.NumberOfVariables; i++)
                    model.SignRestrictions.Add(VariableType.Positive);
                return;
            }

            var vars = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (vars.Length != model.NumberOfVariables)
                throw new ArgumentException($"Sign restrictions count ({vars.Length}) doesn't match number of variables ({model.NumberOfVariables})");

            foreach (string var in vars)
            {
                string t = var.ToLower();
                if (t == "+") model.SignRestrictions.Add(VariableType.Positive);
                else if (t == "-") model.SignRestrictions.Add(VariableType.Negative);
                else if (t == "urs") model.SignRestrictions.Add(VariableType.Unrestricted);
                else if (t == "int") model.SignRestrictions.Add(VariableType.Integer);
                else if (t == "bin") model.SignRestrictions.Add(VariableType.Binary);
                else throw new ArgumentException($"Invalid sign restriction: {var}");
            }
        }

    
        private static bool IsSignRestrictionLine(string line)
        {
            var vars = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string var in vars)
            {
                string t = var.ToLower();
                // If any vars is a number or relation its not a sign restriction
                if (t != "+" && t != "-" && t != "urs" && t != "int" && t != "bin")
                    return false;
            }
            return true;
        }
    }
}
