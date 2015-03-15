using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using Task4_1;

    [TestClass]
    public class ScanLineTest
    {
        private Tree tree;

        [TestInitialize]
        public void Init()
        {
            tree = new Tree();
        }

        [TestMethod]
        public void ScanTest1()
        {
            string expression = "(* 2 (+ 5 17))";
            ScanLine.Scan(ref tree, expression);
            Assert.AreEqual("*", tree.Root.Value);
            Assert.AreEqual("2", tree.Root.LeftSon.Value);
            Assert.AreEqual("+", tree.Root.RightSon.Value);
            Assert.AreEqual("5", tree.Root.RightSon.LeftSon.Value);
            Assert.AreEqual("17", tree.Root.RightSon.RightSon.Value);
        }

    }
}
