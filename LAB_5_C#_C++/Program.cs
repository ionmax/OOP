using System;

namespace OOP_LAB5_CS
{
    public struct Point
    {
        public double x;
        public double y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Segment mySegment = new Segment(4, 5, 12, 15);

            Console.WriteLine($"Begin:({mySegment.GetX(Points.begin)},{mySegment.GetY(Points.begin)})" +
                $"End:({mySegment.GetX(Points.end)},{mySegment.GetY(Points.end)})");
            Console.WriteLine(mySegment.Length().ToString("0.000"));

            mySegment.Reduction(5);

            Console.WriteLine(
                $"Begin:({mySegment.GetX(Points.begin).ToString("0.000")}," +
                $"{mySegment.GetY(Points.begin).ToString("0.000")})" +
                $"End:({mySegment.GetX(Points.end).ToString("0.000")}" +
                $",{mySegment.GetY(Points.end).ToString("0.000")})");
            Console.WriteLine(mySegment.Length().ToString("0.000"));

            Console.ReadKey();
        }
    }
}
