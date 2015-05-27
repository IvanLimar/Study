using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Set;

namespace SetTest
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void AddTest()
        {
            var expected = new Set<int>();
            for (int i = 0; i < 3; ++i)
            {
                expected.Add(i);
            }
            int actual = -1;
            foreach (var x in expected)
            {
                ++actual;
                Assert.AreEqual(x, actual);
            }
        }

        [TestMethod]
        public void ContainsTest()
        {
            var set = new Set<int>() {0, 1, 2, 3, 4};
            for (int i = 0; i < 5; ++i)
            {
                Assert.IsFalse(set.Contains(-i - 1));
                Assert.IsTrue(set.Contains(i));
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            var set = new Set<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 10; ++i)
            {
                set.Delete(i);
            }
            for (int i = 0; i < 10; ++i)
            {
                Assert.IsFalse(set.Contains(i));
            }
        }

        [TestMethod]
        public void UnionTest()
        {
            var firstSet = new Set<int>() { 0, 1, 2, 3, 4 };
            var secondSet = new Set<int>() { 5, 6, 7 };
            var unitedSet = Set<int>.Union(firstSet, secondSet);
            int actual = -1;
            foreach (var x in unitedSet)
            {
                ++actual;
                Assert.AreEqual(x, actual);
            }
        }

        [TestMethod]
        public void IntersectionTest()
        {
            var firstSet = new Set<int>() { 0, 1, 2, 3, 4, 5};
            var secondSet = new Set<int>() { 5, 6, 7 };
            var result = Set<int>.Intersection(firstSet, secondSet);
            foreach (var x in result)
            {
                int actual = 5;
                Assert.AreEqual(x, actual);
            }
        }
    }
}
