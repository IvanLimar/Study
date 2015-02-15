#include <iostream>
#include "matrix.h"

using namespace std;

void main()
{
	cout << "Enter the hight of matrix: ";
	int hight = size();

	cout << "Enter the length of matrix: ";
	int length = size();

	int **matrix = createMatrix(hight, length);

	printSeddlePoints(matrix, hight, length);

	deleteMatrix(matrix, hight);
}

/*
Ввод:
1 1
0
Вывод:
matrix[0][0] = 0;

Ввод:
3 3
0 0 0
0 0 0
0 0 0
Вывод:
There aren't seddle points in matrix.

Ввод: 2 4
1 2 3 4
5 6 7 8
Вывод:
matrix[1][0] = 5
*/