#include "graph.h"
#include <iostream>

int **createGraph(int quantityOfVertexes)
{
	int **graph = new int*[quantityOfVertexes];
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		graph[i] = new int[quantityOfVertexes];
		for (int j = 0; j < quantityOfVertexes; ++j)
		{
			graph[i][j] = 0;
		}
	}
	return graph;
}

void deleteGraph(int **graph, int quantityOfVertexes)
{
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		delete[] graph[i];
	}
	delete[] graph;
}

//»щем ближайшую соседнюю вершину(*line = graph[i], i - номер вершину, у которой ищем ближайшую).
int neighbourVertex(int *line, bool *isVisited, int quantityOfVertexes)
{
	int result = -1;
	int length = -1;
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		if (length == -1 && !isVisited[i] && line[i] > 0)
		{
			result = i;
			length = line[i];
		}
		if (!isVisited[i] && line[i] < length && line[i] > 0)
		{
			result = i;
			length = line[i];
		}
	}
	return result;
}

//»щем ближайшую вершину к остовному дереву
int nearestVertex(int **graph, bool *isVisited, int quantityOfVertexes, int &vertex)
{
	int result = -1;
	int length = -1;
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		if (isVisited[i])
		{
			int const neighbour = neighbourVertex(graph[i], isVisited, quantityOfVertexes);
			if (length == -1 && neighbour >= 0)
			{
				length = graph[i][neighbour];
				result = neighbour;
				vertex = i;
			}
			if (length > graph[i][neighbour] && neighbour >= 0)
			{
				length = graph[i][neighbour];
				result = neighbour;
				vertex = i;
			}
		}
	}
	return result;
}

void buildSpanningTree(int **graph, int **spanningTree, int quantityOfVertexes, int startVertex)
{
	bool *isVisited = new bool[quantityOfVertexes];
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		isVisited[i] = false;
	}
	isVisited[startVertex] = true;
	while (true)
	{
		int vertex = nearestVertex(graph, isVisited, quantityOfVertexes, startVertex);
		spanningTree[startVertex][vertex] = graph[startVertex][vertex];
		spanningTree[vertex][startVertex] = graph[vertex][startVertex];
		isVisited[vertex] = true;
		bool isEnd = true;
		for (int i = 0; i < quantityOfVertexes; ++i)
		{
			if (!isVisited[i])
			{
				isEnd = false;
				break;
			}
		}
		if (isEnd)
		{
			break;
		}
	}
	delete[] isVisited;
}

void printingGraph(int **graph, int quantityOfVertexes)
{
	std::cout << "Printing graph:" << std::endl;
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		for (int j = 0; j < quantityOfVertexes; ++j)
		{
			std::cout << graph[i][j] << " ";
		}
		std::cout << std::endl;
	}
}