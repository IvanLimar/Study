#include "quickSort.h"
#include <iostream>

using namespace std;

// Сортировка вставкой
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

/* Поиск в массиве "array" с границами "leftBorder" и "rightBorder" числа,
большего первого, и перестановка этого числа с первым */
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

/* Элементы, не превосходящие первого, будут слева от него. Справа - превосходящие.
Функция вернет новый индекс этого числа */
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

// Функция возвращает true, если массив с данными границами отсортирован, в противном сучае - false.
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