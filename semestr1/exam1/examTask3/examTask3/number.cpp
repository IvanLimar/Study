#include "number.h"
#include <iostream>

using namespace std;

int sumOfNumbers(int number)
{
	if (number < 0)
	{
		number = -number;
	}
	int result = 0;
	while (number > 0)
	{
		result = result + number % 10;
		number = number / 10;
	}
	return result;
}

int maxSumNumbers(int *numbers, int *amountOfNumbers, int length)
{
	int result = 0;
	for (int i = 0; i < length; ++i)
	{
		int const sum = amountOfNumbers[i];
		if (result < sum)
		{
			result = sum;
		}
	}
	return result;
}

void print(int *numbers, int *ammountOfNumbers, int length, int maxSum)
{
	cout << "The largest amount of numbers: "  << maxSum << endl;
	for (int i = 0; i < length; ++i)
	{
		if (ammountOfNumbers[i] == maxSum)
		{
			cout << numbers[i] << endl;
		}
	}
}