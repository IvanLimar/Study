#include "matrix.h"
#include <iostream>

using namespace std;

int **createMatrix(int hight, int length)
{
	cout << "Enter the matrix:" << endl;
	int **matrix = new int*[hight];
	for (int i = 0; i < hight; ++i)
	{
		matrix[i] = new int[length];
		for (int j = 0; j < length; ++j)
		{
			cin >> matrix[i][j];
		}
	}
	return matrix;
}

void deleteMatrix(int **matrix, int hight)
{
	for (int j = 0; j < hight; ++j)
	{
		delete[] matrix[j];
	}
	delete[] matrix;
}

int size()
{
	int size = 0;
	cin >> size;
	return size;
}

//»щем все минимумы в строках.
void findMinimum(int **matrix, int hight, int length, bool *isMinimum, int *minimum, int *position)
{
	for (int i = 0; i < hight; ++i)
	{
		minimum[i] = matrix[i][0];
		isMinimum[i] = true;
		position[i] = 0;
		for (int j = 1; j < length; ++j)
		{
			if (matrix[i][j] == minimum[i])
			{
				isMinimum[i] = false;
				position[i] = -1;
			}
			if (matrix[i][j] < minimum[i])
			{
				isMinimum[i] = true;
				minimum[i] = matrix[i][j];
				position[i] = j;
			}
		}
	}
}

//»щем все максимуы в столбцах.
void findMaximum(int **matrix, int hight, int length, bool *isMaximum, int *maximum)
{
	for (int i = 0; i < length; ++i)
	{
		maximum[i] = matrix[0][i];
		isMaximum[i] = true;
		for (int j = 1; j < hight; ++j)
		{
			if (matrix[j][i] == maximum[i])
			{
				isMaximum[i] = false;
			}
			if (matrix[j][i] > maximum[i])
			{
				isMaximum[i] = true;
				maximum[i] = matrix[j][i];
			}
		}
	}
}

//—оздаем массив длины length
int *numbers(int length)
{
	int *numbers = new int[length];
	for (int i = 0; i < length; ++i)
	{
		numbers[i] = 0;
	}
	return numbers;
}

//—оздаем булевый массив длины length
bool *boolean(int length)
{
	bool *boolean = new bool[length];
	for (int i = 0; i < length; ++i)
	{
		boolean[i] = true;
	}
	return boolean;
}

void printSeddlePoints(int **matrix, int hight, int length)
{
	cout << "Seddle points:" << endl;

	int *minimum = numbers(hight);
	int *minPosition = numbers(hight);
	bool *isMinimum = boolean(hight);
	findMinimum(matrix, hight, length, isMinimum, minimum, minPosition);

	int *maximum = numbers(length);
	bool *isMaximum = boolean(length);
	findMaximum(matrix, hight, length, isMaximum, maximum);

	bool isSeddleElement = false;
	for (int i = 0; i < hight; ++i)
	{
		if (isMinimum[i] && isMaximum[minPosition[i]] && minimum[i] == maximum[minPosition[i]])
		{
			isSeddleElement = true;
			cout << "Matrix[" << i << "][" << minPosition[i] << "] = " << matrix[i][minPosition[i]] << endl;
		}
	}
	if (!isSeddleElement)
	{
		cout << "There arent't seddle points in matrix." << endl;
	}

	delete[] minimum;
	delete[] maximum;
	delete[] isMaximum;
	delete[] isMinimum;
	delete[] minPosition;
}