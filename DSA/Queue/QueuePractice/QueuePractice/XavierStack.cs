using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePractice {
    public class XavierStack<T> {
        // Attributes
        public LinkedList<T> theList { get; set; } = new LinkedList<T>();

        // Constructors
        public XavierStack() { }

        // Methods
        public void Push(T element) {
            theList.AddLast(element);
        }
        public T Pop() {
            var lastElement = theList.Last;
            theList.RemoveLast();
            return lastElement.Value;
        }
        public T Peek() {
            return theList.Last.Value;
        }
        public void Clear() {
            theList.Clear();
        }
        public int Count() {
            return theList.Count();
        }
    }
}
