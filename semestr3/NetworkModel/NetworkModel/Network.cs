using System.Collections.Generic;
using System;

namespace NetworkModel
{
    /// <summary>
    /// Represens a model of network.
    /// </summary>
    public class Network
    {
        private List<Computer> computers;
        private List<int> infectedComputers;
        private Func<OperatingSystems, double> probabilityFunction;
        readonly private bool[,] network;

        /// <summary>
        /// Gets numbers of infected computers.
        /// </summary>
        public List<int> InfectedComputers
        {
            get
            {
                return infectedComputers;
            }
        }

        public Network(bool[,] network, List<Computer> computers, Func<OperatingSystems, double> probabilityFunction)
        {
            this.network = network;
            this.computers = computers;
            this.probabilityFunction = probabilityFunction;
            infectedComputers = new List<int>();
            const int zero = 0;
            for (int i = zero; i < computers.Count; ++i)
            {
                UpdateList(ref infectedComputers, i);
            }
        }

        /// <summary>
        /// Infected computers try to infect "neighbour" computers.
        /// </summary>
        public void MakeTurn()
        {
            List<int> infectedComputersAtThisTurn = new List<int>();
            const int zero = 0;
            for (int i = zero; i < computers.Count; ++i)
            {
                if (computers[i].IsInfected && !infectedComputersAtThisTurn.Contains(i))
                {
                    for (int j = zero; j < computers.Count; ++j)
                    {
                        if (i != j && network[i, j] && !computers[j].IsInfected)
                        {
                            computers[j].TryInfect(probabilityFunction);
                            UpdateList(ref infectedComputers, j);
                            UpdateList(ref infectedComputersAtThisTurn, j);
                        }
                    }
                }               
            }
        }

        private void UpdateList(ref List<int> list ,int index)
        {
            if (computers[index].IsInfected && !list.Contains(index))
            {
                list.Add(index);
            }
        }

    }
}
