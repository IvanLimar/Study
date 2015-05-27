using Task4_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TreeTest
    {
        private Tree test1;
        private Tree test3;
        private Tree test2;

        [TestInitialize]
        public void Init()
        {
            test1 = new Tree("( + 20 ( * 5 3 ) )");
            test2 = new Tree("( * ( + 2 3 ) ( / 6 2 ) )");
            test3 = new Tree("( / 2 0 )");
        }

        [TestMethod]
        public void LineTest()
        {
            Assert.AreEqual(test1.Line(), "( + 20 ( * 5 3 ) ) ");
            Assert.AreEqual(test2.Line(), "( * ( + 2 3 ) ( / 6 2 ) ) ");
            Assert.AreEqual(test3.Line(), "( / 2 0 ) ");
        }

        [ExpectedException(typeof(DividingByZeroException))]
        [TestMethod]
        public void DivideByZeroTest()
        {
            test3.Calculate();
        }

        [TestMethod]
        public void CalculateTest()
        {
            Assert.AreEqual(test1.Calculate(), 35);
            Assert.AreEqual(test2.Calculate(), 15);
        }
    }
}
