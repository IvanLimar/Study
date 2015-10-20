using System.Collections.Generic;
using System.Linq;

namespace JumpingRobots
{
    /// <summary>
    /// Represents Graph, which solves our task.
    /// </summary>
    public class Graph
    {
        private List<Vertex> vertexes = new List<Vertex>();

        public Graph(List<List<bool>> matrixOfAdjacency, List<int> numbersOfOccupiedVertexes)
        {
            if (!AreCorrectEntranceDate(matrixOfAdjacency, numbersOfOccupiedVertexes))
            {
                vertexes = null;
                return;
            }
            int count = matrixOfAdjacency.Count;
            const int zero = 0;
            for (int i = zero; i < count; ++i)
            {
                vertexes.Add(new Vertex());
            }
            for (int i = zero; i < count; ++i)
            {
                vertexes[i].SetRobot(numbersOfOccupiedVertexes.Contains(i));
                List<Vertex> neighbours = new List<Vertex>();
                for (int j = zero; j < count; ++j)
                {
                    if (i != j && matrixOfAdjacency[i].ElementAt(j))
                    {
                        neighbours.Add(vertexes[j]);
                    }
                }
                vertexes[i].SetNeighbours(neighbours);
            }
        }

        /// <summary>
        /// Returns true, if it is possible to destroy robots.
        /// </summary>
        public bool PossibilityOfDestroyingRobots()
        {
            if (vertexes == null)
            {
                return false;
            }
            DivideGraph();
            int amountOfRobotsInFirstSubgraph = 0;
            int amountOfRobotsInSecondSubgraph = 0;
            CountRobotsInSubgraps(ref amountOfRobotsInFirstSubgraph, ref amountOfRobotsInSecondSubgraph);
            const int one = 1;
            return (amountOfRobotsInFirstSubgraph != one && amountOfRobotsInSecondSubgraph != one);
        }

        /// <summary>
        /// Counts robots in subgraphes.
        /// </summary>
        private void CountRobotsInSubgraps(ref int amountOfRobotsInFirstSubgraph, ref int amountOfRobotsInSecondSubgraph)
        {
            amountOfRobotsInFirstSubgraph = 0;
            amountOfRobotsInSecondSubgraph = 0;
            const int zero = 0;
            for (int i = zero; i < vertexes.Count; ++i)
            {
                if (vertexes[i].ContainsRobot)
                {
                    switch (vertexes[i].NumberOfSubgraph)
                    {
                        case Subgraph.First: ++amountOfRobotsInFirstSubgraph; break;
                        case Subgraph.Second: ++amountOfRobotsInSecondSubgraph; break;
                        default: amountOfRobotsInFirstSubgraph = 1; amountOfRobotsInSecondSubgraph = 1; return;
                    }
                }                
            }
        }

        /// <summary>
        /// Divides graph into two subgraphes.
        /// </summary>
        private void DivideGraph()
        {
            const int zero = 0;
            int startParity = 0;
            vertexes[zero].MakeFirstSubrgaph(ref startParity);
            for (int i = zero; i < vertexes.Count; ++i)
            {
                if (vertexes[i].NumberOfSubgraph == Subgraph.Zero)
                {
                    vertexes[i].SetSubgraph(Subgraph.Second);
                }
            }
        }

        /// <summary>
        /// Returns true, if entrance data was correct
        /// </summary>
        private bool AreCorrectEntranceDate(List<List<bool>> matrixOfAdjacency, List<int> numbersOfOccupiedVertexes)
        {
            if (matrixOfAdjacency == null || matrixOfAdjacency.Count == 0)
            {
                return false;
            }
            int temp = matrixOfAdjacency.Count;
            const int zero = 0;
            for (int i = zero; i < temp; ++i)
            {
                if (matrixOfAdjacency[i].Count != temp)
                {
                    return false;
                }
            }
            if (numbersOfOccupiedVertexes != null && numbersOfOccupiedVertexes.Count > 0)
            {
                int countOfOccupiedVertexes = numbersOfOccupiedVertexes.Count;
                if (countOfOccupiedVertexes > temp)
                {
                    return false;
                }
                for (int i = zero; i < countOfOccupiedVertexes; ++i)
                {
                    if (numbersOfOccupiedVertexes[i] >= temp)
                    {
                        return false;
                    }
                }
            }
            for (int i = zero; i < temp; ++i)
            {
                for (int j = i; j < temp; ++j)
                {
                    if (matrixOfAdjacency[i].ElementAt(j) != matrixOfAdjacency[j].ElementAt(i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private class Vertex
        {
            private bool containsRobot;
            private Subgraph numberOfSubgraph = Subgraph.Zero;
            private List<Vertex> neighbours;

            public Subgraph NumberOfSubgraph
            {
                get
                {
                    return numberOfSubgraph;
                }
            }

            public bool ContainsRobot
            {
                get
                {
                    return containsRobot;
                }
            }

            public void SetNeighbours(List<Vertex> neighbours)
            {
                this.neighbours = neighbours;
            }

            public void SetRobot(bool containsRobot)
            {
                this.containsRobot = containsRobot;
            }

            public void SetSubgraph(Subgraph subgraph)
            {
                numberOfSubgraph = subgraph;
            }

            /// <summary>
            /// Finds vertexes, which referes to first subgraph
            /// </summary>
            public void MakeFirstSubrgaph(ref int parity)
            {
                if (parity % 2 == 0)
                {
                    numberOfSubgraph = Subgraph.First;
                    ++parity;
                    foreach (var v in neighbours)
                    {
                        v.MakeFirstSubrgaph(ref parity);
                    }
                }
                else
                {
                    ++parity;
                    foreach (var v in neighbours)
                    {
                        if (v.NumberOfSubgraph != Subgraph.First)
                        {
                            v.MakeFirstSubrgaph(ref parity);
                        }
                    }
                    --parity;
                }
            }
        }
    }
}