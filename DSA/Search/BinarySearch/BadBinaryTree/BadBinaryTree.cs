using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BadBinaryTree {
    internal class BadTree<T> {

        // ========== ATTRIBUTES ==========

        // what the root is
        public BadTreeNode? root { get; private set; } = null;

        // ========== CONSTRUCTORS ==========

        public BadTree() { }
        // guarantees sorted int array
        public BadTree(int[] nodes) {
            nodes.Order();
            
            BuildTree(nodes);
        }



        private void BuildTree(int[] nodes) {
            int mid = (nodes.Length - 1) / 2;
            BadTreeNode newNode = new BadTreeNode(nodes[mid]);
            root = newNode;

            RecursiveBuild(newNode, nodes);
        }

        private void RecursiveBuild(BadTreeNode node, int[] nodes) {
            // array of size 2
            if (nodes.Length == 2) {
                // if list[0] != node
                // node.left = list[0]
                if (nodes[0] != node.Content) {
                    BadTreeNode newNode = new BadTreeNode(nodes[0]);
                    node.Left = newNode;
                }
                // if list[1] != node
                // node.right = list[1]
                if (nodes[1] != node.Content) {
                    BadTreeNode newNode = new BadTreeNode(nodes[1]);
                    node.Right = newNode;
                }
            }

            int l = 0;
            int r = nodes.Length - 1;
            int mid = (r - l) / 2;

            // left side
            //      calculate the midpoint of left side
            // [ 1, 2, 3, 4, 5]
            // CHRIS IMPLEMENT HERE
            int leftMidIndex = Math.Round(mid / 2);
            int leftMidValue = nodes[leftMidIndex];
            

            int lMid = mid - ((r - l) / 2);
            //      left side of the passed node has a child == that midpoint
            node.Left = new BadTreeNode(nodes[lMid]);
            //      recursiveFunction(left node, array[0..midpoint])
            RecursiveBuild(node.Left, nodes[0..(mid+1)]); // + to make inclusive
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
        public T Min() {
            throw new NotImplementedException();
        }

        // max element in tree
        public T Max() {
            throw new NotImplementedException();
        }

        // get all nodes at a specific level
        public int GetAllAtLevel(int targetLevel) {
            throw new NotImplementedException();
        }

        // fill tree
        public void FillTree(IEnumerable<T> nodes) {
            throw new NotImplementedException();

        }
    }

    internal class BadTreeNode {

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

        // ========== METHODS ==========

    }
}
