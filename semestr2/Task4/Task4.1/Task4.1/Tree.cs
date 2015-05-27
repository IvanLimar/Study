namespace Task4_1
{
    /// <summary>
    /// Дерево разбора арифметического выпажения. Может печататься и считаться
    /// </summary>
    public class Tree
    {
        private Node root;

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
