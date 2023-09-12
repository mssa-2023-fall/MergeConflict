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
            var testAry = new int[] { 1, 2, 3, 4, 5 };
            var ourTree = new BadTree(testAry);
            var targetAry = new int[] { 3, 2, 4, 1, 5 };
            Array.Reverse(targetAry);

            // Act
            var newAry = ourTree.ToArray();

            // Assert
            Assert.AreEqual(targetAry[0], newAry[0]);
            Assert.AreEqual(targetAry[1], newAry[1]);
            Assert.AreEqual(targetAry[2], newAry[2]);
            Assert.AreEqual(targetAry[3], newAry[3]);
            Assert.AreEqual(targetAry[4], newAry[4]);

            //for (int i = 0; i < targetAry.Length; i++) {
            //    Assert.AreEqual(targetAry[i], newAry[i]);
            //}
        }
    }
}