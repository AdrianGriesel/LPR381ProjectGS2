using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinearProgrammingSolver
{
    public class LPInputParser
    {
        public enum ConstraintType
        {
            LessOrEqual,    // <=
            GreaterOrEqual, // >=
            Equal           // =
        }
        public enum VariableType
        {
            Positive,   // +
            Negative,   // -
            Unrestricted, // urs
            Integer,    // int
            Binary      // bin
        }
        public class LPModel
        {
            public bool IsMaximization { get; set; }
            public List<double> ObjectiveCoefficients { get; set; } = new List<double>();
            public List<Constraint> Constraints { get; set; } = new List<Constraint>();
            public List<VariableType> SignRestrictions { get; set; } = new List<VariableType>();
            public int NumberOfVariables { get; set; }
        }

        public class Constraint
        {
            public List<double> Coefficients { get; set; } = new List<double>();
            public ConstraintType Type { get; set; }
            public double RightHandSide { get; set; }
        }


        public static LPModel ParseInputFile(string filePath)
        {
            if (!File.Exists(filePath))//check if file does not exists then ,then give exception
                throw new FileNotFoundException($"Input file not found: {filePath}");
            string[] lines = File.ReadAllLines(filePath);//reads all line int an array
            if (lines.Length < 2)//to small give error
                throw new ArgumentException("Input file must contain at least objective function and sign restrictions");

            var model = new LPModel();//creates a model
            try
            {
                // Parse objective function (first line)
                ParseObjectiveFunction(lines[0], model);

                // Parse constraints (all lines except first and last)
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                    {
                        var constraint = ParseConstraint(lines[i], model.NumberOfVariables);
                        model.Constraints.Add(constraint);
                    }
                }

                // Parse sign restrictions (last line)
                ParseSignRestrictions(lines[lines.Length - 1], model);

                return model;
            }
            catch (Exception ex)//error handling
            {
                throw new ArgumentException($"Error parsing input file: {ex.Message}", ex);
            }
        }
        private static void ParseObjectiveFunction(string line, LPModel model)
        {
            var vars = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);//spilits the values

            if (vars.Length < 3 || vars.Length % 2 == 0)
                throw new ArgumentException("Invalid objective function format. Expected: max/min +/- number +/- number ...");

            // Parse max/min
            string problemType = vars[0].ToLower();
            if (problemType == "max")
                model.IsMaximization = true;
            else if (problemType == "min")
                model.IsMaximization = false;
            else
                throw new ArgumentException($"Invalid problem type: {problemType}. Must be 'max' or 'min'");

            // Parse operator-coefficient pairs
            for (int i = 1; i < vars.Length; i += 2)
            {
                if (i + 1 >= vars.Length)
                    throw new ArgumentException("Missing coefficient after operator");

                string operatorVar = vars[i];
                string numberVar = vars[i + 1];

                // Validate operator
                if (operatorVar != "+" && operatorVar != "-")
                    throw new ArgumentException($"Invalid operator: {operatorVar}. Must be '+' or '-'");

                // Parse coefficient
                if (double.TryParse(numberVar, out double coefficient))
                {
                    // Apply sign from operator
                    if (operatorVar == "-")
                        coefficient = -coefficient;

                    model.ObjectiveCoefficients.Add(coefficient);
                }
                else
                {
                    throw new ArgumentException($"Invalid coefficient: {numberVar}");
                }
            }

            model.NumberOfVariables = model.ObjectiveCoefficients.Count;

            if (model.NumberOfVariables == 0)
                throw new ArgumentException("No variables found in objective function");
        }

    }
}