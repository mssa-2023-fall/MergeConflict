
using System.Collections;
using System.Collections.Generic;

namespace LinkedList {
    public class BadLinkedList<T> : ILinkedList<T>, IEnumerable<T> {

        // ========== ATTRIBUTES ==========

        public int Count { get; private set; } = 0;
        public INode<T>? Head { get; private set; } = null;
        public INode<T>? Tail { get; private set; } = null;
        public IEnumerable<INode<T>> Nodes {
            get {
                INode<T>[] allNodes = new INode<T>[Count];
                INode<T> currNode = Head;
                int currIndex = 0;
                while (currNode != null) {
                    allNodes[currIndex++] = currNode;
                    currNode = currNode.Next;
                }
                return allNodes;
            }
        }

        // ========== CONSTRUCTORS ==========

        public BadLinkedList() { }

        public BadLinkedList(INode<T> node) {
            Head = node;
            Tail = node;
            Count = 1;
        }

        // ========== METHODS ==========

        public void AddFirst(INode<T> value) {
            INode<T>? currHead = Head;

            value.Next = Head;
            Head = value;

            Count++;
        }
        public void AddLast(INode<T> value) {
            Tail.Next = value;
            Tail = value;
            Count++;
        }
        public void Clear() {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public INode<T>[] FindAll(T value) {
            List<INode<T>> allNodes = new();
            INode<T> currNode = Head;

            while (currNode != null) {
                if (currNode.Content.Equals(value)) {
                    allNodes.Add(currNode);
                }
                currNode = currNode.Next;
            }

            return allNodes.ToArray();
        }
        public INode<T>? FindFirst(T value) {
            INode<T> currNode = Head;

            while (currNode != null) {
                if (currNode.Content.Equals(value)) {
                    return currNode;
                }
                currNode = currNode.Next;
            }

            return null;
        }
        public void InsertAfterNodeIndex(INode<T> value, int position) {
            if (position < 0 || position > Count-1) {
                throw new InvalidOperationException();
            }

            if (position == Count-1) {
                AddLast(value);
                return;
            }

            INode<T>? currNode = Head;

            for (int i = 0; i < position; i++) {
                currNode = currNode.Next;
            }

            (currNode.Next, value.Next) = (value, currNode.Next);

            Count++;

            return;
        }
        public void RemoveAt(int IndexPosition) {
            if (IndexPosition < 0 || IndexPosition > Count-1) {
                throw new InvalidOperationException();
            }

            if (IndexPosition == 0) {
                RemoveFirst();
                return;
            }

            if (IndexPosition == Count - 1) {
                RemoveLast();
                return;
            }

            if (IndexPosition >= Count) { return; }

            INode<T>? currNode = Head;
            INode<T>? prevNode = null;

            for (int i = 0; i < IndexPosition; i++) {
                (currNode, prevNode) = (currNode.Next, currNode);
            }

            prevNode.Next = currNode.Next;

            Count--;

            return;
        }
        public void RemoveFirst() {
            if (Head == null) {
                throw new InvalidOperationException();
            }

            if (Tail == Head) {
                Tail = Head.Next;
            }

            Head = Head.Next;
            Count--;
            return;
        }
        public void RemoveLast() {
            if (Tail == null) {
                throw new InvalidOperationException();
            }

            if (Head == Tail) {
                Clear();
                return;
            }

            INode<T> currNode = Head;
            INode<T>? prevNode = null;

            while (currNode != Tail) {
                (currNode, prevNode) = (currNode.Next, currNode);
            }

            prevNode.Next = null;
            Tail = prevNode;

            Count--;
        }

        public IEnumerator<T> GetEnumerator() {
            return (IEnumerator<T>)Nodes.GetEnumerator();
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Nodes.GetEnumerator();
            //throw new NotImplementedException();
        }
    }

    public class BadNode<T> : INode<T> {

        // ========== ATTRIBUTES ==========
        public T Content { get; set; }
        public INode<T>? Next { get; set; } = null;

        // ========== CONSTRUCTORS ==========

        public BadNode(T element) {
            Content = element;
        }
    }
}
