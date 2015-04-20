using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ListFunctionTest
{
    using ListFunctions;
    [TestClass]
    public class ListFunctionTest
    {     
        private List<int> list;
        [TestInitialize]
        public void Init()
        {
            list = new List<int>() {15, 7, 9, 17, 83, 96, 37, 105, 130, 250};
        }

        [TestMethod]
        public void MapTest1()
        {
            List<int> result = ListMethods.Map(list, value => value * 0);
            foreach (int value in result)
            {
                Assert.AreEqual(value, 0);
            }
        }

        [TestMethod]
        public void MapTest2()
        {
            List<int> result = ListMethods.Map(list, value => value * 2 - 1);
            for (int i = 0; i < result.Count; ++i)
            {
                Assert.AreEqual(result[i], list[i] * 2 - 1);
            }
        }

        [TestMethod]
        public void FilterTest1()
        {
            List<int> result = ListMethods.Filter(list, value => value % 2 == 0);
            int firstValue = 96;
            int secondValue = 130;
            int thirdValue = 250;
            foreach (int value in result)
            {
                Assert.IsTrue(value == firstValue || value == secondValue || value == thirdValue);
            }
        }

        [TestMethod]
        public void FoldTest1()
        {
            int result = ListMethods.Fold(list, 0, (account, value) => account + value);
            Assert.AreEqual(result, 749);
        }
    }
}
