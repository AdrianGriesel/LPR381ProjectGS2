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
        private static Constraint ParseConstraint(string line, int expectedVariables)
        {
            var vars = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Expected format: +/- number +/- number ... <= >= = RHS
            // So we need: (expectedVariables * 2) + relation + RHS = (expectedVariables * 2) + 2 vars
            int expectedvars = (expectedVariables * 2) + 2;
            if (vars.Length != expectedvars)
                throw new ArgumentException($"Invalid constraint format. Expected {expectedvars} vars, got {vars.Length}: {line}");

            var constraint = new Constraint();

            // Parse operator-coefficient pairs
            for (int i = 0; i < expectedVariables * 2; i += 2)
            {
                string operatorVar = vars[i];
                string numberVar = vars[i + 1];

                // Validate operator
                if (operatorVar != "+" && operatorVar != "-")
                    throw new ArgumentException($"Invalid operator in constraint: {operatorVar}. Must be '+' or '-'");

                // Parse coefficient
                if (double.TryParse(numberVar, out double coefficient))
                {
                    // Apply sign from operator
                    if (operatorVar == "-")
                        coefficient = -coefficient;

                    constraint.Coefficients.Add(coefficient);
                }
                else
                {
                    throw new ArgumentException($"Invalid constraint coefficient: {numberVar}");
                }
            }

            // Parse constraint type (at position expectedVariables * 2)
            string relationToken = vars[expectedVariables * 2];
            switch (relationToken)
            {
                case "<=":
                    constraint.Type = ConstraintType.LessOrEqual;
                    break;
                case ">=":
                    constraint.Type = ConstraintType.GreaterOrEqual;
                    break;
                case "=":
                    constraint.Type = ConstraintType.Equal;
                    break;
                default:
                    throw new ArgumentException($"Invalid constraint relation: {relationToken}");
            } // Parse RHS (at position expectedVariables * 2 + 1)
            if (double.TryParse(tokens[expectedVariables * 2 + 1], out double rhs))
            {
                constraint.RightHandSide = rhs;
            }
            else
            {
                throw new ArgumentException($"Invalid right-hand side value: {tokens[expectedVariables * 2 + 1]}");
            }

            return constraint;
        }
        private static void ParseSignRestrictions(string line, LPModel model)
        {
            var tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length != model.NumberOfVariables)
                throw new ArgumentException($"Number of sign restrictions ({tokens.Length}) must match number of variables ({model.NumberOfVariables})");

            foreach (string token in tokens)
            {
                switch (token.ToLower())
                {
                    case "+":
                        model.SignRestrictions.Add(VariableType.Positive);
                        break;
                    case "-":
                        model.SignRestrictions.Add(VariableType.Negative);
                        break;
                    case "urs":
                        model.SignRestrictions.Add(VariableType.Unrestricted);
                        break;
                    case "int":
                        model.SignRestrictions.Add(VariableType.Integer);
                        break;
                    case "bin":
                        model.SignRestrictions.Add(VariableType.Binary);
                        break;
                    default:
                        throw new ArgumentException($"Invalid sign restriction: {token}");
                }
            }
        }
        // Utility method to display parsed model (for testing/debugging)
        public static void DisplayModel(LPModel model)
        {
            Console.WriteLine($"Problem Type: {(model.IsMaximization ? "Maximize" : "Minimize")}");

            Console.Write("Objective Function: ");
            for (int i = 0; i < model.ObjectiveCoefficients.Count; i++)
            {
                Console.Write($"{model.ObjectiveCoefficients[i]:+0.###;-0.###}x{i + 1}");
                if (i < model.ObjectiveCoefficients.Count - 1)
                    Console.Write(" ");
            }
            Console.WriteLine();

            Console.WriteLine("Constraints:");
            for (int i = 0; i < model.Constraints.Count; i++)
            {
                var constraint = model.Constraints[i];
                Console.Write($"  ");
                for (int j = 0; j < constraint.Coefficients.Count; j++)
                {
                    Console.Write($"{constraint.Coefficients[j]:+0.###;-0.###}x{j + 1}");
                    if (j < constraint.Coefficients.Count - 1)
                        Console.Write(" ");
                }

                string relationSymbol = constraint.Type switch
                {
                    ConstraintType.LessOrEqual => "<=",
                    ConstraintType.GreaterOrEqual => ">=",
                    ConstraintType.Equal => "=",
                    _ => "?"
                };

                Console.WriteLine($" {relationSymbol} {constraint.RightHandSide}");
            }

            Console.WriteLine("Sign Restrictions:");
            for (int i = 0; i < model.SignRestrictions.Count; i++)
            {
                string restriction = model.SignRestrictions[i] switch
                {
                    VariableType.Positive => "+",
                    VariableType.Negative => "-",
                    VariableType.Unrestricted => "urs",
                    VariableType.Integer => "int",
                    VariableType.Binary => "bin",
                    _ => "?"
                };
                Console.Write($"x{i + 1}: {restriction}  ");
            }
            Console.WriteLine();
        }
    }