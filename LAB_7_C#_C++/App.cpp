#include <iostream>
#include "FloatList.h"

using namespace std;

void main()
{
	FloatList* list = new FloatList();

	list->Add(-5);
	list->Add(-4);
	list->Add(-3);
	list->Add(-2);
	list->Add(-1);
	list->Add(-0);
	list->Add(1);
	list->Add(2);
	list->Add(3);

	for (int i = 0; i < list->Length(); i++)
		cout << (*list)[i] << " ";

	cout << endl << list->BiggerThanAverage() << endl;
	list->DeleteAllNegativeNums();

	for (int i = 0; i < list->Length(); i++)
		cout << (*list)[i] << " ";

	char i;
	cin >> i;
}