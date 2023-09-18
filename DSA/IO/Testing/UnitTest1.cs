namespace Testing {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TryStreamReadMethod() {
            // Arrange
            // create a 100 loop to build MemoryStyream 0x01, 0x02, 0x03...
            byte[] byteAry = new byte[100];
            for (int i = 0; i < byteAry.Length; i++) {
                byteAry[i] = (byte)i;
            }
            Stream s = new MemoryStream(byteAry);

            // Act
            // read first 5 bytes by using Stream.Read method
            var bufferToPopulate = new byte[5];
            int bytesRead = s.Read(bufferToPopulate, 0, 5);

            // Assert
            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bytesRead, 5);
        }

        [TestMethod]
        public void ConfirmStreamReadReturnValueIsBoundByTheNumberOfBytesActuallyRead() {
            // Arrange
            // create a 100 loop to build MemoryStyream 0x01, 0x02, 0x03...
            byte[] byteAry = new byte[100];
            for (int i = 0; i < byteAry.Length; i++) {
                byteAry[i] = (byte)i;
            }
            Stream s = new MemoryStream(byteAry);

            // Act
            // read first 5 bytes by using Stream.Read method
            var bufferToPopulate = new byte[120];
            int bytesRead = s.Read(bufferToPopulate, 0, 120);

            // Assert
            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bytesRead, 100);
        }

        [TestMethod]
        public void CreateANewMemoryStreamFromBytes() {
            // Arrange
            // create a 100 loop to build MemoryStyream 0x01, 0x02, 0x03...
            byte[] byteAry = new byte[100];
            for (int i = 0; i < byteAry.Length; i++) {
                byteAry[i] = (byte)i;
            }
            var s = new MemoryStream();

            // Act
            s.Write(byteAry);
            s.Seek(0, 0);

            // write to stream s using data in byte array
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(0, s.Position);
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
        }

        [TestMethod]
        public void CreateANewFileStreamFromBytes() {
            // Arrange
            // create a 100 loop to build MemoryStyream 0x01, 0x02, 0x03...
            byte[] byteAry = new byte[100];
            for (int i = 0; i < byteAry.Length; i++) {
                byteAry[i] = (byte)i;
            }
            var s = new FileStream("stream_file", FileMode.OpenOrCreate);

            // Act
            s.Write(byteAry);
            s.Seek(0, 0);

            // write to stream s using data in byte array
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(0, s.Position);
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
            s.Flush();
            s.Close();
        }
    }
}