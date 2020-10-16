using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogger.Functions
{
    public class RandomGenerators{
        public Random random = new Random();
        Dictionary<String, DeweyDecimalSystem> deweyItems;

        public Dictionary<String, DeweyDecimalSystem> generateNumbersAndDescription(int numbers) {
            deweyItems = new Dictionary<string, DeweyDecimalSystem>();
            generateRandomCallNumbers(numbers);
            return deweyItems;
        }

        public int chooseList() {
            int temp = random.Next(0, 2);
            return temp;
        }

        public Dictionary<String, DeweyDecimalSystem> generateRandomCallNumbers(int numbers) {
            for (int i = 0; i < numbers; i++) {
                String callNumber = "";
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
                    int author = random.Next(65, 90);
                    part3 += (char)author;
                }

                callNumber = (part1 + "." + part2 + " " + part3);
                DeweyDecimalSystem temp = generateDescriptions(callNumber); 
                deweyItems.Add(callNumber, temp);
            }
            
            return deweyItems;
        }

        public DeweyDecimalSystem generateDescriptions(String call) {
            DeweyDecimalSystem item = new DeweyDecimalSystem();
            String name = call.Substring(0,3);
            switch (Int32.Parse(name)) {
                case 0:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = "";
                    return item;
                case 1:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = "";
                    return item;
                case 2:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systemss";
                    item.Low1 = "";
                    return item;
                case 3:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = "";
                    return item;
                case 4:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = "";
                    return item;
                case 5:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = "";
                    return item;
                case 6:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = ""; 
                    return item;
                case 7:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = ""; 
                    return item;
                case 8:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = ""; 
                    return item;
                case 9:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Computer science, knowledge & systems";
                    item.Low1 = ""; 
                    return item;
                case 10:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 11:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 12:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 13:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 14:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 15:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 16:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 17:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 18:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 19:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Bibliographies";
                    item.Low1 = "";
                    return item;
                case 20:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 21:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 22:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 23:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 24:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 25:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 26:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 27:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 28:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 29:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Library & information sciences";
                    item.Low1 = "";
                    return item;
                case 30:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 31:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 32:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 33:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 34:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 35:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 36:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 37:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 38:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case 39:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Encyclopedias & books of facts";
                    item.Low1 = "";
                    return item;
                case int n when (n >= 40 && n <= 49):
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Unnasigned";
                    item.Low1 = "";
                    return item;
                case 50:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 51:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 52:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 53:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 54:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 55:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 56:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 57:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 58:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 59:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Magazines, journals & serials";
                    item.Low1 = "";
                    return item;
                case 60:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 61:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 62:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 63:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 64:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 65:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 66:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 67:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 68:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 69:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Associations, organizations & museums";
                    item.Low1 = "";
                    return item;
                case 70:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 71:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 72:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 73:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 74:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 75:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 76:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 77:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 78:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 79:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "News media, journalism & publishing";
                    item.Low1 = "";
                    return item;
                case 80:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 81:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 82:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 83:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 84:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 85:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 86:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 87:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 88:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 89:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Quotations";
                    item.Low1 = "";
                    return item;
                case 90:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case 91:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 92:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 93:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 94:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 95:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 96:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 97:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 98:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case 99:
                    item.High1 = "Computer science, information & general works";
                    item.Mid1 = "Manuscripts & rare books";
                    item.Low1 = "";
                    return item;
                case int n when (n < 200 && n >= 100):
                    item.High1 = "Philosophy & psychology";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 300 && n >= 200):
                    item.High1 = "Religion";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 400 && n >= 300):
                    item.High1 = "Social sciences";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 500 && n >= 400):
                    item.High1 = "Language";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 600 && n >= 500):
                    item.High1 = "Science";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 700 && n >= 600):
                    item.High1 = "Technology";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 800 && n >= 700):
                    item.High1 = "Arts & recreation";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 900 && n >= 800):
                    item.High1 = "Literature";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                case int n when (n < 1000 && n >= 900):
                    item.High1 = "History & geography";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
                default:
                    item.High1 = "";
                    item.Mid1 = "";
                    item.Low1 = "";
                    return item;
            }
        }
    }

}
