using System;

namespace Task4_1
{
    /// <summary>
    /// Дерево разбора арифметического выпажения. Может печататься и считаться
    /// </summary>
    public class Tree
    {
        private Node root;

        /// <summary>
        /// Класс узел. Может печататься и считаться.
        /// </summary>
        private abstract class Node
        {
            public abstract string Print();

            public abstract int Calculate();
        }

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

        private class NodeOperation : Node
        {
            private string operation;
            private Node leftSon;
            private Node rightSon;

            public NodeOperation(string[] values, ref int currentIndex)
            {
                operation = values[currentIndex++];
                for (int i = 0; i < 2; ++i)
                {
                    Node temp;
                    while (Symbol.IsBracket(values[currentIndex]))
                    {
                        ++currentIndex;
                    }
                    if (Symbol.IsOperation(values[currentIndex]))
                    {
                        temp = new NodeOperation(values, ref currentIndex);
                    }
                    else
                    {
                        temp = new NodeOperand(values, ref currentIndex);
                    }
                    if (i == 0)
                    {
                        leftSon = temp;
                    }
                    else
                    {
                        rightSon = temp;
                    }
                }
            }

            public override string Print()
            {
                string result = "";
                result = "( " + operation + " ";
                result = result + leftSon.Print();
                result = result + rightSon.Print();
                result = result + ") ";
                return result;
            }

            public override int Calculate()
            {
                int firstOperand = leftSon.Calculate();
                int secondOperand = rightSon.Calculate();
                int result = 0;
                switch (operation)
                {
                    case "+":
                        {
                            result = firstOperand + secondOperand;
                            break;
                        }
                    case "-":
                        {
                            result = firstOperand - secondOperand;
                            break;
                        }
                    case "*":
                        {
                            result = firstOperand * secondOperand;
                            break;
                        }
                    case "/":
                        {
                            if (secondOperand == 0)
                            {
                                throw new DividingByZeroException("Dividing by zero.");
                            }
                            result = firstOperand / secondOperand;
                            break;
                        }
                }
                return result;
            }
        }

        /// <summary>
        /// Строит дерево обхода арифметического выражения.
        /// Работает только с корректными expression.
        /// </summary>
        public Tree(string expression)
        {
            string[] values = expression.Split(' ');
            int currentIndex = 0;
            while (Symbol.IsBracket(values[currentIndex]))
            {
                ++currentIndex;
            }
            if (Symbol.IsOperation(values[currentIndex]))
            {
                root = new NodeOperation(values, ref currentIndex);
            }
            else
            {
                root = new NodeOperand(values, ref currentIndex);
            }
        }


        public int Calculate()
        {
            return root.Calculate();
        }

        public string Line()
        {
            return root.Print();
        }
    }
}
