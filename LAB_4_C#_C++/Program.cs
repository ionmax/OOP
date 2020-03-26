using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_4_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Rhombus P1 = new Rhombus();
            Rhombus P2 = new Rhombus(-5, 0, 0, 4, 5, 0, 0, -4);
            Rhombus P3 = new Rhombus(2*P2);

            Console.WriteLine($"Coords of P1 rhombus: \n" +
                $"Point A:({P1.GetX(Points.A)}, {P1.GetY(Points.A)}) " +
                $"Point B:({P1.GetX(Points.B)}, {P1.GetY(Points.B)}) " +
                $"Point C:({P1.GetX(Points.C)}, {P1.GetY(Points.C)}) " +
                $"Point D:({P1.GetX(Points.D)}, {P1.GetY(Points.D)})\n");
            Console.WriteLine($"Side length of P2 rhombus: {P2.Side.ToString("0.000")}");
            Console.WriteLine($"Diagonals length of P3 rhombus: {P3.Diagonal_1.ToString("0.000")}; {P3.Diagonal_2.ToString("0.000")}\n");
            Console.WriteLine($"Square of P1 rhombus: {P1.Square}");
            Console.WriteLine($"Square of P2 rhombus: {P2.Square}");
            Console.WriteLine($"Square of P3 rhombus: {P3.Square.ToString("0.")}");
            Console.WriteLine($"Perimetr of P2 rhombus: {P2.Perimetr.ToString("0.00")}\n");

            P1 = P3 - P2;
            Console.WriteLine($"Square P1 after subtraction P3-P2: {P1.Square.ToString("0.")}");
            P1 = P1 - 20;
            Console.WriteLine($"Square P1 after subtraction P1-20: {P1.Square.ToString("0.")}");

            Console.ReadKey();
        }
    }
}
