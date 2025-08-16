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


    }
}