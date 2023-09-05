namespace LearnImmutableTest {
    [TestClass]
    public class SampleRecordTest {

        [TestMethod]
        public void TestRecordTypeEqualityWithPositionParameters() {

            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);

        }

        [TestMethod]
        public void TestRecordTypeInequalityWithPositionParameters() {

            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);

        }

        [TestMethod]
        public void TestRecordTypeSamenessWithPositionParameters() {

            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = record1;

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);

        }

        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties() {

            // Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            // Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);

        }

        [TestMethod]
        public void TestRecordTypeMutableProperties() {

            // Arrange
            string newMutableProperty = "New";
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5)) { MutableProperty = "Old" };

            // Act
            record1.MutableProperty = newMutableProperty;

            // Assert
            Assert.AreEqual(newMutableProperty, record1.MutableProperty);

        }

        [TestMethod]
        public void TestRecordTypeHasDestructMethodWithoutParam() {

            // Arrange
            string outString = String.Empty;
            int outInt = 0;
            DateTime outDate = new DateTime();
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5)) { MutableProperty = "Old" };

            // Act
            record1.Deconstruct(out outString, out outInt, out outDate);

            // Assert
            Assert.AreEqual(outString, "Test");
            Assert.AreEqual(outInt, 1);
            Assert.AreEqual(outDate, new DateTime(2023, 9, 5));


        }
    }
}