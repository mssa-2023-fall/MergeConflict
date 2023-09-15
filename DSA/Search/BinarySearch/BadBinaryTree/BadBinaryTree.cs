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

        public BadTree() { }

        // guarantees sorted int array
        public BadTree(int[] nodes) {
            if(nodes == null || nodes.Length == 0)
            {
                return;
            }
            Root = BuildTree(nodes, 0, nodes.Length - 1);
        }
        
        public BadTreeNode? BuildTree(int[] nodes, int left, int right) {
            if (left > right) {
                return null;
            }

            int mid = (left + right) / 2;

            var curNode = new BadTreeNode(nodes[mid]);
            curNode.Left = BuildTree(nodes, left, mid - 1);
            curNode.Right = BuildTree(nodes, mid + 1, right);

            return curNode;
        }

        public int[] ToArray() {
            List<int> newAry = new List<int>();
            Queue<BadTreeNode> queue = new Queue<BadTreeNode>();

            // BFS through tree
            queue.Enqueue(Root);

            while (queue.Count > 0) {

                // each element touched, place into array
                var node = queue.Dequeue();

                // add node to newAry
                newAry.Add(node.Content);

                // add left child and right child to queue
                if (node.Left != null) { queue.Enqueue(node.Left); }
                if (node.Right != null) { queue.Enqueue(node.Right); }

            }

            // return array
            return newAry.ToArray();
        }

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

    //  3
    // 2 4
    //1   5
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
