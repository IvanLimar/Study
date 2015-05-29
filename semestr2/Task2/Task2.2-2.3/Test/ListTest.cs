using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskListHashTable;

namespace Test
{
    [TestClass]
    public class ListTest
    {
        private List list;
        [TestInitialize]
        public void Init()
        {
            list = new List();
        }

        [TestMethod]
        public void LengthTest()
        {
            string ololo = "olololo";
            Assert.AreEqual(0, list.Length());
            list.Add(ololo);
            Assert.AreEqual(1, list.Length());
            list.Add("zazazza");
            Assert.AreEqual(2, list.Length());
            list.Delete(ololo);
            Assert.AreEqual(1, list.Length());
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
            list.Add("12");
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i.ToString());
            }
            Assert.IsTrue(list.Contains("0"));
            Assert.IsTrue(list.Contains("9"));
            Assert.IsTrue(list.Contains("5"));
            Assert.IsFalse(list.Contains("-1"));
        }

        [TestMethod]
        public void DeleteTest()
        {

            for (int i = 0; i < 10; ++i)
            {
                list.Add(i.ToString());
            }
            Assert.IsTrue(list.Contains("0"));
            list.Delete("0");
            Assert.IsFalse(list.Contains("0"));

            Assert.IsTrue(list.Contains("5"));
            list.Delete("5");
            Assert.IsFalse(list.Contains("5"));

            Assert.IsTrue(list.Contains("9"));
            list.Delete("9");
            Assert.IsFalse(list.Contains("9"));
        }

        [ExpectedException(typeof(NonExistentValueDeleteException))]
        [TestMethod]
        public void NonExistentValueDeleteTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i.ToString());
            }
            list.Delete("-1");
            list.Delete("ololol");
        }

        [TestMethod]
        public void GetValueTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i.ToString());
            }
            for (int i = 0; i < 10; ++i)
            {
                Assert.AreEqual(i.ToString(), list.GetValue(i));
            }
        }
    }
}
