using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2._4;

namespace Task2._4Test
{
    [TestClass]
    public class StackArrayTest
    {
        private StackArray<int> stack;

        [TestInitialize]
        public void Init()
        {
            stack = new StackArray<int>();
        }

        [ExpectedException(typeof(EmptyStackException))]
        [TestMethod]
        public void PopFromEmptyStackArrayTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void IsEmptyStackArrayTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsStackArrayTest()
        {
            for (int i = 0; i < 150; ++i)
            {
                stack.Push(i);
            }
            for (int i = 149; i >= 0; --i)
            {
                Assert.AreEqual(stack.Pop(), i);
            }
        }
    }
}
