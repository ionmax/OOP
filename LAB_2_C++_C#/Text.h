#pragma once

class Text
{
public:
	int length;
	vector<MyString> text;
	void AddStr(MyString strToAdd);
	void DeleteStr(int strToDel);
	void CleatText();
	void ToUpper();
	MyString TakeAKey();
	int TheLength(int amount);
	MyString& operator [](int index);
	void Print(int i);
	void Print();
};