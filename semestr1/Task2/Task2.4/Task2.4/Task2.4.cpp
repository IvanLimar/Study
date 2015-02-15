#include <iostream>
#include <stdlib.h>
#include <ctime>

using namespace std;

void printArray(int* array, int length)
{
	for (int i = 0; i < length; ++i)
	{
		cout << array[i] << " ";
	}
	cout << endl;
}
// ����� �� ������� ������� "array" ������ "length" 


int main()
{
	const int length = 8;
	int* numbers = new int[length];

	srand(time(NULL));

	for (int i = 0; i < length; ++i)
	{
		numbers[i] = rand() % 100 + 1;
	}

	cout << "begining:" << endl;
	printArray(numbers, length);

	int firstNumberIndex = 0;
	int rightIndex = length - 1;
	int leftIndex = 0;
	bool areIndexesLegal = (leftIndex <= length - 1) && (rightIndex >= 0);

	while (leftIndex <= rightIndex && areIndexesLegal)
	{
		while (numbers[firstNumberIndex] < numbers[rightIndex] && areIndexesLegal)
		{
			--rightIndex;
		}
		if (areIndexesLegal && leftIndex <= rightIndex)
		{
			swap(numbers[firstNumberIndex], numbers[rightIndex]);
			firstNumberIndex = rightIndex;
		}
		
		while (areIndexesLegal && numbers[firstNumberIndex] >= numbers[leftIndex])
		{
			++leftIndex;
		}
		if (areIndexesLegal && leftIndex <= rightIndex)
		{
			swap(numbers[firstNumberIndex], numbers[leftIndex]);
			firstNumberIndex = leftIndex;
		}
		
	}
	

	

	cout << "end:" << endl;
	printArray(numbers, length);
	delete[] numbers;

	return 0;
}
/*
���� 1:
����: 5, 5, 5, 5, 5, 5, 5, 5
�����: 5, 5, 5, 5, 5, 5, 5, 5

���� 2:
����: 1, 5, 5, 5, 5, 5, 5, 5
�����: 1, 5, 5, 5, 5, 5, 5, 5

���� 3:
����: 1, 5, 5, 1, 5, 5, 5, 5
�����: 1, 1, 5, 5, 5, 5, 5, 5

���� 4:
����: 5, 5, 5, 6, 5, 5, 5, 5
�����: 5, 5, 5, 5, 5, 5, 5, 6

���� 5:
����: 6, 5, 5, 5, 5, 5, 5, 5
�����: 5, 5, 5, 5, 5, 5, 5, 6

���� 6:
����: 59, 26, 8, 59, 29, 64, 55, 7
�����: 7, 26, 8, 59, 29, 55, 59, 64

���� 7:
����: 58, 12, 81, 32, 24, 6, 58, 27
�����: 27, 12, 58, 32, 24, 6, 58, 81

���� 8:
����: 17, 88, 60, 88, 47, 62, 48, 7
�����: 7, 17, 60, 88, 47, 62, 48, 88

���� 9:
����: 91, 51, 90, 90, 35, 27, 50, 92
�����: 50, 51, 90, 90, 35, 27, 91, 92

���� 10:
����: 12, 45, 15, 69, 61, 53, 25, 100
�����: 12, 45, 15, 69, 61, 53, 25, 100
*/
