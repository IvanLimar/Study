using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyList;

namespace MyListTest
{
    [TestClass]
    public class MyListTest
    {
        private MyList<int> list;

        [TestInitialize]
        public void Init()
        {
            list = new MyList<int>() { 0, 1, 2, 3, 4 };
        }

        [TestMethod]
        public void GetTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(i, list[i]);
            }
        }

        [TestMethod]
        public void SetTest()
        {
            for (int i = 5; i < 10; ++i)
            {
                list[i - 5] = i;
                Assert.AreEqual(list[i - 5], i);
            }
        }

        [TestMethod]
        public void AddTest()
        {
            for (int i = 5; i < 10; ++i)
            {
                list.Add(i);
            }
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(i, list[i]);
            }
        }

        [TestMethod]
        public void InsertToBeginTest()
        {
            list.Insert(0, -1);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], i - 1);
            }
        }

        [TestMethod]
        public void InsertToEndTest()
        {
            list.Insert(list.Count, 5);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], i);
            }
        }

        [TestMethod]
        public void InsertToMiddleTest()
        {
            list.Insert(2, 2);
            for (int i = 0; i < 3; ++i)
            {
                Assert.AreEqual(list[i], i);
            }
            for (int i = 3; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], i - 1);
            }
        }

        [TestMethod]
        public void IndexOfTest()
        {
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(i, list.IndexOf(i));
            }
            Assert.AreEqual(-1, list.IndexOf(10));
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.IsTrue(list.Contains(i));
            }
            Assert.IsFalse(list.Contains(10));
        }

        [TestMethod]
        public void CopyToTest()
        {
            int[] array = new int[list.Count];
            list.CopyTo(array, 0);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(array[i], i);
            }
        }

        [TestMethod]
        public void RemoveAtBeginTest()
        {
            list.RemoveAt(0);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], i + 1);
            }
        }

        [TestMethod]
        public void RemoveAtEndTest()
        {
            list.RemoveAt(list.Count - 1);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], i);
            }
        }

        [TestMethod]
        public void RemoveAtMiddleTest()
        {
            int temp = list.Count - 1;
            for (int i = 1; i < temp; ++i)
            {
                list.RemoveAt(1);
            }
            Assert.AreEqual(list[0], 0);
            Assert.AreEqual(list[1], 4);
        }

        [TestMethod]
        public void ClearTest()
        {
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            list.Remove(0);
            Assert.AreEqual(list.Count, 4);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(list[i], i + 1);
            }
        }

        [TestMethod]
        public void ForeachTest()
        {
            int i = -1;
            foreach (int x in list)
            {
                Assert.AreEqual(x, ++i);
            }
        }
    }
}
