using System;

namespace Task4_1
{
    public class ScanLine : Tree
    {
        /// <summary>
        /// Строим дерево разбора арифмитического выражения.
        /// </summary>
        public static void Scan(ref Tree tree, string expression)
        {
            if (tree.Root == null)
            {
                throw new NullExpection("This object refers to null.");
            }
            string[] symbols = expression.Split(' ');
            Node node = tree.Root;
            int index = 0;
            ScanSymbol(ref node, symbols, ref index);
        }

        /// <summary>
        /// Заносим число или знак операции в узел.
        /// </summary>
        private static void ScanSymbol(ref Node node, string[] expression, ref int index)
        {
            if (index < 0 || index >= expression.Length)
            {
                throw new OutBorderArrayExpection("Illegal index of array.");
            }
            string value = expression[index++].Trim('(', ')');
            while (value == "")
            {
                value = expression[index++].Trim('(', ')');
            }
            node.AddValue(value);
            char symbol = value[0];
            if (Symbol.IsOperation(symbol))
            {
                node.CreateSons();
                Node leftSon = node.LeftSon;
                ScanSymbol(ref leftSon, expression, ref index);
                Node rightSon = node.RightSon;
                ScanSymbol(ref rightSon, expression, ref index);
            }
        }
    }
}
