using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using Task4_1;

    [TestClass]
    public class NodeTest : Tree
    {
        private Node node;

        [TestInitialize]
        public void init()
        {
            node = new Node();
        }

        [TestMethod]
        public void NodSonsTest()
        {
            Assert.IsNotNull(node);
            Assert.IsNull(node.LeftSon);
            Assert.IsNull(node.RightSon);
        }

        [TestMethod]
        public void CreateSonsTest()
        {
            node.RightSon = new Node();
            node.CreateSons();
            Assert.IsNull(node.LeftSon);
            node.RightSon.CreateSons();
            Assert.IsNotNull(node.RightSon.LeftSon);
            Assert.IsNotNull(node.RightSon.LeftSon);
        }

        [TestMethod]
        public void ValueTest()
        {
            node.AddValue("z");
            Assert.AreEqual(node.Value, "z");
            Assert.AreNotEqual(node.Value, "");
        }
    }
}
