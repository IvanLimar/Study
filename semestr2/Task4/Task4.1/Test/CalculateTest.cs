using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using Task4_1;

    [TestClass]
    public class CalculateTest
    {
        private Tree tree;

        [TestInitialize]
        public void init()
        {
            tree = new Tree();
        }

        [ExpectedException(typeof(DividingByZeroExpection))]
        [TestMethod]
        public void DivideDyZeroTest()
        {
            string expression = "(/ 2 0)";
            ScanLine.Scan(ref tree, expression);
            CalculateTree.Calculate(tree);
        }

        [TestMethod]
        public void CalculateTest1()
        {
            string expression = "(* 2 (+ 5 17))";
            ScanLine.Scan(ref tree, expression);
            Assert.AreEqual(CalculateTree.Calculate(tree), 44);
        }
    }
}
