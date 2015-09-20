using System.Collections.Generic;
using System.Collections;
using System;

namespace BinarySearchTree
{
    /// <summary>
    /// Represents binary search tree with T values.
    /// </summary>
    public class BinarySearchTree<T> : IEnumerable where T : IComparable
    {
        private Node root;
        /// <summary>
        /// Binary search tree's node.
        /// </summary>
        private class Node
        {
            public T Value { get; set; }
            public Node LeftSon { get; set; }
            public Node RightSon { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public void AddValue(T value)
            {
                int temp = value.CompareTo(Value);
                if (temp == 0)
                {
                    return;
                }
                if (temp > 0)
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
        /// Adds a value to binary search tree.
        /// </summary>
        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }
            root.AddValue(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) new Enumerator(this);
        }

        /// <summary>
        /// Iterator. Uses depth-first search.
        /// </summary>
        private class Enumerator : IEnumerator
        {
            private List<T> nodeList = new List<T>();
            private int index = -1;

            /// <summary>
            /// Adds values to nodeList, when enumerator creates.
            /// </summary>
            private void NodeList(List<T> nodeList, Node currentNode)
            {
                nodeList.Add(currentNode.Value);
                if (currentNode.LeftSon != null)
                {
                    NodeList(nodeList, currentNode.LeftSon);
                }
                if (currentNode.RightSon != null)
                {
                    NodeList(nodeList, currentNode.RightSon);
                }
            }

            public Enumerator(BinarySearchTree<T> tree)
            {
                if (tree.root != null)
                {
                    NodeList(nodeList, tree.root);
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

            public T Current
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
