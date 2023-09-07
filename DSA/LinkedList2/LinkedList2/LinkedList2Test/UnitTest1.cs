using LinkedList;

namespace LinkedListTest {
    [TestClass]
    public class BadLinkedListTest {
        [TestMethod]
        public void DefaultConstructorCreatesEmptyLL() {
            var testLL = new BadLinkedList<int>();
            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }
        [TestMethod]
        public void EmptyLLCallingRemoveShouldThrowInvalidOperationException() {
            var testLL = new BadLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveLast(), "Remove method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveFirst(), "Remove method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveAt(0), "Remove method on empty list did not throw an exception");

        }

        [TestMethod]
        public void ParameterizedConstructorShouldPopulateTheHeadAndTailNode() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            Assert.AreEqual(1, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.IsNotNull(testLL.Tail);
            Assert.AreSame(testLL.Head, initialNode);
            Assert.AreSame(testLL.Tail, initialNode);
        }

        [TestMethod]
        public void AddFirstShouldReplaceHeadNodeAndCreateLinkToOldHead() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            var addFirstNode = new BadNode<int>(10);

            testLL.AddFirst(addFirstNode);

            Assert.AreEqual(2, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.IsNotNull(testLL.Tail);
            Assert.AreSame(testLL.Head, addFirstNode);
            Assert.AreSame(testLL.Tail, initialNode);
            Assert.AreEqual(10, testLL.Head.Content);
            Assert.AreEqual(5, testLL.Tail.Content);
        }

        [TestMethod]
        public void AddLastShouldReplaceHeadNodeAndCreateLinkToOldHead() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            var addLastNode = new BadNode<int>(10);

            testLL.AddLast(addLastNode);

            Assert.AreEqual(2, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.IsNotNull(testLL.Tail);
            Assert.AreSame(testLL.Head, initialNode);
            Assert.AreSame(testLL.Tail, addLastNode);
            Assert.AreEqual(5, testLL.Head.Content);
            Assert.AreEqual(10, testLL.Tail.Content);
        }

        [TestMethod]
        public void ClearMethodShouldReturnEmptyLinkedList() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            var addLastNode = new BadNode<int>(10);
            testLL.AddLast(addLastNode);

            testLL.Clear();
            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }


        [TestMethod]
        public void FindAllMethodShouldReturnNullIfNotFound() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));
            //finding nonexistant value
            INode<int>[] result = testLL.FindAll(1);


            Assert.AreEqual(0, result.Length);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindAllMethodShouldReturnOne() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));
            //finding nonexistant value
            INode<int>[] result = testLL.FindAll(5);


            Assert.AreEqual(1, result.Length);
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].Content, 5);

        }

        [TestMethod]
        public void FindAllMethodShouldReturnMany() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));
            testLL.AddFirst(new BadNode<int>(5));
            //finding nonexistant value
            INode<int>[] result = testLL.FindAll(5);

            Assert.AreEqual(2, result.Length);
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].Content, 5);
            Assert.AreEqual(result[1].Content, 5);
        }

        [TestMethod]
        public void FindOneMethodShouldReturnExactlyOneEvenIfThereAreMultipleMatches() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));
            testLL.AddFirst(new BadNode<int>(5));
            //finding nonexistant value
            INode<int>? result = testLL.FindFirst(5);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, 5);
        }
        [TestMethod]
        public void FindOneMethodShouldReturnNullWhenThereAreNoMatch() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));
            testLL.AddFirst(new BadNode<int>(5));
            //finding nonexistant value
            INode<int>? result = testLL.FindFirst(8);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void FindOneMethodShouldReturnOneWhenThereIsOneMatch() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));
            testLL.AddFirst(new BadNode<int>(5));
            //finding nonexistant value
            INode<int>? result = testLL.FindFirst(7);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, 7);
        }

        [TestMethod]
        public void RemoveFirstShouldRemoveHeadAndMakeSecondNodeTheHead() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddFirst(new BadNode<int>(6));
            testLL.AddFirst(new BadNode<int>(7));

            testLL.RemoveFirst();
            Assert.AreEqual(2, testLL.Count);
            Assert.AreEqual(6, testLL.Head?.Content);
            Assert.AreEqual(5, testLL.Tail?.Content);
        }

        [TestMethod]
        public void RemoveFirstShouldReturnEmptyLinkedListWhenThereIsOnlyOneNode() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);

            testLL.RemoveFirst();

            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }

        [TestMethod]
        public void RemoveFirstShouldThrowExceptionIfLinkedListIsEmpty() {
            var testLL = new BadLinkedList<int>();

            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveFirst(), "We think, if one attempts to remove an item from empty LL, it should throw Exception");

        }
    }
}