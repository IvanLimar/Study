using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriorityQueueTest
{
    using PriorityQueue;
    [TestClass]
    public class PriorityQueueTest
    {
        private PriorityQueue queue;

        [TestInitialize]
        public void Init()
        {
            queue = new PriorityQueue();
        }

        [ExpectedException(typeof(NullExpection))]
        [TestMethod]
        public void DequeueFromEmptyTest()
        {
            queue.Dequeue();
        }

        [TestMethod]
        public void IsQueueTest()
        {
            queue.Enqueue(5, 1);
            queue.Enqueue(4, 1);
            queue.Enqueue(3, 1);
            Assert.AreEqual(queue.Dequeue(), 5);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 3);
        }

        [TestMethod]
        public void IsPriorityQueueTest()
        {
            queue.Enqueue(1, 9);
            queue.Enqueue(2, 8);
            queue.Enqueue(3, 7);
            queue.Enqueue(4, 10);
            queue.Enqueue(5, 7);
            queue.Enqueue(6, 10);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 5);
        }
    }
}
