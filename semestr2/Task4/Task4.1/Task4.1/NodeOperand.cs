using System;

namespace Task4_1
{
    /// <summary>
    /// Операнд. Может считаться и печататься
    /// </summary>
    public class NodeOperand : Node
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
