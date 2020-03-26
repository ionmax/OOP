enum Points
{
	a,
	b,
	c,
	d
};

class Rhombus{
private:
	struct Point{
	public:
		double x;
		double y;
	};
	Point A;
	Point B;
	Point C;
	Point D;
public:
	Rhombus();
	Rhombus(double a1, double a2, double b1, double b2, double c1, double c2, double d1, double d2);
	Rhombus(Rhombus* other);
	static Rhombus* Multiply(Rhombus rhomb, double number);
	double Side();
	double Square();
	double Perimetr();
	double GetX(Points point);
	double GetY(Points point);
	double Diagonal_1();
	double Diagonal_2();
	Rhombus* operator *(double number);
	Rhombus* operator -(Rhombus* second);
	Rhombus* operator -(double second);
};