using BadBinaryTree;

namespace Testing {

    [TestClass]
    public class BadBinaryTreeTest {

        [TestMethod]
        public void truee() {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GivenASortedArray_WhenConvertedToTree_TreeContentsAreCorrect() {
            // Arrange
            var testAry = new int[] { 0, 1, 2, 3, 4, 5, 5, 7, 8, 8, 9, 11, 12, 22, 33 };
            var ourTree = new BadTree(testAry);
            var targetAry = new int[] { 7, 3, 11, 1, 5, 8, 22, 0, 2, 4, 5, 8, 9, 12, 33 };

            // Act
            var newAry = ourTree.ToArray();

            // Assert
            for (int i = 0; i < targetAry.Length; i++) {
                Assert.AreEqual(targetAry[i], newAry[i]);
            }
        }
    }
}