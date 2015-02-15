#include "ATD.h"
#include <iostream>

using namespace std;

void main()
{
	
	cout << "Enter the length of list:" << endl;
	int length = 0;
	cin >> length;
	Type *list = create(length);
	for (int i = 0; i < length; ++i)
	{
		cout << "Enter the number:" << endl;
		int number = 0;
		cin >> number;
		add(list, i, number);
	}
	megreSort(list, length);
	cout << endl;
	writing(list, length);
	deleting(list);
}