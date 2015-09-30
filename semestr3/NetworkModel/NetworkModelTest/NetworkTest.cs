using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetworkModelTest
{
    using NetworkModel;
    
    [TestClass]
    public class NetworkTest
    {
        private bool[,] network = new bool[5, 5] { {true, true, true, true, false},
                                                   {true, true, true, false, true},
                                                   {true, true, true, true, true},
                                                   {true, false, true, true, true},
                                                   {false, true, true, true, true} };
        [TestMethod]
        public void NoInfectedTest()
        {
            Computer computer = new Computer(OperatingSystems.Lunix, (x) => { return 0; }, false);
            Network net = new Network(network, new List<Computer> { computer, computer, computer, computer, computer });
            for (int i = 0; i < 100; ++i)
            {
                net.MakeTurn();
            }
            Assert.IsTrue(net.InfectedComputers.Count == 0);
        }

        [TestMethod]
        public void AllInfectedTest()
        {
            Func<OperatingSystems, double> temp = (x) => { return 1; };
            Computer infectedComputer = new Computer(OperatingSystems.Windows, temp, true);
            Computer computer = new Computer(OperatingSystems.Mac, temp, false);
            Network net = new Network(network, new List<Computer> { infectedComputer, computer, computer, computer, computer });
            Assert.IsTrue(net.InfectedComputers.Count == 1);
            net.MakeTurn();
            Assert.IsTrue(net.InfectedComputers.Count == 5);
        }

    }
}
