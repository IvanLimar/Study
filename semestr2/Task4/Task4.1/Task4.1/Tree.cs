using System;

namespace Task4_1
{
    /// <summary>
    /// Класс дерево.
    /// </summary>
    public class Tree
    {
        public Node Root { get; set; }

        /// <summary>
        /// Класс узел.
        /// </summary>
        public class Node
        {
            public Node LeftSon { get; set; }
            public Node RightSon { get; set; }
            public string Value { get; set; }

            public Node()
            {
                LeftSon = null;
                RightSon = null;
            }

            /// <summary>
            /// В данный узел заносим value
            /// </summary>
            public void AddValue(string value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Если узел не имеет потомков, создаем сыновей.
            /// </summary>
            public void CreateSons()
            {
                if (this.LeftSon != null || this.RightSon != null)
                {
                    return;
                }
                this.LeftSon = new Node();
                this.RightSon = new Node();
            }      
        }

        public Tree()
        {
            Root = new Node();
        }
    }
}
