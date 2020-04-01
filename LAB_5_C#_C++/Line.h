#pragma once

struct Point {
public:
	double x;
	double y;
};

class Line{
protected:
	Point begin;
	Point end;
public:
	Line(double begin_x, double begin_y, double end_x, double end_y);
	double Length();
};