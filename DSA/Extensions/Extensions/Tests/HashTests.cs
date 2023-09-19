using MssaExtensionsNS;

namespace Tests {
    [TestClass]
    public class HashTests {
        [TestMethod]
        public void HashesMatch() {
            var _file = new FileInfo(@"C:\oscar_age_male.csv");
            Assert.AreEqual("ebaebd8f6c8bfb71808ab2b83c1627cef90605be", _file.GetSHAString(MssaExtensions.StringFormat.Base64));
            Assert.AreEqual("79B69E6DDF1FE9CF1B7DBEF5F34F1A6F66FCDDCD7ADBB71E7FDD3AD396DE", _file.GetSHAString(MssaExtensions.StringFormat.Hex));
        }

        [TestMethod]
        public void CustomLinqMethods() {
            IEnumerable<int> inputs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<float> inputs2 = new[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f };
            var median = inputs.Median();
            var median2 = inputs2.Median();

            Assert.AreEqual(5.5, median);
            Assert.AreEqual(5.5, median2);

        }
    }
}