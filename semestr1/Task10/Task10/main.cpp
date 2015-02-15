// Решение задачи для неориентированного графа.
// Нумерация вешин, дорог, государств начинается с 0.
// Граф представлен в виде матрицы  инцидентности.

#include <iostream>
#include <fstream>
#include "graph.h"

using namespace std;

// Переопределение roads
void rebuilding(Vertex *vertexes ,Road *roads, int quantityOfRoads)
{
	for (int i = 0; i < quantityOfRoads; ++i)
	{
		int firstNumber = 0;
		firstNumber = roads[i].firstVertex.number;
		int secondNumber = 0;
		secondNumber = roads[i].secondVertex.number;
		roads[i].firstVertex = vertexes[firstNumber];
		roads[i].secondVertex = vertexes[secondNumber];
	}
}

void main()
{
	fstream file("Text.txt");
	int buffer = 0;
	file >> buffer;
	const int quantityOfVertexes = buffer;
	Vertex vertexes[100];
	createVertexes(vertexes, quantityOfVertexes);

	
	file >> buffer;
	int const quantityOfRoads = buffer;

	Road roads [100];
	for (int i = 0; i < quantityOfRoads; ++i)
	{
		int firstNumber = 0;
		file >> firstNumber;
		int secondNumber = 0;
		file >> secondNumber;
		file >> roads[i].length;
		roads[i].firstVertex = vertexes[firstNumber];
		roads[i].secondVertex = vertexes[secondNumber];
	}

	
	file >> buffer;
	int const quantityOfStates = buffer;
	file.close();
	createStates(vertexes, quantityOfVertexes, quantityOfStates);

	rebuilding(vertexes, roads, quantityOfRoads);

	bool graph[100] [100];
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		for (int j = 0; j < quantityOfRoads; ++j)
		{
			graph[i][j] = false;
		}
	}

	createGraph(graph, roads, quantityOfRoads);

	int numberOfState = 0;
	while (!areOccupied(vertexes, quantityOfVertexes))
	{
		if (numberOfState == quantityOfStates)
		{
			numberOfState = 0;
		}
		occupyFreeVertex(graph, vertexes, quantityOfVertexes, roads, quantityOfRoads, numberOfState);
		++numberOfState;
		rebuilding(vertexes, roads, quantityOfRoads);
	}
	
	for (int i = 0; i < quantityOfStates; ++i)
	{
		if (i == quantityOfVertexes)
		{
			break;
		}
		cout << "State " << i << ": ";
		for (int j = 0; j < quantityOfVertexes; ++j)
		{
			if (i == vertexes[j].state)
			{
				cout << j << " ";
			}
		}
		cout << endl;
	}
}