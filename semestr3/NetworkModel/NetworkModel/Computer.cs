using System;

namespace NetworkModel
{
    /// <summary>
    /// Represents a model of computer.
    /// </summary>
    public class Computer
    {
        readonly private OperatingSystems operatingSytem;
        readonly private Random random;
        private bool isInfected;

        public OperatingSystems OperatingSystem
        {
            get 
            {
                return operatingSytem;
            }
        }

        /// <summary>
        /// Gets true, if computer is infected.
        /// </summary>
        public bool IsInfected
        {
            get
            {
                return isInfected;
            }
        }

        public Computer(OperatingSystems operatingSystem, bool isInfected)
        {
            this.operatingSytem = operatingSystem;
            this.isInfected = isInfected;
            random = new Random();
        }

        /// <summary>
        /// Tryes to infect computer.
        /// </summary>
        public void TryInfect(Func<OperatingSystems, double> probabilityFunction)
        {
            double temp = random.NextDouble();
            isInfected = temp < probabilityFunction(operatingSytem);
        }

    }
}
