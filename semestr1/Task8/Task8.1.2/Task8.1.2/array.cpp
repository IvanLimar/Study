#include "list.h"
#include <iostream>

using namespace std;



List *createList(int length)
{
	List *list = new List[length];
	for (int i = 0; i < length; ++i)
	{
		list[i] = 0;
	}
	return list;
}

void deleteList(List *list)
{
	delete[] list;
}

void addToList(List *list, int &length, int element, int position)
{
	if (position < length)
	{
		list[position] = element;
		return;
	}
	length = position + 1;
	list[position] = element;
}

void printList(List *list, int length)
{
	cout << "Printing list:" << endl;
	for (int i = 0; i < length; ++i)
	{
		cout << list[i] << endl;
	}
}

int element(List *list, int length, int position)
{
	if (position >= length || position < 0)
	{
		return -999999;
	}
	return list[position];
}