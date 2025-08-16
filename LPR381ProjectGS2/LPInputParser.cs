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
        }


    }
}