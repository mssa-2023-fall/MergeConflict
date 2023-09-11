using QueuePractice;

namespace BadQueueTest {

    [TestClass]
    public class BadQueueTest {

        [TestMethod]
        public void EnqueueAddsItemsToQueue() {
            // Arrange
            var ourQueue = new BadQueue<int>();

            // Act
            ourQueue.Enqueue(1);

            // Assert
            Assert.AreEqual(1, ourQueue.Peek());
        }

        [TestMethod]
        public void DequeueRemovesItemsFromQueue() {
            // Arrange
            var ourQueue = new BadQueue<int>();

            // Act
            ourQueue.Enqueue(1);
            ourQueue.Enqueue(2);
            ourQueue.Dequeue();

            // Assert
            Assert.AreEqual(2, ourQueue.Peek());
        }

        [TestMethod]
        public void QueueCanBeIterated() {
            // Arrange
            var ourQueue = new BadQueue<int>();
            int i = 0;

            // Act
            ourQueue.Enqueue(0);
            ourQueue.Enqueue(1);
            ourQueue.Enqueue(2);

            // Assert
            foreach (var item in ourQueue) {
                Assert.AreEqual(item, i);
                i++;
            }
        }
    }
}
