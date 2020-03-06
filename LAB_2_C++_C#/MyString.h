#pragma once

class MyString
{
public:
	MyString();
	MyString(char* str);
	char& operator [](int index);
	void Print();
	char* MyStr;
	int length;
};