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

//�������������� vertexes.
void createVertexes(Vertex *vertexes, int quantityOfVertexes);

//������������� �����.
void createGraph(bool graph[100][100], Road *roads, int quantityOfRoads);

//������������ ��������� �������.
void createStates(Vertex *vertexes, int quantityOfVertexes, int quantityOfStates);

//����������� � ������� numberOfState �������� ��������� ��������� �����, ���� �� ����.
void occupyFreeVertex(bool graph[100][100], Vertex *vertexes, int quantityOfVertexes, Road *roads, int quantityOfRoads, int numberOfState);

//���������, ��� �� ������ ������.
bool areOccupied(Vertex *vertexes, int quantityOfVertexes);