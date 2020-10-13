using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogger.Functions
{
    public class RandomGenerators{
        public List<String> callNumbers; 
        public List<String> callNumbersDescriptions;
        public Random random = new Random();

        public Dictionary<string, string> generateNumbersAndDescription(int items) {
            generateRandomCallNumbers(items);
            generateCallNumberDescriptions(callNumbers);

            Dictionary<string, string> numbersDescription = new Dictionary<string, string>();
            for (int i = 0; i < callNumbers.Count; i++) {
                numbersDescription.Add(callNumbers[i], callNumbersDescriptions[i]);
            }
            return numbersDescription;
        }

        public int chooseList() {
            int temp = random.Next(0, 2);
            return temp;
        }

        public List<String> generateRandomCallNumbers(int items) {
            callNumbers = new List<string>();
            for (int i = 0; i < items; i++) {
                String part1 = random.Next(1000).ToString();
                if (int.Parse(part1) < 10) {
                    part1 = "00" + part1;
                } else if (int.Parse(part1) < 100) {
                    part1 = "0" + part1;
                }
                String part2 = random.Next(100).ToString();
                if (int.Parse(part2) < 10) {
                    part2 = "00" + part2;
                }
                String part3 = "";
                for (int k = 0; k < 3; k++) { 
                    int temp = random.Next(65, 90);
                    part3 += (char)temp;
                }
                callNumbers.Add(part1 + "." + part2 + " " + part3);
            }
            return callNumbers;
        }

        public List<String> generateCallNumberDescriptions(List<String> numbers) {
            callNumbersDescriptions = new List<string>();
            foreach (String item in numbers) {
                String description;
                String name = item.Substring(item.Length - 3);
                switch (Int32.Parse(item.Substring(0,3))) {
                    case int n when (n < 100 && n > 0):
                        description = "Computer science, knowledge & systems";
                        break;
                    case int n when (n < 200 && n >= 100):
                        description = "Philosophy & psychology";
                        break;
                    case int n when (n < 300 && n >= 200):
                        description = "Religion";
                        break;
                    case int n when (n < 400 && n >= 300):
                        description = "Social sciences";
                        break;
                    case int n when (n < 500 && n >= 400):
                        description = "Language";
                        break;
                    case int n when (n < 600 && n >= 500):
                        description = "Science";
                        break;
                    case int n when (n < 700 && n >= 600):
                        description = "Technology";
                        break;
                    case int n when (n < 800 && n >= 700):
                        description = "Arts & recreation";
                        break;
                    case int n when (n < 900 && n >= 800):
                        description = "Literature";
                        break;
                    case int n when (n < 1000 && n >= 900):
                        description = "History & geography";
                        break;
                    default:
                        description = "";
                        break;
                }
                callNumbersDescriptions.Add(description);
            }
            return callNumbersDescriptions;
        }
    }

}
