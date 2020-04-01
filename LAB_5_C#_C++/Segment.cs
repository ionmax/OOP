using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB5_CS
{
    public enum Points
    {
        begin,
        end
    }
    class Segment : Line
    {
        public Segment(double begin_x, double begin_y, double end_x, double end_y)
            : base(begin_x, begin_y, end_x, end_y) { }

        public void Reduction(double number)
        {
            if(number <= Length())
            {
                double current = Length() - number;
                double index = Math.Pow(current, 2) / Math.Pow(Length(), 2);

                end.x = end.x * Math.Sqrt(index);
                end.y = end.y * Math.Sqrt(index);
                begin.x = begin.x * Math.Sqrt(index);
                begin.y = begin.y * Math.Sqrt(index);
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public double GetX(Points point)
        {
            if(point == Points.begin)
            {
                return begin.x;
            }
            else
            {
                return end.x;
            }
        }

        public double GetY(Points point)
        {
            if (point == Points.begin)
            {
                return begin.y;
            }
            else
            {
                return end.y;
            }
        }
    }
}
