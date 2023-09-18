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

        [TestMethod]
        public void WritePrimitiveData() {
            // Arrange
            // create a file stream to store data at binary.bin
            // construct a BinaryWriter with above stream
            var fileStream = new FileStream("binary.bin", FileMode.OpenOrCreate);
            var binaryWriter = new BinaryWriter(fileStream);

            // Act
            // write char, string, decimal, int64, int32 and write a double
            // dont forget to flush and close the file
            using (binaryWriter) { 
                binaryWriter.Write((char)'A');
                binaryWriter.Write((string)" sail boat costs: ");
                binaryWriter.Write((decimal)decimal.MaxValue);
                binaryWriter.Write((Int64)Int64.MaxValue);
                binaryWriter.Write((Int32)Int32.MaxValue);
                binaryWriter.Write((double)double.MaxValue);
                binaryWriter.Flush();
            }

            // write to stream s using data in byte array
            fileStream = new FileStream("binary.bin", FileMode.OpenOrCreate);
            var binaryReader = new BinaryReader(fileStream);

            using (binaryReader) {
                Assert.AreEqual('A', binaryReader.ReadChar());
                Assert.AreEqual(" sail boat costs: ", binaryReader.ReadString());
            }

        }

        [TestMethod]
        public void CopyFile() {
            // Arrange
            var file1 = new FileStream("binary.bin", FileMode.Open);
            var binaryReader = new BinaryReader(file1);
            var file2 = new FileStream("binary COPY.bin", FileMode.OpenOrCreate);
            var binaryWriter = new BinaryWriter(file2);

            // Act
            using (binaryReader) { 
            using (binaryWriter) {
                binaryWriter.Write(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length));
                binaryWriter.Flush();
            }}

            var oldFile = new FileStream("binary.bin", FileMode.Open);
            var newFile = new FileStream("binary COPY.bin", FileMode.Open);

            while (oldFile.Position != oldFile.Length || newFile.Position != newFile.Length) {
                Assert.AreEqual(oldFile.ReadByte(), newFile.ReadByte());
            }

            oldFile.Close();
            newFile.Close();
        }
    }
}