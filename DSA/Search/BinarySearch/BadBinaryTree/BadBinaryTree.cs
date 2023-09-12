using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BadBinaryTree {
    public class BadTree {

        // ========== ATTRIBUTES ==========

        // what the root is
        public BadTreeNode? Root { get; set; } = null;

        // ========== CONSTRUCTORS ==========

        /*
        public BadTree() { }
        // guarantees sorted int array
        public BadTree(int[] nodes) {
            nodes.Order();
            
            BuildTree(nodes, 0, nodes.Length-1);
        }
        */

        /*
        public void BuildTree(int[] nodes) {
            int mid = (nodes.Length - 1) / 2;
            BadTreeNode newNode = new BadTreeNode(nodes[mid]);
            Root = newNode;

            RecursiveBuild(newNode, nodes);
        }
        */
        public void RecursiveBuild(BadTreeNode node, int[] nodes) {

            // array of size 2
            if (nodes.Length == 2) {
                // if list[0] != node
                // node.left = list[0]
                if (nodes[0] != node.Content && nodes[0] != node.Parent.Content) {
                    BadTreeNode newNode = new BadTreeNode(nodes[0], node);
                    node.Left = newNode;
                }
                // if list[1] != node
                // node.right = list[1]
                if (nodes[1] != node.Content && nodes[1] != node.Parent.Content) {
                    BadTreeNode newNode = new BadTreeNode(nodes[1], node);
                    node.Right = newNode;
                }
                return;
            }

            int l = 0;
            int r = nodes.Length - 1;
            int mid = (r - l) / 2;

            // left side
            //      calculate the midpoint of left side
            // [ 1, 2, 3, 4, 5 ]
            // CHRIS IMPLEMENT HERE

            //      left side of the passed node has a child == that midpoint
            if (nodes[mid / 2] != node.Content && nodes[mid / 2] != node.Parent.Content) {
                node.Left = new BadTreeNode(nodes[mid / 2], node);
                //      recursiveFunction(left node, array[0..midpoint])
                RecursiveBuild(node.Left, nodes[0..(mid + 1)]); // + to make inclusive
            }



            if (nodes[mid + (mid / 2)] != node.Content && nodes[mid + (mid / 2)] != node.Parent.Content) {
                node.Right = new BadTreeNode(nodes[mid + (mid / 2)], node);
                RecursiveBuild(node.Right, nodes[mid..nodes.Length]); // + to make inclusive
            }
        }
            

        public int[] ToArray() {
            int[] newAry = new int[32];
            Queue<BadTreeNode> queue = new Queue<BadTreeNode>();
            int i = 0;

            // BFS through tree
            queue.Enqueue(Root);

            while (queue.Count > 0) {

                // each element touched, place into array
                var node = queue.Dequeue();

                // add node to newAry
                newAry[i] = node.Content;
                i++;

                // add left child and right child to queue
                if (node.Left != null) { queue.Enqueue(node.Left); }
                if (node.Right != null) { queue.Enqueue(node.Right); }

            }

            // return array
            return newAry;
        }

        /*
        private void BuildTree(int[] nodes, int leftIndex, int rightIndex) {
            if (leftIndex > rightIndex) {
                return; // Base case: No elements left in the subtree
            }

            int midIndex = leftIndex + (rightIndex - leftIndex) / 2;

            // Create a new node for the current midpoint element
            BadTreeNode newNode = new BadTreeNode(nodes[midIndex]);

            // Set the new node as the left or right child based on the comparison with the current node's content
            if (nodes[midIndex].CompareTo(newNode.Content) < 0) {
                newNode.Right = Root;
                Root = newNode;
            } else {
                newNode.Left = Root;
                Root = newNode;
            }

            // Recursively build the left and right subtrees
            BuildTree(nodes, leftIndex, midIndex - 1); // Left subtree
            BuildTree(nodes, midIndex + 1, rightIndex); // Right subtree
        }
        */

        // Constructor that takes an IEnumerable to build the tree
        public BadTree(int[] nodes) {
            var sortedNodes = nodes.OrderBy(node => node).ToArray();
            Root = BuildTree(sortedNodes, 0, sortedNodes.Length - 1);
        }

        // Recursive method to build the balanced BST
        private BadTreeNode BuildTree(int[] nodes, int leftIndex, int rightIndex) {
            if (leftIndex > rightIndex) {
                return null; // Base case: No elements left in the subtree
            }

            int midIndex = leftIndex + (rightIndex - leftIndex) / 2;

            // Create a new node for the current midpoint element
            BadTreeNode newNode = new BadTreeNode(nodes[midIndex]);

            // Recursively build the left and right subtrees
            newNode.Left = BuildTree(nodes, leftIndex, midIndex - 1); // Left subtree
            newNode.Right = BuildTree(nodes, midIndex + 1, rightIndex); // Right subtree

            return newNode;
        }



        // [ 1, 2, 3, 4, 5]
        // add(1)
        // root = 1

        // midpoint
        // root = midpoint

        // [ 1, 2, 3, 4, 5, 6, 7 ]
        //      4
        //   2    6
        // 1  3  5  7

        // recursive function
        // input = node, array

        // [ 1, 2 ]
        // array of size 2
        // if list[0] != node
        // node.left = list[0]
        // if list[1] != node
        // node.right = list[1]

        // left side
        //      calculate the midpoint of left side
        //      left side of the passed node has a child == that midpoint
        //      recursiveFunction(left node, array[0..midpoint])
        // EXAMPLE:
        // node = 4, array = [ 1, 2, 3, 4, 5, 6, 7]
        // left side of array == array[0..midpoint] == [ 1, 2, 3, 4 ]
        // midpoint = 1 == int 2 create a node and make left child of 4 = 2 node
        // 

        // right side
        //      calculate the midpoint of right side
        //      right side of the passed node has a child == that midpoint



        // ========== METHODS ==========

        // how many nodes
        // will iterate through tree for count
        public int Count() {
            throw new NotImplementedException();
        }

        // how deep the tree goes
        public int Depth() {
            throw new NotImplementedException();
        }

        // min element in tree
        public int Min() {
            throw new NotImplementedException();
        }

        // max element in tree
        public int Max() {
            throw new NotImplementedException();
        }

        // get all nodes at a specific level
        public int GetAllAtLevel(int targetLevel) {
            throw new NotImplementedException();
        }

        // fill tree
        public void FillTree(int[] nodes) {
            throw new NotImplementedException();

        }
    }

    public class BadTreeNode {

        // ========== ATTRIBUTES ==========

        // parent node
        public BadTreeNode Parent { get;  set; }
        // level in tree
        public BadTreeNode Level { get;  set; }

        // left node
        public BadTreeNode Left { get; set; }

        // right node
        public BadTreeNode Right { get; set; }

        // content
        public int Content { get; set; }

        // ========== CONSTRUCTORS ==========

        public BadTreeNode(int num) {
            Content = num;
        }
        public BadTreeNode(int num, BadTreeNode theParent) {
            Content = num;
            Parent = theParent;
        }
        // ========== METHODS ==========

    }
}
