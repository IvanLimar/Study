using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using Task4_1;

    [TestClass]
    public class PrintTest
    {
        private Tree tree;

        [TestInitialize]
        public void Init()
        {

            tree = new Tree();
        }
        [TestMethod]
        public void PrintTest1()
        {
            string expression = "(* 2 (+ 5 17))";
            ScanLine.Scan(ref tree, expression);
            string line = PrintTree.Print(tree);
            Assert.AreEqual(line, "( * 2 ( + 5 17 ) ) ");
        }
    }
}
