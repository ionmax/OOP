#pragma once
#include "Line.h"
#include "Points.h"

class Segment : public Line{
public:
	Segment(double begin_x, double begin_y, double end_x, double end_y);
	void Reduction(double number);
	double GetX(Points point);
	double GetY(Points point);
};