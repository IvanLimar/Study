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
        private bool[,] network;
        private List<int> infectedComputers;

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

        public Network(bool[,] network, List<Computer> computers)
        {
            this.network = network;
            this.computers = computers;
            infectedComputers = new List<int>();
            for (int i = 0; i < computers.Count; ++i)
            {
                UpdateInfectedList(i);
            }
        }

        /// <summary>
        /// Infected computers try to infect "neighbour" computers.
        /// </summary>
        public void MakeTurn()
        {
            for (int i = 0; i < computers.Count; ++i)
            {
                if (computers[i].IsInfected)
                {
                    for (int j = 0; j < computers.Count; ++j)
                    {
                        if (i != j && network[i, j])
                        {
                            computers[j].TryInfect();
                            UpdateInfectedList(j);
                        }
                    }
                }               
            }
        }

        private void UpdateInfectedList(int index)
        {
            if (computers[index].IsInfected && !infectedComputers.Contains(index))
            {
                infectedComputers.Add(index);
            }
        }

    }
}
