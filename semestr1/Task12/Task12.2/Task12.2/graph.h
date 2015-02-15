#pragma once

//Создаем граф quantityOfVertexes на quantityOfVertexes.
int **createGraph(int quantityOfVertexes);

//Удаляем граф quantityOfVertexes на quantityOfVertexes.
void deleteGraph(int **graph, int quantityOfVertexes);

//Строим минимальное остовное дерево.
void buildSpanningTree(int **graph, int **spanningTree, int quantityOfVertexes, int startVertex);

//Выводим граф на консоль.
void printingGraph(int **graph, int quantityOfVertexes);