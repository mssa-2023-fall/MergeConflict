namespace QueuePractice {
    public class BadStack<T> {

        // Attributes
        public Stack<T> theStack { get; set; } = new Stack<T>();

        // Constructors
        public BadStack() { }

        // Methods
        public void Push(T element) { 
            theStack.Push(element);
        }
        public T Pop() {
            return theStack.Pop();
        }
        public T Peek() {
            return theStack.Peek();
        }
        public void Clear() {
            theStack.Clear();
        }
        public int Count() {
            return theStack.Count();
        }
    }
}
