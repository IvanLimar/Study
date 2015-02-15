#include <iostream>

using namespace std;

// ���������� ��������
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

// ������� ���������� true, ���� �������� ����� ������������� ������� � ������� ������������, � ��������� ������ - false
bool isTheFrequentNumberExist(int* array, int leftBorder, int rightBorder)
{
	bool result = true;
	for (int quantity = 1, maxQuantity = 1, i = leftBorder; i <= rightBorder; ++i)
	{
		if (i == rightBorder)
		{
			if (quantity == maxQuantity)
			{
				result = false;
				quantity = 1;
			}
			if (quantity > maxQuantity)
			{
				result = true;
				maxQuantity = quantity;
				quantity = 1;
			}
		}
		else
		{
			if (array[i] == array[i + 1])
			{
				++quantity;
			}
			else
			{
				if (quantity == maxQuantity)
				{
					result = false;
					quantity = 1;
				}
				if (quantity > maxQuantity)
				{
					result = true;
					maxQuantity = quantity;
					quantity = 1;
				}
			}
		}
	}
	return result;
}

// ������� ���������� �������� ����� ������������� ������� � ������� array
int frequentNumber(int* array, int leftBorder, int rightBorder)
{
	int result = array[leftBorder];
	for (int quantity = 1, maxQuantity = 1, i = leftBorder; i <= rightBorder; ++i)
	{
		if (i == rightBorder)
		{
			if (quantity > maxQuantity)
			{
				result = array[i];
				maxQuantity = quantity;
				quantity = 1;
			}
		}
		else
		{
			if (array[i] == array[i + 1])
			{
				++quantity;
			}
			else
			{
				if (quantity > maxQuantity)
				{
					result = array[i];
					maxQuantity = quantity;
					quantity = 1;
				}
			}
		}
	}
	return result;
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

	if (isTheFrequentNumberExist(numbers, 0, length - 1))
	{
		int const result = frequentNumber(numbers, 0, length - 1);
		cout << "Most frequent number: " << result << endl;
	}
	else
	{
		cout << "nothing" << endl;
	}
		
	delete[] numbers;
	return 0;
}

/*
���� 1:
����: 0 0 0 0 0
�����: 0

���� 2:
����: -5 -5 -5 -5 -5
�����: -5

���� 3:
����: -5 1 5 6 7 8 9 5 5 5
�����: 5

���� 4:
����: -5 4 4 1 2
�����: 4

���� 5:
����: 2 2 3 3 1 5
�����: nothing
*/