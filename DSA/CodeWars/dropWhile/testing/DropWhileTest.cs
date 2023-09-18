

namespace testing {
    [TestClass]
    public class DropWhileTest {
        [TestMethod]
        public void GivenAnIntArray_WhenDropWhileIsUsed_AllPrefixEvensAreRemoved() {

            // Arrange
            int[] ary = new int[] { 2, 4, 6, 3, 7, 8 };
            int[] solution = new int[] { 3, 7, 8 };

            // Act
            Program.DropWhile(ref ary, x => x % 2 == 0);

            // Assert
            for (int i = 0; i < solution.Length; i++) {
                Assert.AreEqual(ary[i], solution[i]);
            }

        }

        [TestMethod]
        public void GivenAnIntArrayOfAllEvens_WhenDropWhileIsUsed_TheAryIsEmptied() {

            // Arrange
            int[] ary = new int[] { 2, 4, 6, 8, 2, 10};

            // Act
            Program.DropWhile(ref ary, x => x % 2 == 0);

            // Assert
            Assert.AreEqual(0, ary.Length);

        }

        [TestMethod]
        public void GivenAnIntArrayOfAllOdds_WhenDropWhileIsUsed_TheAryIsUnchanged() {

            // Arrange
            int[] ary = new int[] { 1, 5, 7, 3, 7, 9 };
            int[] solution = new int[] { 1, 5, 7, 3, 7, 9 };

            // Act
            Program.DropWhile(ref ary, x => x % 2 == 0);

            // Assert
            for (int i = 0; i < solution.Length; i++) {
                Assert.AreEqual(ary[i], solution[i]);
            }
        }

        [TestMethod]
        public void GivenAnEmptyArray_WhenDropWhileIsUsed_TheAryReturnsWithoutError() {

            // Arrange
            int[] ary = new int[] { };

            // Act
            Program.DropWhile(ref ary, x => x % 2 == 0);

            // Assert
            Assert.AreEqual(0, ary.Length);
        }
    }
}