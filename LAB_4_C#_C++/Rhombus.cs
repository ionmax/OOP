using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_4_CS
{
    public enum Points
    {
        A,
        B,
        C,
        D
    }

    class Rhombus
    {

        private Point A;
        private Point B;
        private Point C;
        private Point D;

        private struct Point
        {
            public double x;
            public double y;
        };

        public Rhombus()
        {
            A.x = -1;
            A.y = 0;

            B.x = 0;
            B.y = 1;

            C.x = 1;
            C.y = 0;

            D.x = 0;
            D.y = -1;
        }

        public Rhombus(double a1, double a2, double b1, double b2, double c1, double c2, double d1, double d2)
        {
            A.x = a1;
            A.y = a2;

            B.x = b1;
            B.y = b2;

            C.x = c1;
            C.y = c2;

            D.x = d1;
            D.y = d2;
        }

        public Rhombus(Rhombus other)
        {
            A.x = other.A.x;
            A.y = other.A.y;

            B.x = other.B.x;
            B.y = other.B.y;

            C.x = other.C.x;
            C.y = other.C.y;

            D.x = other.D.x;
            D.y = other.D.y;
        }

        public double Side
        {
            get
            {
                return Math.Sqrt(Math.Pow(A.x - B.x, 2) + Math.Pow(A.y - B.y, 2));
            }
        }

        public double Square
        {
            get
            {
                double d1 = Math.Sqrt(Math.Pow(A.x - C.x, 2) + Math.Pow(A.y - C.y, 2));
                double d2 = Math.Sqrt(Math.Pow(B.x - D.x, 2) + Math.Pow(B.y - D.y, 2));

                return d1 * d2 / 2;
            }
        }

        public double Perimetr
        {
            get
            {
                double perim = 0;

                perim += Math.Sqrt(Math.Pow(A.x - B.x, 2) + Math.Pow(A.y - B.y, 2));
                perim += Math.Sqrt(Math.Pow(B.x - C.x, 2) + Math.Pow(B.y - C.y, 2));
                perim += Math.Sqrt(Math.Pow(C.x - D.x, 2) + Math.Pow(C.y - D.y, 2));
                perim += Math.Sqrt(Math.Pow(D.x - A.x, 2) + Math.Pow(D.y - A.y, 2));

                return perim;
            }
        }

        public double GetX(Points point)
        {
            if (point == Points.A)
            {
                return A.x;
            }
            else if (point == Points.B)
            {
                return B.x;
            }
            else if (point == Points.C)
            {
                return C.x;
            }
            else if (point == Points.D)
            {
                return D.x;
            }

            return 0;
        }

        public double GetY(Points point)
        {
            if (point == Points.A)
            {
                return A.y;
            }
            else if (point == Points.B)
            {
                return B.y;
            }
            else if (point == Points.C)
            {
                return C.y;
            }
            else if (point == Points.D)
            {
                return D.y;
            }

            return 0;
        }

        public double Diagonal_1
        {
            get
            {
                return Math.Sqrt(Math.Pow(A.x - C.x, 2) + Math.Pow(A.y - C.y, 2));
            }
        }

        public double Diagonal_2
        {
            get
            {
                return Math.Sqrt(Math.Pow(B.x - D.x, 2) + Math.Pow(B.y - D.y, 2));
            }
        }

        private static Rhombus Multiply(Rhombus rhomb, double number)
        {
            Rhombus result = new Rhombus(rhomb);

            result.A.x = result.A.x * Math.Sqrt(number);
            result.A.y = result.A.y * Math.Sqrt(number);

            result.B.x = result.B.x * Math.Sqrt(number);
            result.B.y = result.B.y * Math.Sqrt(number);

            result.C.x = result.C.x * Math.Sqrt(number);
            result.C.y = result.C.y * Math.Sqrt(number);

            result.C.x = result.C.x * Math.Sqrt(number);
            result.C.y = result.C.y * Math.Sqrt(number);

            return result;
        }

        public static Rhombus operator *(Rhombus rhomb, double number)
        {
            Rhombus temp = Rhombus.Multiply(rhomb, number);
            return temp;
        }

        public static Rhombus operator *(double number, Rhombus rhomb)
        {
            Rhombus temp = Rhombus.Multiply(rhomb, number);
            return temp;
        }

        public static Rhombus operator -(Rhombus first, Rhombus second)
        {
            Rhombus temp = new Rhombus();
            double subtraction = first.Square - second.Square;
            temp = first * (subtraction / first.Square);

            return temp;
        }

        public static Rhombus operator -(Rhombus first, double second)
        {
            Rhombus temp = new Rhombus();
            double subtraction = first.Square - second;
            temp = first * (subtraction / first.Square);

            return temp;
        }

    }
}
