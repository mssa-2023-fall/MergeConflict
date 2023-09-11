using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePractice {
    public class BadQueue<T>: IEnumerable<T> {

        // Attributes
        public Queue<T> theQueue { get; set; } = new Queue<T>();

        // Constructors
        public BadQueue() { }

        // Methods
        public void Enqueue(T element) {
            theQueue.Enqueue(element);
        }

        public void Dequeue() {
            theQueue.Dequeue();
        }

        public T Peek() {
            return theQueue.Peek();
        }

        public IEnumerator<T> GetEnumerator() {
            return theQueue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return theQueue.GetEnumerator();
        }
    }
}
