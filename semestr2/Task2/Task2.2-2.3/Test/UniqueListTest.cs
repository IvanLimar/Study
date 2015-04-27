using System;
using TaskListHashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UniqueListTest
    {
        private UniqueList uniqueList;

        [TestInitialize]
        public void Init()
        {
            uniqueList = new UniqueList();
        }

        [TestMethod]
        public void UniqueListLengthTest()
        {
            string ololo = "olololo";
            Assert.AreEqual(0, uniqueList.Length());
            uniqueList.Add(ololo);
            Assert.AreEqual(1, uniqueList.Length());
            uniqueList.Add("zazazza");
            Assert.AreEqual(2, uniqueList.Length());
            uniqueList.Delete(ololo);
            Assert.AreEqual(1, uniqueList.Length());
        }

        [TestMethod]
        public void UniqueListIsEmptyTest()
        {
            Assert.IsTrue(uniqueList.IsEmpty());
            uniqueList.Add("12");
            Assert.IsFalse(uniqueList.IsEmpty());
        }

        [TestMethod]
        public void UniqueListContainsTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                uniqueList.Add(i.ToString());
            }
            Assert.IsTrue(uniqueList.Contains("0"));
            Assert.IsTrue(uniqueList.Contains("9"));
            Assert.IsTrue(uniqueList.Contains("5"));
            Assert.IsFalse(uniqueList.Contains("-1"));
        }

        [TestMethod]
        public void UniqueListDeleteTest()
        {

            for (int i = 0; i < 10; ++i)
            {
                uniqueList.Add(i.ToString());
            }
            Assert.IsTrue(uniqueList.Contains("0"));
            uniqueList.Delete("0");
            Assert.IsFalse(uniqueList.Contains("0"));

            Assert.IsTrue(uniqueList.Contains("5"));
            uniqueList.Delete("5");
            Assert.IsFalse(uniqueList.Contains("5"));

            Assert.IsTrue(uniqueList.Contains("9"));
            uniqueList.Delete("9");
            Assert.IsFalse(uniqueList.Contains("9"));
        }

        [TestMethod]
        [ExpectedException(typeof(RepeatedValueAddExpception))]
        public void AddRepeatedValueTest()
        {
            const string line = "ololo";
            uniqueList.Add(line);
            uniqueList.Add(line);
        }

        [TestMethod]
        [ExpectedException(typeof(NonExistentValueDeleteException))]
        public void DeleteNotPresentValueTest()
        {
            const string line = "ololo";
            uniqueList.Add(line);
            uniqueList.Delete("AAA");
        }
    }
}
