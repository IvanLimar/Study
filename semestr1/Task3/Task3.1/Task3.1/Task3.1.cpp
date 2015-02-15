#include <iostream>
#include <stdlib.h>
#include <ctime>

using namespace std;

// ����� �� ������� ������� "array" ������ "length" 
void printArray(int* array, int length)
{
	for (int i = 0; i < length; ++i)
	{
		cout << array[i] << " ";
	}
	cout << endl;
}

// ���������� ������� ������� "array" � ��������� "leftBorder" � "rightBorder"
void insertionSort(int* array, int leftBorder, int rightBorder)
{
	for (int i = leftBorder; i <= rightBorder; ++i)
	{
		for (int j = i; j > leftBorder; --j)
		{
			if (array[j] < array[j - 1])
			{
				swap(array[j], array[j - 1]);
			}
		}
	}
}

/* ����� � ������� "array" � ��������� "leftBorder" � "rightBorder" �����,
�������� �������, � ������������ ����� ����� � ������ */
void searhTheNumberBiggerThanFirst(int* array, int leftBorder, int rightBorder)
{
	for (int i = leftBorder + 1; i <= rightBorder; ++i)
	{
		if (array[i] > array[leftBorder])
		{
			swap(array[i], array[leftBorder]);
			break;
		}
	}
}

/* ��������, �� ������������� �������, ����� ����� �� ����. ������ - �������������.
������� ������ ����� ������ ����� ����� */
int movement(int* array, int leftBorder, int rightBorder)
{
	int firstNumberIndex = leftBorder;
	int rightIndex = rightBorder;
	int leftIndex = leftBorder;
	bool const areIndexesLegal = (leftIndex <= rightBorder) && (rightIndex >= leftBorder);

	while (leftIndex <= rightIndex && areIndexesLegal)
	{
		while (array[firstNumberIndex] < array[rightIndex] && areIndexesLegal)
		{
			--rightIndex;
		}
		if (areIndexesLegal && leftIndex <= rightIndex)
		{
			swap(array[firstNumberIndex], array[rightIndex]);
			firstNumberIndex = rightIndex;
		}

		while (areIndexesLegal && array[firstNumberIndex] >= array[leftIndex])
		{
			++leftIndex;
		}
		if (areIndexesLegal && leftIndex <= rightIndex)
		{
			swap(array[firstNumberIndex], array[leftIndex]);
			firstNumberIndex = leftIndex;
		}

	}
	return firstNumberIndex;
}

// ������� ���������� true, ���� ������ � ������� ��������� ������������, � ��������� ����� - false.
bool isArraySorted(int* array, int leftBorder, int rightBorder)
{
	bool result = true;
	for (int i = leftBorder; i < rightBorder; ++i)
	{
		if (array[i] <= array[i + 1])
		{
			result = true;
		}
		else
		{
			result = false;
			break;
		}
	}
	return result;
}

// ������� ����������
void quickSort(int* array, int leftBorder, int rightBorder)
{
	if (isArraySorted(array, leftBorder, rightBorder))
	{
		return;
	}
	if (rightBorder - leftBorder + 1 <= 10)
	{
		insertionSort(array, leftBorder, rightBorder);
	}
	else
	{
		searhTheNumberBiggerThanFirst(array, leftBorder, rightBorder);
		int border = movement(array, leftBorder, rightBorder);
		quickSort(array, leftBorder, border - 1);
		quickSort(array, border, rightBorder);
	}
}


int main()
{
	int length = 0;
	while (length <= 0)
	{
		cout << "Enter the length of array:" << endl;
		cin >> length;
		if (length <= 0)
		{
			cout << "Length is POSITIVE number" << endl;
		}
	}
	
	int *numbers = new int[length];
	for (int i = 0; i < length; ++i)
	{
		cout << "Enter the number: ";
		cin >> numbers[i];
	}
	
	quickSort(numbers, 0, length - 1);
	
	cout << "End:" << endl;
	printArray(numbers, length);
	delete[] numbers;
	return 0;
}

/*
���� 1:
length = 7;
������: 0 0 0 0 0 0 0 0
�����: 0 0 0 0 0 0 0 0

���� 2:
length = 5;
������: 8 6 1 2 8
�����: 1 2 6 8 8

���� 3:
length = 15;
������: 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 
�����: 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1

���� 4:
length = 20;
������: 5 6 8 7 12 3 20 15 49 67 85 25 1 2 3 5 7 6 1 5
�����: 1 1 2 3 3 5 5 5 6 6 7 7 8 12 15 20 25 49 67 85
*/