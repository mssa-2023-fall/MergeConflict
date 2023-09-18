using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IO {
    public class Winner {
        public int Year { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Movie { get; set; }

        public Winner(string input) {
            // parse the input string like
            // 1, 1928, 44, "Emil Jannings", "The Last Command, The Way of All Flesh"
            List<string> ourList = new List<string>();
            var lastAddedIndex = 1;
            bool useComma = true;
            bool isString = false;

            for (int i = 1; i < input.Length; i++) {
                if (input[i] == ',' && useComma) {
                    if (isString) {
                        ourList.Add(HelpCopy(input, lastAddedIndex+3, i-1));
                        isString = false;
                    } else {
                        ourList.Add(HelpCopy(input, lastAddedIndex+2, i));
                    }
                    lastAddedIndex = i;
                } else if (input[i] == '"') {
                    isString = true;
                    useComma = !useComma;
                }
            }

            ourList.Add(HelpCopy(input, lastAddedIndex + 3, input.Length - 1));

            Year = Convert.ToInt32(ourList[1]);
            Age = Convert.ToInt32(ourList[2]);
            Name = ourList[3];
            Movie = ourList[4];
        }

        public static string HelpCopy (string words, int start, int end) {
            if (end <= start) { return ""; }

            var newString = new StringBuilder();
            newString.Length = end - start;

            for (int i = 0; i < newString.Length; i++) {
                newString[i] = words[i+start];
            }
            
            return newString.ToString();
        }

    }
}
