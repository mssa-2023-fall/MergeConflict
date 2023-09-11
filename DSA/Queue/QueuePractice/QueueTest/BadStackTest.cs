using QueuePractice;

namespace BadStackTest {

    [TestClass]
    public class BadStackTest {

        [TestMethod]
        public void WhenStackIsInstantiated_StackIsEmpty() {
            // Arrange
            var ourStack = new BadStack<int>();

            // Assert
            Assert.AreEqual(0, ourStack.theStack.Count);
        }

        [TestMethod]
        public void ElementsCanBePushedOntoStack() {
            // Arrange
            var ourStack = new BadStack<int>();

            // Act
            ourStack.Push(3);
            ourStack.Peek();

            // Assert
            Assert.AreEqual(3, ourStack.Peek());
        }

        [TestMethod]
        public void ElementsCanBePopedFromStack() {
            // Arrange
            var ourStack = new BadStack<int>();

            // Act
            ourStack.Push(3);
            ourStack.Push(4);
            ourStack.Pop();

            // Assert
            Assert.AreEqual(3, ourStack.Peek());
        }

        [TestMethod]
        public void ElementsCanBePeekedWithoutBeingRemoved() {
            // Arrange
            var ourStack = new BadStack<int>();

            // Act
            ourStack.Push(3);
            ourStack.Peek();

            // Assert
            Assert.AreEqual(3, ourStack.Peek());
            Assert.AreEqual(3, ourStack.Pop());
        }

        [TestMethod]
        public void TheStackCanBeCleared() {
            // Arrange
            var ourStack = new BadStack<int>();

            // Act
            ourStack.Push(1);
            ourStack.Push(2);
            ourStack.Push(3);
            ourStack.Clear();

            // Assert
            Assert.AreEqual(0, ourStack.Count());
        }

        [TestMethod]
        public void UsingCountReturnsAmountOfElementsInStack() {
            // Arrange
            var ourStack = new BadStack<int>();

            // Act
            ourStack.Push(1);
            ourStack.Push(2);
            ourStack.Push(3);

            // Assert
            Assert.AreEqual(3, ourStack.Count());
        }
    }
}