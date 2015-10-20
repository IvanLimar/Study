using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetworkModelTest
{
    using NetworkModel;
    
    [TestClass]
    public class NetworkTest
    {
        private const int size = 5;
        private bool[,] network = new bool[size, size] { {true, true, true, true, false},
                                                         {true, true, true, false, true},
                                                         {true, true, true, true, true},
                                                         {true, false, true, true, true},
                                                         {false, true, true, true, true} };
        [TestMethod]
        public void NoInfectedTest()
        {
            const int quantityOfComputers = 5;
            const int zero = 0;

            List<Computer> computers = new List<Computer>();
            for (int i = zero; i < quantityOfComputers; ++i)
            {
                computers.Add(new Computer(OperatingSystems.Windows, false));
            }
            Network net = new Network(network, computers, (x) => { return zero; });
            const int hundred = 100;
            for (int i = zero; i < hundred; ++i)
            {
                net.MakeTurn();
            }
            Assert.IsTrue(net.InfectedComputers.Count == zero);
        }

        [TestMethod]
        public void AllInfectedTest()
        {
            const int one = 1;
            Func<OperatingSystems, double> temp = (x) => { return one; };
            Computer infectedComputer = new Computer(OperatingSystems.Windows, true);
            List<Computer> computers = new List<Computer>();
            const int four = 4;
            const int zero = 0;
            computers.Add(infectedComputer);
            for (int i = zero; i < four; ++i)
            {
                computers.Add(new Computer(OperatingSystems.Mac, false));
            }
            Network net = new Network(network, computers, temp);
            Assert.IsTrue(net.InfectedComputers.Count == one);
            net.MakeTurn();
            Assert.IsTrue(net.InfectedComputers.Count == four);
            net.MakeTurn();
            const int five = 5;
            Assert.IsTrue(net.InfectedComputers.Count == five);
        }

        [TestMethod]
        public void SomeInfectedTest()
        {
            const int one = 1;
            const int zero = 0;
            Func<OperatingSystems, double> function = (x) =>
                {
                    if (x == OperatingSystems.Lunix)
                    {
                        return zero;
                    }
                    else
                    {
                        return one;
                    }
                };
            List<Computer> computers = new List<Computer>();
            computers.Add(new Computer(OperatingSystems.Windows, true));
            const int two = 2;
            for (int i = zero; i < two; ++i)
            {
                computers.Add(new Computer(OperatingSystems.Lunix, false));
            }
            computers.Add(new Computer(OperatingSystems.Windows, false));
            computers.Add(new Computer(OperatingSystems.Mac, false));

            Network net = new Network(network, computers, function);
            Assert.IsTrue(net.InfectedComputers.Count == one);
            net.MakeTurn();
            Assert.IsTrue(net.InfectedComputers.Count == two);
            net.MakeTurn();
            const int three = 3;
            Assert.IsTrue(net.InfectedComputers.Count == three);
        }

    }
}
