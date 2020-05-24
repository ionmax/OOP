#pragma once

class FloatList
{
private:
	float* floatlist;
	int count;
public:
	FloatList();
	void Add(float num);
	int Find(float num);
	void Remove(float num);
	int BiggerThanAverage();
	void DeleteAllNegativeNums();
	float& operator [](const int index);
	int Length();
};