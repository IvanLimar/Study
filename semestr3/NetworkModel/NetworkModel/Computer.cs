using System;

namespace NetworkModel
{
    /// <summary>
    /// Represents a model of computer.
    /// </summary>
    public class Computer
    {
        private OperatingSystems operatingSytem;
        private Func<OperatingSystems, double> probabilityFunction;
        private bool isInfected;
        private Random random;

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

        public Computer(OperatingSystems operatingSystem, Func<OperatingSystems, double> probabilityFunction, bool isInfected)
        {
            this.operatingSytem = operatingSystem;
            ChangeProbalilityFunction(probabilityFunction);
            this.isInfected = isInfected;
            random = new Random();
        }

        /// <summary>
        /// Tryes to infect computer.
        /// </summary>
        public void TryInfect()
        {
            double temp = random.NextDouble();
            isInfected = temp < probabilityFunction(operatingSytem);
        }

        /// <summary>
        /// Changes the function, which inluences to probability of infection.
        /// </summary>
        public void ChangeProbalilityFunction(Func<OperatingSystems, double> newFunction)
        {
            this.probabilityFunction = (x) =>
            {
                double temp = newFunction(operatingSytem);
                if (temp == 1)
                {
                    return 1;
                }
                if (temp == 0)
                {
                    return 0;
                }
                return temp - Math.Truncate(temp);
            };
        }
    }
}
