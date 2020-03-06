#include <iostream>
#include <string>
#include "MyString.h"

using namespace std;

class MyString
{
public:

	MyString()
	{
		MyStr = new char[0];
		length = 0;
	}

	MyString(char* str)
	{
		MyStr = str;
		length = strlen(str);
	}

	//For calling operator "[]"
	char& operator [](int index)
	{
		return MyStr[index];
	}

	//Printing the string
	void Print()
	{
		for (int j = 0; j < length; j++)
		{
			cout << MyStr[j];
		}
	}
public:

	char* MyStr;
	int length;
};

