namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task2._2_2._3;

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
        public void TestLength()
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
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
            list.Add("12");
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void TestContains()
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
        public void TestDelete()
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
    }

    [TestClass]
    public class HashTableTest
    {
        HashTable hashTable;

        [TestInitialize]
        public void Init()
        {
            hashTable = new HashTable(100);
        }

        [TestMethod]
        public void AddContainsTest()
        {
            for (int i = 0; i < 1000; ++i)
            {
                string number = i.ToString();
                hashTable.Add(number);
                Assert.IsTrue(hashTable.Contains(number));
            }
            Assert.IsTrue(hashTable.Contains("523"));
            Assert.IsFalse(hashTable.Contains("-0"));
        }

        [TestMethod]
        public void AddDeleteContainsTest()
        {
            HashTable hashTable = new HashTable(100);
            for (int i = 0; i < 1000; ++i)
            {
                string number = i.ToString();
                hashTable.Add(number);
            }

            for (int i = 50; i < 100; ++i)
            {
                string number = i.ToString();
                hashTable.Delete(number);
                Assert.IsFalse(hashTable.Contains(number));
            }
        }
    }

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
        [ExpectedException(typeof(AddictionPresentValueException))]
        public void AddRepeatedValueTest()
        {
            const string line = "ololo";
            uniqueList.Add(line);
            uniqueList.Add(line);
        }

        [TestMethod]
        [ExpectedException(typeof(DeletingNotPresentValueException))]
        public void DeleteNotPresentValueTest()
        {
            const string line = "ololo";
            uniqueList.Add(line);
            uniqueList.Delete("AAA");
        }
    }
}
