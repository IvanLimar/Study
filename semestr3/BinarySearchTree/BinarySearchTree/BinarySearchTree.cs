using System.Collections.Generic;
using System.Collections;

namespace BinarySearchTree
{
    /// <summary>
    /// Represents binary search tree with integer numbers.
    /// </summary>
    public class BinarySearchTree : IEnumerable
    {
        private Node root = null;

        /// <summary>
        /// Binary search tree's node.
        /// </summary>
        private class Node
        {
            public int Value { get; set; }
            public Node LeftSon { get; set; }
            public Node RightSon { get; set; }

            public Node(int value)
            {
                LeftSon = null;
                RightSon = null;
                Value = value;
            }

            public void AddValue(int value)
            {
                if (Value == value)
                {
                    return;
                }
                if (value > Value)
                {
                    if (RightSon == null)
                    {
                        RightSon = new Node(value);
                    }
                    else
                    {
                        RightSon.AddValue(value);
                    }
                }
                else
                {
                    if (LeftSon == null)
                    {
                        LeftSon = new Node(value);
                    }
                    else
                    {
                        LeftSon.AddValue(value);
                    }
                }
            }

        }

        /// <summary>
        /// Adds values to nodeList, when enumerator creates.
        /// </summary>
        private void NodeList(ref List<int> nodeList, Node currentNode)
        {
            nodeList.Add(currentNode.Value);
            if (currentNode.LeftSon != null)
            {
                NodeList(ref nodeList, currentNode.LeftSon);
            }
            if (currentNode.RightSon != null)
            {
                NodeList(ref nodeList, currentNode.RightSon);
            }
        }

        /// <summary>
        /// Adds a value to binary search tree.
        /// </summary>
        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }
            root.AddValue(value);
        }

        private Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        /// <summary>
        /// Iterator. Uses depth-first search.
        /// </summary>
        private class Enumerator : IEnumerator
        {
            private List<int> nodeList = new List<int>();
            private int index = -1;

            public Enumerator(BinarySearchTree tree)
            {
                if (tree.root != null)
                {
                    tree.NodeList(ref nodeList, tree.root);
                }             
            }

            public bool MoveNext()
            {
                index++;
                return index < nodeList.Count;
            }

            public void Reset()
            {
                index = -1;
            }

            public int Current
            {
                get
                {
                    return nodeList[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
        }
    }
}
