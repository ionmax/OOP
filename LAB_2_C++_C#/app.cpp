#include <iostream>
#include <string>
#include <vector>
#include "MyString.h"
#include "Text.h"
using namespace std;



int main(int argc, const char* argv[])
{
	int strToDel, chars = 0;
	int amountOfStrs = 0;

	Text text;
	string inputing;

	cout << "Enter amount of strings: ";
	cin >> amountOfStrs;
	cout << endl;

	cin.clear();

	for (int i = 0; i < amountOfStrs; i++) 
	{
		cout << "Entered " << i + 1 << " string: ";
		cin >> inputing;

		char* array = new char[inputing.length()];

		for (int i = 0; i < strlen(array); i++)
			array[i] = inputing[i];

		text.AddStr(array);
		inputing.clear();
	}

	cout << endl;
	cout << "Enter strings :";
	text.Print();

	JustLines();

	cout << "First letters to upper register: ";
	text.ToUpper();
	text.Print();
	JustLines();

	cout << "The key-word is: ";
	text.TakeAKey().Print();
	JustLines();

	cout << "Input the amount of chars in string: ";
	cin >> chars;
	cout << "The amount of strings with this numb of chars is: " << text.TheLength(chars);
	JustLines();

	cout << "Enter number of string to delete: ";
	cin >> strToDel;
	text.DeleteStr(strToDel);

	cout << "After deleteting " << strToDel << " string: " ;
	text.Print();
	JustLines();

	cout << "After cleaning: " << endl;
	text.CleatText();
	text.Print();

	cin >> strToDel;
	return 0;
}

void JustLines()
{
	cout << "\n---------------------------\n";
}