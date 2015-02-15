#include <iostream>

using namespace std;

void bubbleSort(int* aray, int length)
{
	const int startIndex = 0;
	for (int i = startIndex; i < length; ++i)
	{
		for (int j = length - 1; j > i; --j)
		{
			if (aray[j - 1] > aray[j])
			{
				const int x = aray[j];
				aray[j] = aray[j - 1];
				aray[j - 1] = x;
			}
		}
		
	}
}

int minimum(int* aray, int length)
{
	const int startIndex = 0;
	int result = aray[startIndex];
	for (int i = startIndex + 1; i < length; ++i)
	{
		if (aray[i] < result)
		{
			result = aray[i];
		}
	}
	return result;
}

int maximum(int* aray, int length)
{
	const int startIndex = 0;
	int result = aray[startIndex];
	for (int i = startIndex + 1; i < length; ++i)
	{
		if (aray[i] > result)
		{
			result = aray[i];
		}
	}
	return result;
}

void increase(int* aray, int length, int number)
{
	if (number < 0)
	{
		number = -number;
	}
	const int startIndex = 0;
	for (int i = startIndex; i < length; ++i)
	{
		aray[i] = aray[i] + number;
	}
}

void decrease(int* aray, int length, int number)
{
	if (number < 0)
	{
		number = -number;
	}
	const int startIndex = 0;
	for (int i = startIndex; i < length; ++i)
	{
		aray[i] = aray[i] - number;
	}
}

void cauntingSort(int* aray, int length)
{
	const int min = minimum(aray, length);
	if (min < 0)
	{
		increase(aray, length, min);
	}

	const int helpedArrayLength = maximum(aray, length) + 1;
	int* helpedArray = new int[helpedArrayLength];
	const int startIndex = 0;

	for (int i = startIndex; i < helpedArrayLength; ++i)
	{
		helpedArray[i] = 0;
	}

	for (int i = startIndex; i < length; ++i)
	{
		++helpedArray[aray[i]];
	}

	int index = 0;
	for (int i = startIndex; i < helpedArrayLength; ++i)
	{
		while (helpedArray[i] > 0)
		{
			aray[index] = i;
			++index;
			--helpedArray[i];
		}
	}

	if (min < 0)
	{
		decrease(aray, length, min);
	}
	delete[] helpedArray;
}

int main()
{
	cout << "enter the length of array:" << endl;
	int length = 0;
	cin >> length;
	int *aray = new int[length];
	for (int i = 0; i < length; ++i)
	{
		cout << "enter the number: ";
		cin >> aray[i];
	}

	cout << "Array in the begining:";
	const int startIndex = 0;
	for (int i = startIndex; i < length; ++i)
	{
		cout << " " << aray[i];
	}
	cout << endl << "End: ";

	const bool isBubbleSort = false;

	if (isBubbleSort)
	{
		bubbleSort(aray, length);
	}
	else
	{
		cauntingSort(aray, length);
	}

	for (int i = startIndex; i < length; ++i)
	{
		cout << aray[i] << " ";
	}

	delete[] aray;
	cout << endl;
	cin.ignore();
	return 0;
}