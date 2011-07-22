using System;
using System.Diagnostics;

namespace Aads.Trees {
    public class BinarySearchTree<T> where T : IComparable<T> {

        #region Fields

        private Node _root;

        #endregion

        #region Insertion

        public void Add(T value) {
            if (_root == null) {
                CreateRoot(value);
                return;
            }
            Node parent = null;
            Node current = _root;
            while (current != null) {
                parent = current;
                current = value.CompareTo(current.Value) < 0 ? current.Left : current.Right;
            }
            var newNode = new Node { Value = value, Parent = parent };
            if (value.CompareTo(parent.Value) < 0) {
                parent.Left = newNode;
            }
            else {
                parent.Right = newNode;
            }
        }

        private void CreateRoot(T value) {
            _root = new Node { Value = value };
        }

        #endregion

        #region Deletion

        public void Remove(T value) {
            var node = FindNode(value);
            if (node == null) return;
            if (node.IsLeaf) {
                Transplant(node, null);
            }
            else if (node.Left != null && node.Right == null) {
                Transplant(node, node.Left);
            }
            else if (node.Left == null && node.Right != null) {
                Transplant(node, node.Right);
            }
            else {
                //node has both left and right
                Node successor = FindMinimum(node.Right);
                if (!ReferenceEquals(node, successor.Parent)) {
                    Transplant(successor, successor.Right);
                    successor.Right = node.Right;
                    successor.Right.Parent = successor;
                }
                successor.Left = node.Left;
                successor.Left.Parent = successor;
                if (node.IsRoot) {
                    _root = successor;
                    successor.Parent = null;
                }
                else {
                    successor.Parent = node.Parent;
                }
            }

        }

        private void Transplant(Node first, Node second) {
            if (first.Parent == null) {
                //first is root
                _root = second;
            }
            else if (ReferenceEquals(first.Parent.Left, first)) {
                //first is a left node
                first.Parent.Left = second;
            }
            else {
                first.Parent.Right = second;
            }
            if (second != null) {
                second.Parent = first.Parent;
            }
        }

        #endregion

        #region Finding

        public Node FindNode(T value) {
            return FindNodeCore(_root, value);
        }

        protected virtual Node FindNodeCore(Node startNode, T value) {
            if (startNode == null || startNode.Value.Equals(value)) return startNode;
            if (startNode.Value.CompareTo(value) < 0) {
                return FindNodeCore(startNode.Left, value);
            }
            return FindNodeCore(startNode.Right, value);
        }

        private Node FindMinimum(Node node) {
            while (node.Left != null) {
                node = node.Left;
            }
            return node;
        }

        #endregion



        #region Node

        [DebuggerDisplay("{Value}")]
        public class Node {
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }

            public bool IsLeaf {
                get { return Left == null && Right == null; }
            }

            public bool IsRoot {
                get { return Parent == null; }
            }
        }

        #endregion
    }
}
