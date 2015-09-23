using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTest
{
    using BinarySearchTree;

    [TestClass]
    public class BinarySearchTreeTest
    {
        private BinarySearchTree<int> usualTree;
        private BinarySearchTree<int> listTree;
        private BinarySearchTree<int> emptyTree;
        private List<int> values;

        [TestInitialize]
        public void TestInit()
        {
            usualTree = new BinarySearchTree<int>();
            listTree = new BinarySearchTree<int>();
            emptyTree = new BinarySearchTree<int>();
            values = new List<int>();

            usualTree.Add(5);
            usualTree.Add(7);
            usualTree.Add(3);
            usualTree.Add(9);
            usualTree.Add(2);
            usualTree.Add(4);
            usualTree.Add(6);
            usualTree.Add(1);
            usualTree.Add(10);
            usualTree.Add(15);
            usualTree.Add(13);
            usualTree.Add(14);

            for (int i = 0; i < 10; ++i)
            {
                listTree.Add(i);
            }
        }

        [TestMethod]
        public void TestOne()
        {
            
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
            foreach (var x in usualTree)
            {
                Assert.AreEqual(x, values[i++]);
            }
        }

        [TestMethod]
        public void TestTwo()
        {
            for (int i = 0; i < 10; ++i)
            {
                values.Add(i);
            }
            int y = 0;
            foreach (var x in listTree)
            {
                Assert.AreEqual(x, values[y++]);
            }
        }

        [TestMethod]
        public void EmptyTreeTest()
        {
            foreach (var x in emptyTree)
            {
            }
            Assert.IsTrue(emptyTree.IsEmpty);
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                Assert.IsTrue(listTree.Contains(i));
            }
            Assert.IsFalse(emptyTree.Contains(10));
            Assert.IsTrue(usualTree.Contains(7));
            Assert.IsFalse(usualTree.Contains(100));
        }

        [TestMethod]
        public void SimplestDeleteTest()
        {
            usualTree.Delete(15);
            Assert.IsTrue(usualTree.IsBinarySearchTree);
            Assert.IsFalse(usualTree.Contains(15));
        }

        [TestMethod]
        public void SimpleDeleteTest()
        {
            listTree.Delete(7);
            Assert.IsTrue(listTree.IsBinarySearchTree);
            Assert.IsFalse(listTree.Contains(7));
        }

        [TestMethod]
        public void DeleteTest()
        {
            usualTree.Delete(5);
            Assert.IsTrue(usualTree.IsBinarySearchTree);
            Assert.IsFalse(usualTree.Contains(5));
        }
    }
}
