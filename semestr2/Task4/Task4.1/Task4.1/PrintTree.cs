using System;

namespace Task4_1
{
    public class PrintTree : Tree
    {
        /// <summary>
        /// Печать дерева разбора арифметического выражения
        /// </summary>
        public static string Print(Tree tree)
        {
            if (tree.Root == null)
            {
                throw new NullExpection("This object refers to null.");
            }
            string expression = "";
            PrintNode(tree.Root, ref expression);
            return expression;
        }

        /// <summary>
        /// Печать узла
        /// </summary>
        private static void PrintNode(Node node, ref string expression)
        {
            char symbol = node.Value[0];
            if (Symbol.IsOperation(symbol))
            {
                expression = expression + "( " + node.Value + " "; 
                Console.Write("( {0}", symbol);
                if (node.LeftSon == null || node.RightSon == null)
                {
                    throw new NullExpection("This object refers to null.");
                }
                PrintNode(node.LeftSon, ref expression);
                PrintNode(node.RightSon, ref expression);
                Console.Write(" ) ");
                expression = expression + ") "; 
                return;
            }
            Console.Write(" {0} ", node.Value);
            expression = expression + node.Value + " "; 
        }
    }
}
