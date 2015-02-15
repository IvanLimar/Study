#include <iostream>

using namespace std;

int main()
{
	cout << "enter the size of array:" << endl;
	int size;
	cin >> size;
	int *aray = new int[size];
	for (int i = 0; i < size; ++i)
	{
		cout << "enter the number: ";
		cin >> aray[i];
	}

	int numberOfZero = 0;
	for (int i = 0; i < size; ++i)
	{
		if (aray[i] == 0)
		{	
			++numberOfZero;
		}
	}

	cin.ignore;
	delete[] aray;
	cout << "Number of zero: " << numberOfZero << endl;
	return 0;
}