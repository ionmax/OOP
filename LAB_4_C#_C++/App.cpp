#include <iostream>
#include "Rhombus.h"

using namespace std;

int main()
{
	Rhombus* P1 = new Rhombus();
	Rhombus* P2 = new Rhombus(-5, 0, 0, 4, 5, 0, 0, -4);
	Rhombus* P3 = new Rhombus((*P2 * 2.));

	cout << "Coords of P1 rhombus: \n" <<
		"Point A: (" << P1->GetX(a) << ";" << P1->GetY(a) << ") " <<
		"Point B: (" << P1->GetX(b) << ";" << P1->GetY(b) << ") " <<
		"Point C: (" << P1->GetX(c) << ";" << P1->GetY(c) << ") " <<
		"Point D: (" << P1->GetX(d) << ";" << P1->GetY(d) << ") " << endl << endl;
	cout << "Side length of P2 rhombus: " << P2->Side() << endl;
	cout << "Diagonals length of P3 rhombus: " << P3->Diagonal_1() << "; " << P3->Diagonal_2() << endl << endl;
	cout << "Square of P1 rhombus: " << P1->Square() << endl;
	cout << "Square of P2 rhombus: " << P2->Square() << endl;
	cout << "Square of P3 rhombus: " << P3->Square() << endl;
	cout << "Perimetr of P2 rhombus: " << P2->Perimetr() << endl << endl;

	P1 = *P3 - P2;
	cout << "Square P1 after subtraction P3-P2: " << P1->Square() << endl;

	char n;
	cin >> n;
	return 0;
}
