using System;

namespace OOP_LAB_6
{
    class Expression
    {
        // Properties
        #region
        public double A { set; get; }
        public double B { set; get; }
        public double C { set; get; }
        public double D { set; get; }
        #endregion
        public Expression(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public double Calculate()
        {
            if (24 + D - C < 0)
            {
                throw new InvalidOperationException();
            }
            if (Math.Sqrt(24 + D - C) + A/B == 0)
            {
                throw new DivideByZeroException();
            }

            return (1 + A - B / 2) / (Math.Sqrt(24 + D - C) + A / B);
        }

        public static Expression operator +(Expression exp, int num) => 
            new Expression(exp.A + num, exp.B + num, exp.C + num, exp.D + num);

        public static Expression operator +(Expression exp1, Expression exp2) => 
            new Expression(exp1.A + exp2.A, exp1.B + exp2.B, exp1.C + exp2.C, exp1.D + exp2.D);

        public static Expression operator -(Expression exp, int num) =>
            new Expression(exp.A - num, exp.B - num, exp.C - num, exp.D - num);

        public static Expression operator -(Expression exp1, Expression exp2) =>
            new Expression(exp1.A - exp2.A, exp1.B - exp2.B, exp1.C - exp2.C, exp1.D - exp2.D);

    }
}
