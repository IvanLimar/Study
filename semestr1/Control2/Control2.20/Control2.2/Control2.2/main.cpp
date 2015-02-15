#include <iostream>
#include <fstream>

using namespace std;



// Спускаемся в глубь графа
void goingDown(int **matrix, int quantity, int startLine, bool *isVisited)
{
	isVisited[startLine] = true;
	for (int j = 0; j < quantity; ++j)
	{
		if (matrix[startLine][j] == 1 && !isVisited[j])
		{
			goingDown(matrix, quantity, j, isVisited);
		}
	}
}

//Начинаем обход графа в глубину с вершины startLine
void walking(int **matrix, int quantity, int startLine, bool *isVisited)
{
	isVisited[startLine] = true;
	for (int j = 0; j < quantity; ++j)
	{
		if (matrix[startLine][j] == 1 && !isVisited[j])
		{
			goingDown(matrix, quantity, j, isVisited);
		}
	}
	for (int j = 0; j < quantity; ++j)
	{
		if (isVisited[j])
		{
			matrix[startLine][j] = 1;
		}
	}
}



void main()
{
	fstream input("input.txt");
	int quantity = 0;
	input >> quantity;
	int **matrix = new int*[quantity];
	for (int i = 0; i < quantity; ++i)
	{
		matrix[i] = new int[quantity];
		for (int j = 0; j < quantity; ++j)
		{
			input >> matrix[i][j];
		}
	}
	input.close();
	for (int i = 0; i < quantity; ++i)
	{
		bool *isVisited = new bool[quantity];
		for (int j = 0; j < quantity; ++j)
		{
			isVisited[j] = false;
		}
		walking(matrix, quantity, i, isVisited);
		delete[] isVisited;
	}
	fstream output("output.txt");
	output.clear();
	for (int i = 0; i < quantity; ++i)
	{
		for (int j = 0; j < quantity; ++j)
		{
			if (matrix[i][j] == 1)
			{
				output << "1 ";
			}
			else
			{
				output << "0 ";
			}
		}
		output << endl;
	}
	output.close();
	delete[] matrix;
}

/*
Тест:
Ввод:
5
0 1 1 0 0
1 0 0 0 1
1 0 0 1 0
0 0 1 0 1
0 1 0 1 0

Вывод:
1 1 1 1 1
1 1 1 1 1
1 1 1 1 1
1 1 1 1 1
1 1 1 1 1

Тест:
Ввод:
5
0 1 0 0 0
0 0 1 0 0
0 0 0 1 0
0 0 0 0 1
0 0 0 0 0

Вывод:
1 1 1 1 1
0 1 1 1 1
0 0 1 1 1
0 0 0 1 1
0 0 0 0 1

*/