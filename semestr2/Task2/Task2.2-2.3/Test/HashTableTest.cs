using System;
using TaskListHashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable;

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

        [TestMethod]
        public void ChangeHashTest()
        {
            Func<string, int> newHash = (string line) => { return line.Length; };
            hashTable.ChangeHash(newHash);
            Assert.AreEqual(hashTable.Function("olololo"), newHash("abababb"));
        }

        [TestMethod]
        public void RebuildTest()
        {
            for (int i = 0; i < 1000; ++i)
            {
                string number = i.ToString();
                hashTable.Add(number);
            }
            Func<string, int> newHash = (string line) => { return line.Length; };
            hashTable.ChangeHash(newHash);
            for (int i = 0; i < 1000; ++i)
            {
                Assert.IsTrue(hashTable.Contains(i.ToString()));
            }
        }
    }
}
