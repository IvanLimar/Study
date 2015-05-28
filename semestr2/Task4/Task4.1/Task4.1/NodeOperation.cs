namespace Task4_1
{
    /// <summary>
    /// Операция. Может считаться и печататься
    /// </summary>
    public class NodeOperation : Node
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
}
