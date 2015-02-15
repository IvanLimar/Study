#include <fstream>
#include "graph.h"

using namespace std;

void main()
{
	fstream file("text.txt");
	int quantutyOfVertexes = 0;
	file >> quantutyOfVertexes;
	int **graph = createGraph(quantutyOfVertexes);
	for (int i = 0; i < quantutyOfVertexes; ++i)
	{
		for (int j = 0; j < quantutyOfVertexes; ++j)
		{
			file >> graph[i][j];
		}
	}
	file.close();
	int **spanningTree = createGraph(quantutyOfVertexes);

	int const startVertex = 0;
	buildSpanningTree(graph, spanningTree, quantutyOfVertexes, 0);

	deleteGraph(graph, quantutyOfVertexes);

	printingGraph(spanningTree, quantutyOfVertexes);

	deleteGraph(spanningTree, quantutyOfVertexes);
}