#include "array.h"
#include <iostream>

void addToArray(int *ourArray, int index, int element)
{
	ourArray[index] = element;
}

int *createArray(int length)
{
	int *newArray = new int[length];
	return newArray;
}

void deleteArray(int *ourArray)
{
	delete[] ourArray;
}

// Проверяет отсортированность ourArray длины length.
bool isArraySorted(int *ourArray, int length)
{
	if (length == 1)
	{
		return true;
	}
	for (int i = 0; i < length - 1; ++i)
	{
		if (ourArray[i] > ourArray[i + 1])
		{
			return false;
		}
	}
	return true;
}

//Разбивает ourArray на leftArray и rightArray в равном соотношении.
void dividingArray(int *ourArray, int length, int *leftArray, int *rightArray)
{
	int index = 0;
	for (int i = 0; i < length / 2; ++i)
	{
		leftArray[i] = ourArray[index];
		++index;
	}
	for (int i = 0; i < length - length / 2; ++i)
	{
		rightArray[i] = ourArray[index];
		++index;
	}
}

//Склеивает отсортированные leftArray длины leftLength и rightArray длины rightLength в ourArray длины length.
void mergingArray(int *leftArray, int leftLength, int *rightArray, int rigthLength, int *ourArray, int length)
{
	int leftIndex = 0;
	int rightIndex = 0;
	for (int i = 0; i < length; ++i)
	{
		bool const isLeftIndexLegal = leftIndex < leftLength;
		bool const isRigthIndexLegal = rightIndex < rigthLength;
		if (!isLeftIndexLegal && isRigthIndexLegal)
		{
			ourArray[i] = rightArray[rightIndex];
			++rightIndex;
			continue;
		}
		
		if (!isRigthIndexLegal && isLeftIndexLegal)
		{
			ourArray[i] = leftArray[leftIndex];
			++leftIndex;
			continue;
		}
		
		if (leftArray[leftIndex] <= rightArray[rightIndex])
		{
			ourArray[i] = leftArray[leftIndex];
			++leftIndex;
		}
		else
		{
			ourArray[i] = rightArray[rightIndex];
			++rightIndex;
		}
	}
}

void arrayMergeSort(int *ourArray, int length)
{
	if (isArraySorted(ourArray, length))
	{
		return;
	}
	int leftLength = length / 2;
	int rightLength = length - length / 2;
	int *leftArray = createArray(leftLength);
	int *rightArray = createArray(rightLength);
	
	dividingArray(ourArray, length, leftArray, rightArray);
	if (isArraySorted(leftArray, leftLength) && isArraySorted(rightArray, rightLength))
	{
		mergingArray(leftArray, leftLength, rightArray, rightLength, ourArray, length);
	}
	else
	{
		if (!isArraySorted(leftArray, leftLength))
		{
			arrayMergeSort(leftArray, leftLength);
		}

		if (!isArraySorted(rightArray, rightLength))
		{
			arrayMergeSort(rightArray, rightLength);
		}

		mergingArray(leftArray, leftLength, rightArray, rightLength, ourArray, length);
	}
	deleteArray(leftArray);
	deleteArray(rightArray);
}

void writingArray(int *ourArray, int length)
{
	std::cout << "Your list:" << std::endl;
	for (int i = 0; i < length; ++i)
	{
		std::cout << ourArray[i] << std::endl;
	}
}