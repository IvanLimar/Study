using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    public partial class Tree
    {
        /// <summary>
        /// Операнд. Может считаться и печататься
        /// </summary>
        private class NodeOperand : Node
        {
            private int operand;

            public NodeOperand(string[] values, ref int currentIndex)
            {
                operand = Int32.Parse(values[currentIndex++]);
            }

            public override string Print()
            {
                return operand.ToString() + " ";
            }

            public override int Calculate()
            {
                return operand;
            }
        }
    }
}
