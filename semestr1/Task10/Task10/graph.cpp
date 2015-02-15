#include "graph.h"

void createVertexes(Vertex *vertexes, int quantityOfVertexes)
{
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		vertexes[i].number = i;
		vertexes[i].state = -1;
	}
}

void createGraph(bool graph[100][100], Road *roads, int quantityOfRoads)
{
	for (int i = 0; i < quantityOfRoads; ++i)
	{
		graph[roads[i].firstVertex.number][i] = true;
		graph[roads[i].secondVertex.number][i] = true;
	}
}

void createStates(Vertex *vertexes, int quantityOfVertexes, int quantityOfStates)
{
	for (int i = 0; i < quantityOfStates; ++i)
	{
		if (i == quantityOfVertexes)
		{
			break;
		}
		vertexes[i].state = i;
	}
}

void occupyFreeVertex(bool graph[100][100], Vertex *vertexes, int quantityOfVertexes, Road *roads, int quantityOfRoads, int numberOfState)
{
	int numberOfVertex = -1;
	int theSortestWay = -1;
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		if (numberOfState == vertexes[i].state)
		{
			for (int j = 0; j < quantityOfRoads; ++j)
			{
				if (graph[i][j])
				{
					int neighbourVertex = roads[j].firstVertex.number;
					if (neighbourVertex == i)
					{
						neighbourVertex = roads[j].secondVertex.number;
					}
					if (vertexes[neighbourVertex].state == -1)
					{
						if (theSortestWay == -1)
						{
							theSortestWay = roads[j].length;
							numberOfVertex = neighbourVertex;
						}
						if (theSortestWay > roads[i].length)
						{
							theSortestWay = roads[j].length;
							numberOfVertex = neighbourVertex;
						}
					}
					
				}
			}
		}
	}
	vertexes[numberOfVertex].state = numberOfState;

}

bool areOccupied(Vertex *vertexes, int quantityOfVertexes)
{
	for (int i = 0; i < quantityOfVertexes; ++i)
	{
		if (vertexes[i].state == -1)
		{
			return false;
		}
	}
	return true;
}