#include "list.h"
#include <iostream>
#include "mergeSort.h"

using namespace std;

void main()
{
	cout << "Enter the length of list: ";
	int length = 0;
	cin >> length;
	List *list = createList(length);
	for (int i = 0; i < length; ++i)
	{
		cout << "Enter the number: ";
		int number = 0;
		cin >> number;
		addToList(list, length, number, i);
	}
	mergeSort(list, length);
	printList(list, length);
	deleteList(list);
}