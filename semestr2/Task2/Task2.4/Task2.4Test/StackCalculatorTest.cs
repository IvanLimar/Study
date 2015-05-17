using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2._4;

namespace Task2._4Test
{
    [TestClass]
    public class StackCalculatorTest
    {
        private StackArray<int> stackArray;
        private StackList<int> stackList;

        [TestInitialize]
        public void Init()
        {
            stackArray = new StackArray<int>();
            stackList = new StackList<int>();
        }

        [ExpectedException(typeof(DividingByZeroException))]
        [TestMethod]
        public void DivideByZeroTest()
        {
            StackCalculator.Calculate("2 0 /", stackArray);
            StackCalculator.Calculate("2 0 /", stackList);
        }

        [ExpectedException(typeof(WrongExpressionException))]
        [TestMethod]
        public void LettersInExpressionTest()
        {
            StackCalculator.Calculate("olo 1 1 +", stackArray);
            StackCalculator.Calculate("1 a 2 +", stackList);
        }

        [ExpectedException(typeof(WrongExpressionException))]
        [TestMethod]
        public void FewNumbersTest()
        {
            StackCalculator.Calculate("1 +", stackArray);
            StackCalculator.Calculate("2 +", stackList);
        }

        [ExpectedException(typeof(WrongExpressionException))]
        [TestMethod]
        public void ManyNumbersTest()
        {
            StackCalculator.Calculate("1 1 1 +", stackArray);
            StackCalculator.Calculate("2 1 1 +", stackList);
        }

        [TestMethod]
        public void StackCalculateTest()
        {
            Assert.AreEqual(StackCalculator.Calculate("21 10 - 73 60 * + 80 - 27 3 / +", stackArray), 4320);
            Assert.AreEqual(StackCalculator.Calculate("86 29 * 87 10 - 20 / +", stackList), 2497);
        }
    }
}
