#pragma once

struct Vertex
{
	int state;
	int number;
};

struct Road
{
	Vertex firstVertex;
	Vertex secondVertex;
	int length;
};

//Инициализзация vertexes.
void createVertexes(Vertex *vertexes, int quantityOfVertexes);

//Инициализация графа.
void createGraph(bool graph[100][100], Road *roads, int quantityOfRoads);

//Государствам раздаются столицы.
void createStates(Vertex *vertexes, int quantityOfVertexes, int quantityOfStates);

//Государство с номером numberOfState занимает свободный ближайший город, если он есть.
void occupyFreeVertex(bool graph[100][100], Vertex *vertexes, int quantityOfVertexes, Road *roads, int quantityOfRoads, int numberOfState);

//Проверяет, все ли города заняты.
bool areOccupied(Vertex *vertexes, int quantityOfVertexes);