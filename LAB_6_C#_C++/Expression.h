#pragma once


class Expression
{
public:
	double a;
	double b;
	double c;
	double d;

	Expression(double a, double b, double c, double d);

	double Calculate();

	Expression* operator +(int num);

	Expression* operator +(Expression exp2);

	Expression* operator -(int num);

	Expression* operator -(Expression exp2);

};

