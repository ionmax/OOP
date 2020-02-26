#include <iostream>
#include "MyLibrary.h"

using namespace std;
using namespace MySpace;

int main()
{
	int Num;
	int& ref = Num;
	cout << "Input the number for subtraction: ";
	cin >> Num;
	Subtraction(ref);
	cout << "Result of subtraction = " << Num << endl;

	int A, B;
	cout << "Input numbers for comparison" << endl;
	cout << "Number A: ";
	cin >> A;
	cout << "Numver B: ";
	cin >> B;
	bool res = Compare(A, B);

	if (res)
		cout << "   A > B" << endl;
	else
		cout << "   A !> B" << endl;

	system("pause");
	return 0;
}