#include <math.h>
#include "Rhombus.h"

Rhombus* Rhombus::Multiply(Rhombus rhomb, double number)
{
	Rhombus* result = new Rhombus(rhomb);

	result->A.x = result->A.x * sqrt(number);
	result->A.y = result->A.y * sqrt(number);

	result->B.x = result->B.x * sqrt(number);
	result->B.y = result->B.y * sqrt(number);

	result->C.x = result->C.x * sqrt(number);
	result->C.y = result->C.y * sqrt(number);

	result->C.x = result->C.x * sqrt(number);
	result->C.y = result->C.y * sqrt(number);

	return result;
}

Rhombus::Rhombus()
{
	A.x = -1;
	A.y = 0;

	B.x = 0;
	B.y = 1;

	C.x = 1;
	C.y = 0;

	D.x = 0;
	D.y = -1;
}

Rhombus::Rhombus(double a1, double a2, double b1, double b2, double c1, double c2, double d1, double d2)
{
	A.x = a1;
	A.y = a2;

	B.x = b1;
	B.y = b2;

	C.x = c1;
	C.y = c2;

	D.x = d1;
	D.y = d2;
}

Rhombus::Rhombus(Rhombus* other)
{
	A.x = other->A.x;
	A.y = other->A.y;

	B.x = other->B.x;
	B.y = other->B.y;

	C.x = other->C.x;
	C.y = other->C.y;

	D.x = other->D.x;
	D.y = other->D.y;
}

double Rhombus::Side()
{
	return sqrt(pow(A.x - B.x, 2) + pow(A.y - B.y, 2));
}

double Rhombus::Square()
{
	double d1 = sqrt(pow(A.x - C.x, 2) + pow(A.y - C.y, 2));
	double d2 = sqrt(pow(B.x - D.x, 2) + pow(B.y - D.y, 2));

	return d1 * d2 / 2;
}

double Rhombus::Perimetr()
{
	double perim = 0;

	perim += sqrt(pow(A.x - B.x, 2) + pow(A.y - B.y, 2));
	perim += sqrt(pow(B.x - C.x, 2) + pow(B.y - C.y, 2));
	perim += sqrt(pow(C.x - D.x, 2) + pow(C.y - D.y, 2));
	perim += sqrt(pow(D.x - A.x, 2) + pow(D.y - A.y, 2));

	return perim;
}

double Rhombus::GetX(Points point)
{
	if (point == a)
	{
		return A.x;
	}
	else if (point == b)
	{
		return B.x;
	}
	else if (point == c)
	{
		return C.x;
	}
	else if (point == d)
	{
		return D.x;
	}

	return 0;
}

double Rhombus::GetY(Points point)
{
	if (point == a)
	{
		return A.y;
	}
	else if (point == b)
	{
		return B.y;
	}
	else if (point == c)
	{
		return C.y;
	}
	else if (point == d)
	{
		return D.y;
	}

	return 0;
}

double Rhombus::Diagonal_1()
{
	return sqrt(pow(A.x - C.x, 2) + pow(A.y - C.y, 2));
}

double Rhombus::Diagonal_2()
{
		return sqrt(pow(B.x - D.x, 2) + pow(B.y - D.y, 2));
}

Rhombus* Rhombus::operator *(double number)
{
	Rhombus* temp = this->Multiply(*this, number);
	return temp;
}

Rhombus* Rhombus::operator -(Rhombus* second)
{
	Rhombus* temp = new Rhombus();
	double subtraction = this->Square() - second->Square();
	temp = *this * (subtraction / this->Square());

	return temp;
}

Rhombus* Rhombus::operator -(double second)
{
	Rhombus* temp = new Rhombus();
	double subtraction = this->Square() - second;
	temp = this->Multiply(*this, (subtraction / this->Square()));

	return temp;
};

