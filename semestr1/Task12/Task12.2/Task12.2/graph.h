#pragma once

//������� ���� quantityOfVertexes �� quantityOfVertexes.
int **createGraph(int quantityOfVertexes);

//������� ���� quantityOfVertexes �� quantityOfVertexes.
void deleteGraph(int **graph, int quantityOfVertexes);

//������ ����������� �������� ������.
void buildSpanningTree(int **graph, int **spanningTree, int quantityOfVertexes, int startVertex);

//������� ���� �� �������.
void printingGraph(int **graph, int quantityOfVertexes);