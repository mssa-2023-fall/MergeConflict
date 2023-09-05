namespace LearnImmutableTest {
    [TestClass]
    public class SampleRecordTest {

        SampleRecord record1;

        [TestInitialize]
        public void TestSetup() {
            record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
        }

        [TestMethod]
        public void TestRecordTypeEqualityWithPositionParameters() {

            // Arrange
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            // Assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);

        }

        [TestMethod]
        public void TestRecordTypeInequalityWithPositionParameters() {

            // Arrange
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            // Assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);

        }

        [TestMethod]
        public void TestRecordTypeSamenessWithPositionParameters() {

            // Arrange
            SampleRecord record2 = record1;

            // Assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);

        }

        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties() {

            // Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);

        }

        [TestMethod]
        public void TestRecordTypeMutableProperties() {

            // Arrange
            string newMutableProperty = "New";

            // Act
            record1.MutableProperty = newMutableProperty;

            // Assert
            Assert.AreEqual(newMutableProperty, record1.MutableProperty);

        }

        [TestMethod]
        public void TestRecordTypeHasDestructMethodWithOutParam() {

            // Arrange
            string outString = String.Empty;
            int outInt = 0;
            DateTime outDate = new DateTime();

            // Act
            record1.Deconstruct(out outString, out outInt, out outDate);

            // Assert
            Assert.AreEqual(outString, "Test");
            Assert.AreEqual(outInt, 1);
            Assert.AreEqual(outDate, new DateTime(2023, 9, 5));


        }

        [TestMethod]
        public void TestRecordTypeNondestructiveMutationInequality() {

            // Arrange
            string newMutableProperty = "New";

            // Act
            SampleRecord record2 = record1 with { MutableProperty = newMutableProperty };

            // Assert
            Assert.AreNotSame(record1, record2);
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotEqual(record1.MutableProperty, record2.MutableProperty);
            Assert.AreEqual(record2.MutableProperty, newMutableProperty);
            Assert.AreEqual(record1.ParamString, record2.ParamString);


        }

        [TestMethod]
        public void TestRecordTypeNondestructiveMutationEquality() {

            // Act
            SampleRecord record2 = record1 with { };

            // Assert
            Assert.AreNotSame(record1, record2);
            Assert.AreEqual(record1, record2);
            Assert.AreEqual(record1.MutableProperty, record2.MutableProperty);

        }
    }
}