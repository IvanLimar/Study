#include "number.h"
#include <iostream>

using namespace std;

void main()
{
	cout << "Enter the length of array: ";
	int length = 0;
	cin >> length;
	int *numbers = new int[length];
	int *amountOfNumbers = new int[length];
	for (int i = 0; i < length; ++i)
	{
		cout << "Enther the number:";
		cin >> numbers[i];
		amountOfNumbers[i] = sumOfNumbers(numbers[i]);
	}
	int const maxSum = maxSumNumbers(numbers, amountOfNumbers, length);
	print(numbers, amountOfNumbers, length, maxSum);
	delete[] numbers;
	delete[] amountOfNumbers;
}