using IO;
using CsvHelper;

namespace Testing {
    [TestClass]
    public class WinnerTest {

        [TestMethod]
        public void TryStreamReadMethod() {
            string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);

            Assert.AreEqual(w.Year, 1928);
            Assert.AreEqual(w.Age, 44);
            Assert.AreEqual(w.Name, "Emil Jannings");
            Assert.AreEqual(w.Movie, "The Last Command, The Way of All Flesh");

        }

        [TestMethod]
        public void HelpCopyTest() {
            string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);

            Assert.AreEqual(Winner.HelpCopy(input, 0, input.Length), @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""");
        }

        [TestMethod]
        public void HelpCopyTestNot0() {
            string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);

            Assert.AreEqual(Winner.HelpCopy(input, 3, 7), @"1928");
        }

        [TestMethod]
        public void CreateWinnersFromCsvFile() {
            List<Winner> winners = new List<Winner>();

            using (StreamReader sr = new StreamReader(@"C:\oscar_age_male.csv")) {
                string line;

                sr.ReadLine();

                while ((line = sr.ReadLine()) != null) {
                    if (line.Length == 0) break;
                    winners.Add(new Winner(line));
                }
            }

            Assert.AreEqual(89, winners.Count);

        }


        [TestMethod]
        public void CreateWinnersFromCsvFileUsingCsvReader() {
            List<Winner> winners = new List<Winner>();

            using (var treader = new StreamReader()) {
            using (var csv = new CsvReader)
            }

        }
    }
}