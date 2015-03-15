using System;

namespace Task4_1
{
    public class CalculateTree : Tree
    {
        /// <summary>
        /// Считаем бинарную операцию
        /// </summary>
        private static int Operation(char action, int operand1, int operand2)
        {
            if (!Symbol.IsOperation(action))
            {
                throw new IllegalSymbolsExpection("Illegal symbols.");
            }
            if (action == '+') return operand1 + operand2;
            if (action == '-') return operand1 - operand2;
            if (action == '*') return operand1 * operand2;
            if (operand2 == 0)
            {
                throw new DividingByZeroExpection("Dividing by zero.");             
            }
            return operand1 / operand2;            
        }

        /// <summary>
        /// Считаем выражение по дереву разбора
        /// </summary>
        public static int Calculate(Tree tree)
        {
            if (tree.Root == null)
            {
                throw new NullExpection("This object refers to null.");
            }
            return CalculateNode(tree.Root);
        }

        /// <summary>
        /// "Считаем" вершину
        /// </summary>
        private static int CalculateNode(Node node)
        {
            char symbol = node.Value[0];
            if (Symbol.IsOperation(symbol))
            {
                if (node.LeftSon == null || node.RightSon == null)
                {
                    throw new NullExpection("This object refers to null.");
                }
                int operand1 = CalculateNode(node.LeftSon);
                int operand2 = CalculateNode(node.RightSon);
                return Operation(symbol, operand1, operand2);
            }
            return Convert.ToInt32(node.Value);
        }
    }
}
