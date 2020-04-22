#include "Expression.h"
#include <iostream>
#include <math.h>

using namespace std;

Expression::Expression(double a, double b, double c, double d)
{
	this->a = a;
	this->b = b;
	this->c = c;
	this->d = d;
}

double Expression::Calculate()
{
	if (24 + d - c < 0)
	{
		throw domain_error("Sqrt is less than 0");
	}
	if (sqrt(24 + d - c) + a / b == 0)
	{
		throw "Division by zero exception";
	}

	return (1 + a - b / 2) / (sqrt(24 + d - c) + a / b);
}

Expression* Expression::operator +(int num)
{
	return new Expression(this->a + num, this->b + num, this->c + num, this->d + num);
}

Expression* Expression::operator +(Expression exp2)
{
	return new Expression(this->a + exp2.a, this->b + exp2.b, this->c + exp2.c, this->d + exp2.d);
}

Expression* Expression::operator -(int num)
{
	return new Expression(this->a - num, this->b - num, this->c - num, this->d - num);
}

Expression* Expression::operator -(Expression exp2)
{
	return new Expression(this->a - exp2.a, this->b - exp2.b, this->c - exp2.c, this->d - exp2.d);
}