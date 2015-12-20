using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace JumpingRobotsTest
{
    using JumpingRobots;
    [TestClass]
    // Maybe, it should be refactored
    public class GraphTest
    {
        private Graph graph;

        [TestMethod]
        public void WrongSizeOfMatrixOfAdjacencyTest()
        {
            const int zero = 0;
            const int firstSize = 3;
            const int secondSize = 2;
            List<List<bool>> matrixOfAdjacency = new List<List<bool>>();
            List<int> temp = new List<int>(zero);
            graph = new Graph(matrixOfAdjacency, temp);
            Assert.IsFalse(graph.PossibilityOfDestroyingRobots());
            for (int i = zero; i < firstSize; ++i)
            {
                matrixOfAdjacency.Add(new List<bool>());
                for (int j = zero; j < secondSize; ++j)
                {
                    matrixOfAdjacency[i].Add(true);
                }
            }

            graph = new Graph(matrixOfAdjacency, temp);
            Assert.IsFalse(graph.PossibilityOfDestroyingRobots());
        }

        [TestMethod]
        public void NotSymmetricMatrixOfAdjacencyTest()
        {
            const int zero = 0;
            List<List<bool>> matrixOfAdjacency = new List<List<bool>>() { new List<bool>()  {true, true, true},
                                                                          new List<bool>() {false, true, true},
                                                                          new List<bool>() {true, false, true}};
            graph = new Graph(matrixOfAdjacency, new List<int>(zero));
            Assert.IsFalse(graph.PossibilityOfDestroyingRobots());
        }

        [TestMethod]
        public void WrongNumbersOfOccupiedVertexes()
        {
            List<List<bool>> matrixOfAdjacency = new List<List<bool>>() { new List<bool>()  {true, true, true},
                                                                          new List<bool>() {true, true, true},
                                                                          new List<bool>() {true, true, true}};
            List<int> temp = new List<int>() { 0, 1, 2, 3 };
            graph = new Graph(matrixOfAdjacency, temp);
            Assert.IsFalse(graph.PossibilityOfDestroyingRobots());
        }

        [TestMethod]
        public void SimpleGraphTest()
        {
            List<List<bool>> matrixOfAdjacency = new List<List<bool>>() { new List<bool>()  {true, true, true},
                                                                          new List<bool>() {true, true, false},
                                                                          new List<bool>() {true, false, true}};
            List<int> list = new List<int>() { 0, 1, 2 };
            graph = new Graph(matrixOfAdjacency, list);
            Assert.IsFalse(graph.PossibilityOfDestroyingRobots());
            list = new List<int>() { 1, 2 };
            graph = new Graph(matrixOfAdjacency, list);
            Assert.IsTrue(graph.PossibilityOfDestroyingRobots());
        }

        [TestMethod]
        public void OneMoreSimpleGraphTest()
        {
            List<List<bool>> matrixOfAdjacency = new List<List<bool>>() { new List<bool>()  {true, true, true},
                                                                          new List<bool>() {true, true, true},
                                                                          new List<bool>() {true, true, true}};
            List<int> list = new List<int>() { 0, 1, 2 };
            graph = new Graph(matrixOfAdjacency, list);
            Assert.IsTrue(graph.PossibilityOfDestroyingRobots());
            list = new List<int>() { 1, 2 };
            graph = new Graph(matrixOfAdjacency, list);
            Assert.IsTrue(graph.PossibilityOfDestroyingRobots());
        }

        [TestMethod]
        public void FirstNormalTest()
        {
            List<List<bool>> matrixOfAdjacency = new List<List<bool>>() { new List<bool>()  {true, true, !true, !true, true, !true, !true, !true, !true, !true},
                                                                          new List<bool>()  {true, true, true, !true, !true, !true, !true, !true, !true, !true},
                                                                          new List<bool>()  {!true, true, true, true, !true, !true, true, !true, !true, !true},
                                                                          new List<bool>()  {!true, !true, true, true, !true, !true, true, !true, !true, !true},
                                                                          new List<bool>()  {true, !true, !true, !true, true, true, !true, true, !true, !true},
                                                                          new List<bool>()  {!true, !true, !true, !true, true, true, true, !true, true, !true},
                                                                          new List<bool>()  {!true, !true, true, true, !true, true, true, !true, !true, true},
                                                                          new List<bool>()  {!true, !true, !true, !true, true, !true, !true, true, true, !true},
                                                                          new List<bool>()  {!true, !true, !true, !true, !true, true, !true, true, true, true},
                                                                          new List<bool>()  {!true, !true, !true, !true, !true, !true, true, !true, true, true} };
            List<int> list = new List<int>() { 1, 2, 4, 8 };
            graph = new Graph(matrixOfAdjacency, list);
            Assert.IsTrue(graph.PossibilityOfDestroyingRobots());
        }
    }
}
