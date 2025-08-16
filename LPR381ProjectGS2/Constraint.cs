using System;

public class Constraint
{
    public List<double> Coefficients { get; set; } = new List<double>();
    public ConstraintType Type { get; set; }
    public double RightHandSide { get; set; }
}
