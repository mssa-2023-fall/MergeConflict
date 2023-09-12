using BinarySearch;

namespace Testing {
    [TestClass]
    public class BinarySearchTest {

        [TestMethod]
        public void GivenASortedArray_WhenSearchMethodIsUsed_TheIndexOfTheTargetValueIsReturned() {
            // Arrange
            int[] testAry = new int[] { 2, 4, 7, 9, 10, 23, 67 };

            // Act
            // Assert
            Assert.AreEqual(0, BinarySearcher.Search(2, testAry));
            Assert.AreEqual(1, BinarySearcher.Search(4, testAry));
            Assert.AreEqual(6, BinarySearcher.Search(67, testAry));
        }

        [TestMethod]
        public void GivenEmptyArray_WhenSearchMethodIsUsed_NegativeOneIsReturned() {
            // Arrange
            int[] testAry = new int[] {};

            // Act
            // Assert
            Assert.AreEqual(-1, BinarySearcher.Search(0, testAry));
        }

        [TestMethod]
        public void GivenSizeOneArray_WhenSearchMethodIsUsed_CorrectValuesAreReturned() {
            // Arrange
            int[] testAry = new int[] { 1 };

            // Act
            // Assert
            Assert.AreEqual(-1, BinarySearcher.Search(0, testAry));
            Assert.AreEqual(0, BinarySearcher.Search(1, testAry));
        }

        [TestMethod]
        public void GivenSizeTwoArray_WhenSearchMethodIsUsed_CorrectValuesAreReturned() {
            // Arrange
            int[] testAry = new int[] { 1, 2 };

            // Act
            // Assert
            Assert.AreEqual(-1, BinarySearcher.Search(0, testAry));
            Assert.AreEqual(0, BinarySearcher.Search(1, testAry));
            Assert.AreEqual(1, BinarySearcher.Search(2, testAry));
        }

        [TestMethod]
        public void GivenAnArrayAndTargetNotInArray_WhenSearchMethodIsUsed_NegativeOneIsReturned() {
            // Arrange
            int[] testAry = new int[] { 2, 4, 7, 9, 10, 23, 67 };

            // Act
            // Assert
            Assert.AreEqual(-1, BinarySearcher.Search(0, testAry));
            Assert.AreEqual(-1, BinarySearcher.Search(5, testAry));
            Assert.AreEqual(-1, BinarySearcher.Search(70, testAry));
        }

        [TestMethod]
        [DynamicData(nameof(AllArrayData))]
        public void GivenArraysOfVariedSizes_WhenSearchMethodIsUsed_IndexOfTargetIsReturned(int target, int[] testAry) {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(target, BinarySearcher.Search(target, testAry));
        }

        public static IEnumerable<object[]> AllArrayData {
            get {
                Random rnd = new Random();
                for (int i = 1; i < 100; i++) {
                    int[] testAry = new int[i];
                    for (int j = 0; j < i; j++) {
                        testAry[j] = j;
                    }
                    yield return new object[] { rnd.Next(0, i), testAry };
                }
            }
        }
    }
}