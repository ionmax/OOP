#include <Math.h>
#include "Points.h"
#include "Line.h"

Line::Line(double begin_x, double begin_y, double end_x, double end_y)
{
	begin.x = begin_x;
	begin.y = begin_y;

	end.x = end_x;
	end.y = end_y;
};

double Line::Length()
{
	return sqrt(pow(end.x - begin.x, 2) + pow(end.y - begin.y, 2));
};