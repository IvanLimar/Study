#include "binaryNumber.h"
#include <iostream>

using namespace std;

void convertToBinary(int number, bool* array, int size)
{
	for (int i = size - 1; i >= 0; --i)
	{
		array[i] = number % 2 == 1;
		number = number / 10;
	}
}

int compare(bool* array1, bool* array2, int size)
{
	for (int i = 0; i < size; ++i)
	{
		if (!array1[i] && array2[i])
		{
			return -1;
		}
		if (array1[i] && !array2[i])
		{
			return 1;
		}
	}
	return 0;
}