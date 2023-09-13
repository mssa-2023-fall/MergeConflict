using CustomerLogin;

namespace BadDataBaseTest {
    [TestClass]
    public class BadDatabaseTest {

        [TestMethod]
        public void GivenANewDB_WhenACustomerIsAdded_ThatCustomerAppearsInDB() {
            // Arrange
            BadDatabase ourDB = new();

            // Act
            ourDB.AddCustomer("EXemail", "EXname", "EXpassword", "EXcreditcard");

            // Assert
            Assert.IsTrue(ourDB.DB.ContainsKey("EXemail"));
            Assert.IsInstanceOfType(ourDB.DB["EXemail"], typeof(Customer));
        }

        [TestMethod]
        public void GivenANewDB_WhenACustomerIsAdded_TheirOriginalPasswordIsNotStored() {
            // Arrange
            BadDatabase ourDB = new();
            
            // Act
            ourDB.AddCustomer("EXemail", "EXname", "EXpassword", "EXcreditcard");

            // Assert
            Assert.AreNotEqual(ourDB.DB["EXemail"].PasswordHash, "EXpassword");
        }

        [TestMethod]
        public void GivenANewDB_WhenACustomerIsAdded_TheyCanBeRetrievedOnlyIfTheirPasswordMatches() {
            // Arrange
            BadDatabase ourDB = new();
            string ourEmail = "EXemail";
            string ourPassword = "EXpassword";

            // Act
            ourDB.AddCustomer(ourEmail, "EXname", ourPassword, "EXcreditcard");
            var ourCustomerSuccess = ourDB.GetCustomer(ourEmail, ourPassword);
            var ourCustomerFailure = ourDB.GetCustomer(ourEmail, "BadPass");

            // Assert
            Assert.IsTrue(ourCustomerSuccess != null);
            Assert.IsTrue(ourCustomerFailure == null);
        }
    }
}