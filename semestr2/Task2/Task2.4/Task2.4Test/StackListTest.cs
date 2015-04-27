using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2._4;

namespace Task2._4Test
{
    [TestClass]
    public class StackListTest
    {
        private StackList stack;

        [TestInitialize]
        public void Init()
        {
            stack = new StackList();
        }

        [ExpectedException(typeof(EmptyStackException))]
        [TestMethod]
        public void PopFromEmptyStackListTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void IsEmptyStackListTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsStackListTest()
        {
            for (int i = 0; i < 150; ++i)
            {
                stack.Push(i);
            }
            for (int i = 149; i >=0; --i)
            {
                Assert.AreEqual(stack.Pop(), i);
            }
        }
    }
}
