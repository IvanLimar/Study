#include <iostream>

using namespace std;

// bubbleSort
void bubbleSort(int *array, int leftBorder, int rightBorder)
{
	for (int i = leftBorder; i <= rightBorder; ++i)
	{
		for (int j = rightBorder; j > i; --j)
		{
			if (array[j] < array[j - 1])
			{
				swap(array[j], array[j - 1]);
			}
		}
	}
}

int main()
{
	cout << "Enter the size:" << endl;
	int size = 0;
	cin >> size;
	int *numbers = new int[size];
	for (int i = 0; i < size; ++i)
	{
		cout << "Entre the number: ";
		cin >> numbers[i];
	}

	bubbleSort(numbers, 0, size - 1);

	cout << "After bubble sort:" << endl;
	for (int i = 0; i < size; ++i)
	{
		cout << numbers[i] << " ";
	}
	cout << endl;

	delete[] numbers;
	return 0;
}
/*
���� 1: 
����: 0 0 0 0 0
�����: 0 0 0 0 0

���� 2:
����: 1 2 3 4 5
�����: 1 2 3 4 5

���� 3:
����: 5 4 3 2 1
�����: 1 2 3 4 5

*/