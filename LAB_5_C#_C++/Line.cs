using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB5_CS
{
    class Line
    {
        protected Point begin;
        protected Point end;

        public Line(double begin_x, double begin_y, double end_x, double end_y)
        {
            this.begin.x = begin_x;
            this.begin.y = begin_y;

            this.end.x = end_x;
            this.end.y = end_y;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(end.x - begin.x, 2) + Math.Pow(end.y - begin.y, 2));
        }
    }
}
