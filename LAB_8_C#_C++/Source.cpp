#include <iostream>
#include <vector>
#include <string>
using namespace std;

string Get(vector<string> strs);

int main()
{
	string(*GetWord)(vector<string> strs);

	GetWord = Get;

	cout << "Enter the amount of strings:";

	int n;
	cin >> n;

	cout << endl <<"Input the string: ";

	string str;
	vector<string> vec;

	int count = 0;
	while (count < n)
	{
		cin >> str;
		vec.push_back(str);
		count++;
	}

	string res = GetWord(vec);

	cout << res;

	cin >> res;
	return 0;
}

string Get(vector<string> strs)
{
	try
	{
		string result = "";

		for (int i = 0; i < (int)strs.size(); i++)
		{
			result += strs[i][i];
		}

		return result;
	}
	catch (const exception&)
	{
		return "";
	}
}