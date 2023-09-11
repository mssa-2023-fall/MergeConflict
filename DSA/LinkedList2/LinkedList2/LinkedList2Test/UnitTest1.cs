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

        [TestMethod]
        public void RemoveAtShouldRemoveAnElementFromTheList() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            var node2 = new BadNode<int>(6);
            testLL.AddLast(node2);
            testLL.AddLast(new BadNode<int>(7));

            testLL.RemoveAt(2);

            Assert.AreEqual(2, testLL.Count);
            Assert.AreEqual(node2, testLL.Tail);
        }

        [TestMethod]
        public void RemoveAtShouldRemoveNodeAtGivenIndex_Index_is_zero_based() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            testLL.RemoveAt(2);

            Assert.AreEqual(4, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next?.Content);
            Assert.AreEqual(8, testLL.Head?.Next?.Next?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);

        }

        [TestMethod]
        public void RemoveAtBeyondTailShouldThrowInvalidOperation() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1

            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveAt(2));
        }

        [TestMethod]
        public void RemoveAtNegativeValueShouldThrowInvalidOperation() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1

            Assert.ThrowsException<InvalidOperationException>(() => testLL.RemoveAt(-1));
        }

        [TestMethod]
        public void RemoveLastMakesTailSecondToLastNode() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);
            var node2 = new BadNode<int>(6);
            testLL.AddLast(node2);
            testLL.AddLast(new BadNode<int>(7));

            testLL.RemoveLast();

            Assert.AreEqual(testLL.Tail, node2);
        }

        [TestMethod]
        public void RemoveLastMakesReturnsEmptyListIfSizeOf1() {
            var initialNode = new BadNode<int>(5);
            var testLL = new BadLinkedList<int>(initialNode);

            testLL.RemoveLast();

            Assert.AreEqual(null, testLL.Head);
            Assert.AreEqual(null, testLL.Tail);
            Assert.AreEqual(0, testLL.Count);
        }

        [TestMethod]
        public void RemoveAtHeadShouldWork() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            testLL.RemoveAt(0);

            Assert.AreEqual(4, testLL.Count);

            Assert.AreEqual(6, testLL.Head?.Content);
            Assert.AreEqual(7, testLL.Head?.Next?.Content);
            Assert.AreEqual(8, testLL.Head?.Next?.Next?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);
        }

        [TestMethod]
        public void InsertAfterNodeIndexZeroShouldMakeNodeRightAfterHead() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            testLL.InsertAfterNodeIndex(new BadNode<int>(99), 0);

            Assert.AreEqual(6, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(99, testLL.Head?.Next?.Content);
            Assert.AreEqual(6, testLL.Head?.Next?.Next?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);

        }

        [TestMethod]
        public void InsertAtEndShouldBeTheSameAsAddLast() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            testLL.InsertAfterNodeIndex(new BadNode<int>(99), testLL.Count - 1);

            Assert.AreEqual(6, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next?.Content);
            Assert.AreEqual(7, testLL.Head?.Next?.Next?.Content);
            Assert.AreEqual(99, testLL.Tail?.Content);

        }

        [TestMethod]
        public void InsertAtShouldBeBetweenZeroAndCountMinusOneOrItWillThrowInvalidOperation() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            Assert.ThrowsException<InvalidOperationException>(() => testLL.InsertAfterNodeIndex(new BadNode<int>(99), 5));
            Assert.ThrowsException<InvalidOperationException>(() => testLL.InsertAfterNodeIndex(new BadNode<int>(99), -1));

        }

        [TestMethod]
        public void InsertAtAnyValidPositionShouldWork() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            testLL.InsertAfterNodeIndex(new BadNode<int>(99), 1);

            Assert.AreEqual(6, testLL.Count);

            Assert.AreEqual(5, testLL.Head?.Content);
            Assert.AreEqual(6, testLL.Head?.Next?.Content);
            Assert.AreEqual(99, testLL.Head?.Next?.Next?.Content);
            Assert.AreEqual(9, testLL.Tail?.Content);

        }

        [TestMethod]
        public void ableToCreateForEachLoopUsingIEnumerator() {
            var initialNode = new BadNode<int>(5);//index 0
            var testLL = new BadLinkedList<int>(initialNode);
            testLL.AddLast(new BadNode<int>(6));//index 1
            testLL.AddLast(new BadNode<int>(7));//index 2
            testLL.AddLast(new BadNode<int>(8));//index 3
            testLL.AddLast(new BadNode<int>(9));//index 4

            foreach (var item in testLL) {
                Console.WriteLine(item);
            }

            

        }
    }
}
