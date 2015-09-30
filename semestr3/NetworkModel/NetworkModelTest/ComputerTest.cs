using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkModelTest
{
    using NetworkModel;
    [TestClass]
    public class ComputerTest
    {
        [TestMethod]
        public void InfectTestOne()
        {
            Computer computer = new Computer(OperatingSystems.Windows, (x) => { return 1; }, false);
            computer.TryInfect();
            Assert.IsTrue(computer.IsInfected);
        }

        [TestMethod]
        public void InfectTestTwo()
        {
            Computer computer = new Computer(OperatingSystems.Mac, (x) => { return 0; }, false);
            for (int i = 0; i < 100; ++i)
            {
                computer.TryInfect();
                Assert.IsFalse(computer.IsInfected);
            }
        }

        [TestMethod]
        public void CompicatedInfectTest()
        {
            Func<OperatingSystems, double> function = (x) =>
                {
                    switch (x)
                    {
                        case OperatingSystems.Lunix:
                            return 0;
                        case OperatingSystems.Mac:
                            return 1;
                        case OperatingSystems.Windows:
                            return 0;
                        default:
                            break;
                    }
                    return 0;
                };
            Computer windows = new Computer(OperatingSystems.Windows, function, false);
            Computer mac = new Computer(OperatingSystems.Mac, function, false);
            Computer lunix = new Computer(OperatingSystems.Lunix, function, false);
            mac.TryInfect();
            for (int i = 0; i < 99; ++i)
            {
                lunix.TryInfect();
                windows.TryInfect();
            }
            Assert.IsFalse(lunix.IsInfected);
            Assert.IsFalse(windows.IsInfected);
            Assert.IsTrue(mac.IsInfected);
        }

        [TestMethod]
        public void ChangeProbabilityFunctionTest()
        {
            Computer comp = new Computer(OperatingSystems.Mac, (x) => {return 0;}, false);
            comp.TryInfect();
            Assert.IsFalse(comp.IsInfected);
            comp.ChangeProbalilityFunction((x) => { return 1; });
            comp.TryInfect();
            Assert.IsTrue(comp.IsInfected);
        }
    }
}
