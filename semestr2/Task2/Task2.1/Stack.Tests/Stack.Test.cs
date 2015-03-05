
namespace Stack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task2._1;

    [TestClass]
    public class StackTest
    {
        private Stack stack;

        [TestInitialize]
        public void Initialize()
        {
           stack = new Stack();
        }

        [TestMethod]
        public void PopFromEmptyTest()
        {
            Assert.AreEqual(-9999, stack.Pop());
        }

        [TestMethod]
        public void PushPopTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
