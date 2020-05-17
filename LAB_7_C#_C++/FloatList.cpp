#include "FloatList.h"
#include <algorithm>

float& FloatList::operator [] (const int index)
{
	return floatlist[index];
}

int FloatList::Length()
{
	return count;
}

FloatList::FloatList()
{
	count = 0;
}

void FloatList::Add(float num)
{
    float* newList = new float[count + 1];

    count++;
    newList[0] = num;
            
    for(int i = 1; i < count; i++)
    {
        newList[i] = floatlist[i - 1];
    }

    floatlist = newList;
}

int FloatList::Find(float num)
{
    for (int i = 0; i < count; i++)
        if (num == floatlist[i])
            return i;
    return -1;
}

void FloatList::Remove(float num)
{
    int index = Find(num);

    if (index == -1)
        return;

    float* newList = new float[--count];

    for (int i = 0; i < index; i++)
        newList[i] = floatlist[i];

    for (int i = index; i < count; i++)
        newList[i] = floatlist[i + 1];

    floatlist = newList;
}

int FloatList::BiggerThanAverage()
{
    if (count < 2)
        return 0;

    int amount = 0;
    float average;
    float* list = new float[count];

	for (int i = 0; i < count; i++)
		list[i] = floatlist[i];

	int n = sizeof(list) / sizeof(list[0]);

	std::sort(list, list + n);

    average = list[count / 2];

	for(int i = 0; i < count; i++)
		if (list[i] > average)
			amount++;

    return amount;
}

void FloatList::DeleteAllNegativeNums()
{
    for(int i = 0; i < count; i++)
    {
        if (floatlist[i] < 0)
        {
            Remove(floatlist[i]);
            i--;
        }
    }
}