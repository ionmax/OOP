#include <iostream>
#include "Expression.h"
#include <fstream>

using namespace std;


void Log(string* message)
{
	ofstream f;
	f.open("log.txt");
	if (f.is_open())
	{
		f << message;
	}
	f.close();
}

void Main()
{
	try
	{
		Expression* exp1 = new Expression(0, 2, 25, 0);
		//Expression* exp1 = new Expression(0, 2, 24, 0);
		//exp1 = exp1 + 5;
		//exp1 = exp1 + new Expression(1,2,3,4);
		//exp1 += 5;
		//exp1 = exp1 - 5;
		//exp1 -= new Expression(1, 1, 1, 1);

		cout << exp1->Calculate();
	}
	catch (const char* ex)
	{
		string* logText = new string(ex);
		Log(logText);
	}
	catch (domain_error ex)
	{
		string* logText = new string(ex.what());
		Log(logText);
	}
	catch (exception ex)
	{
		string* logText = new string(ex.what());
		Log(logText);
	}
	cout << "The end" << endl;

	char i;
	cin >> i;
}


