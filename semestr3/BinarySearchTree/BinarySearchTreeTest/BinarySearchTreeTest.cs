using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTest
{
    using BinarySearchTree;

    [TestClass]
    public class BinarySearchTreeTest
    {
        private BinarySearchTree tree;
        private List<int> values;

        [TestInitialize]
        public void TestInit()
        {
            tree = new BinarySearchTree();
            values = new List<int>();
        }

        [TestMethod]
        public void TestOne()
        {
            tree.Add(5);
            tree.Add(7);
            tree.Add(3);
            tree.Add(9);
            tree.Add(2);
            tree.Add(4);
            tree.Add(6);
            tree.Add(1);
            tree.Add(10);
            tree.Add(15);
            tree.Add(13);
            tree.Add(14);
            values.Add(5);
            values.Add(3);
            values.Add(2);
            values.Add(1);
            values.Add(4);
            values.Add(7);
            values.Add(6);
            values.Add(9);
            values.Add(10);
            values.Add(15);
            values.Add(13);
            values.Add(14);
            int i = 0;
            foreach (var x in tree)
            {
                Assert.AreEqual(x, values[i++]);
            }
        }

        [TestMethod]
        public void TestTwo()
        {
            for (int i = 0; i < 10; ++i)
            {
                tree.Add(i);
                values.Add(i);
            }
            int y = 0;
            foreach (var x in tree)
            {
                Assert.AreEqual(x, values[y++]);
            }
        }

        [TestMethod]
        public void EmptyTreeTest()
        {
            foreach (var x in tree)
            {
            }
        }
    }
}
