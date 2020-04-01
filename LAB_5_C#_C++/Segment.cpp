#include "Line.h"
#include <Math.h>
#include <iostream>
#include "Points.h"
#include "Segment.h"

Segment::Segment(double begin_x, double begin_y, double end_x, double end_y)
	: Line(begin_x, begin_y, end_x, end_y) { }

void Segment::Reduction(double number)
{
	if (number <= Length())
	{
		double current = Length() - number;
		double index = pow(current, 2) / pow(Length(), 2);

		end.x = end.x * sqrt(index);
		end.y = end.y * sqrt(index);
		begin.x = begin.x * sqrt(index);
		begin.y = begin.y * sqrt(index);
	}
	else
		std::cout << "You cannot subtract number bigger than length of segment!" << std::endl;
};

double Segment::GetX(Points point)
{
	if (point == Begin)
	{
		return begin.x;
	}
	else
	{
		return end.x;
	}
};

double Segment::GetY(Points point)
{
	if (point == Begin)
	{
		return begin.y;
	}
	else
	{
		return end.y;
	}
};