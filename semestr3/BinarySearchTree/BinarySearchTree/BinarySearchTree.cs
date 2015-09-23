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
        /// Gets true if tree is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return root == null;
            }
        }

        /// <summary>
        /// Gets true if tree is normal
        /// </summary>
        public bool IsBinarySearchTree
        {
            get
            {
                if (root != null)
                {
                    return root.IsNormalNode();
                }
                return true;
            }
        }

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

            public bool ContainsValue(T value)
            {
                int temp = value.CompareTo(Value);
                if (temp == 0)
                {
                    return true;
                }
                if (temp > 0)
                {
                    if (RightSon == null)
                    {
                        return false;
                    }
                    else
                    {
                        return RightSon.ContainsValue(value);
                    }
                }
                else
                {
                    if (LeftSon == null)
                    {
                        return false;
                    }
                    else
                    {
                        return LeftSon.ContainsValue(value);
                    }
                }
            }

            public void DeleteValue(ref Node parent, T value)
            {
                int temp = value.CompareTo(Value);
                if (temp == 0)
                {
                    bool isRightSon = parent.RightSon == this;
                    if (RightSon == null)
                    {
                        if (LeftSon == null)
                        {
                            if (isRightSon)
                            {
                                parent.RightSon = null;
                            }
                            else
                            {
                                parent.LeftSon = null;
                            }
                        }
                        else
                        {
                            if (isRightSon)
                            {
                                parent.RightSon = LeftSon;
                            }
                            else
                            {
                                parent.LeftSon = LeftSon;
                            }
                        }
                    }
                    else
                    {
                        if (LeftSon == null)
                        {
                            if (isRightSon)
                            {
                                parent.RightSon = RightSon;
                            }
                            else
                            {
                                parent.LeftSon = RightSon;
                            }
                        }
                        else
                        {
                            Node leftNode = RightSon.leftNode();
                            T swaper = Value;
                            Value = leftNode.Value;
                            leftNode.Value = swaper;
                            parent = this;
                            LeftSon.DeleteValue(ref parent, value);
                        }
                    }
                    return;
                }

                parent = this;
                if (temp > 0)
                {
                    if (RightSon != null)
                    {
                        RightSon.DeleteValue(ref parent, value);
                    }
                }
                else
                {
                    if (LeftSon != null)
                    {
                        LeftSon.DeleteValue(ref parent, value);
                    }
                }
            }

            private Node leftNode()
            {
                if (LeftSon != null)
                {
                    return LeftSon.leftNode();
                }
                return this;
            }

            public bool IsNormalNode()
            {
                if (RightSon == null)
                {
                    if (LeftSon == null)
                    {
                        return true;
                    }
                    return Value.CompareTo(LeftSon.Value) > 0 && LeftSon.IsNormalNode();
                }
                else
                {
                    if (LeftSon == null)
                    {
                        return Value.CompareTo(RightSon.Value) < 0 && RightSon.IsNormalNode();
                    }
                    return Value.CompareTo(LeftSon.Value) > 0 && Value.CompareTo(RightSon.Value) < 0 && LeftSon.IsNormalNode() && RightSon.IsNormalNode();
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

        /// <summary>
        /// Returns true if value is in tree.
        /// </summary>
        public bool Contains(T value)
        {
            if (root != null)
            {
                return root.ContainsValue(value);
            }
            return false;
        }

        /// <summary>
        /// Deletes value from tree.
        /// </summary>
        public void Delete(T value)
        {
            if (root != null)
            {
                Node temp = new Node(default(T));
                temp.RightSon = root;
                Node parent = temp;
                root.DeleteValue(ref parent, value);
                root = temp.RightSon;
            }
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
