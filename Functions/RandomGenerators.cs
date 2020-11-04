using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryLogger.Functions {
    public class RandomGenerators {
        public Random random = new Random();
        Dictionary<String, DeweyDecimalSystem> deweyItems;

        public Dictionary<String, DeweyDecimalSystem> generateNumbersAndDescription(int numbers) {
            deweyItems = new Dictionary<string, DeweyDecimalSystem>();
            GenerateRandomCallNumbers(numbers);
            return deweyItems;
        }

        public string GetRandomNumber(int min, int max) {
            string rand = random.Next(min, max - 1).ToString();
            if (int.Parse(rand) < 10) {
                rand = "00" + rand;
            } else if (int.Parse(rand) < 100) {
                rand = "0" + rand;
            }
            return rand;
        }

        public Dictionary<String, DeweyDecimalSystem> FindingCallNumbers() {
            deweyItems = new Dictionary<string, DeweyDecimalSystem>();
            for (int i = 0; i < 100; i++) {
                String part1 = i.ToString();
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

                string callNumber = (part1 + "." + part2 + " " + part3);
                DeweyDecimalSystem temp = GenerateDescriptions(callNumber);
                deweyItems.Add(callNumber, temp);
            }
            for (int i = 0; i < deweyItems.Count; i++) {
                DeweyDecimalSystem item = deweyItems.Values.ElementAt(i);
                if (item.Low == "" || item.Mid == "") {
                    deweyItems.Remove(deweyItems.Keys.ElementAt(i));
                }
            }
            return deweyItems;
        }

        public Dictionary<String, DeweyDecimalSystem> GenerateRandomCallNumbers(int numbers) {
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
                DeweyDecimalSystem temp = GenerateDescriptions(callNumber);
                deweyItems.Add(callNumber, temp);
            }
            return deweyItems;
        }

        public DeweyDecimalSystem GenerateDescriptions(String call) {
            DeweyDecimalSystem item = new DeweyDecimalSystem();
            String name;
            if (call.Length <= 3) {
                name = call;
            } else {
                name = call.Substring(0, 3);
            }
            switch (Int32.Parse(name)) {
                case 0:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "Computer science, information & general works";
                    return item;
                case 1:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "Knowledge";
                    return item;
                case 2:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "The book";
                    return item;
                case 3:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "Systems";
                    return item;
                case 4:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "Data processing & computer science";
                    return item;
                case 5:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "Computer programming, programs & data";
                    return item;
                case 6:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "Special computer methods";
                    return item;
                case int n when (n >= 7 && n <= 9):
                    item.High = "Computer science, information & general works";
                    item.Mid = "Computer science, knowledge & systems";
                    item.Low = "";
                    return item;
                case 10:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Bibliography";
                    return item;
                case 11:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Bibliographies";
                    return item;
                case 12:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Bibliographies of individuals";
                    return item;
                case 13:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "";
                    return item;
                case 14:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Bibliographies of anonymous & pseudonymous works";
                    return item;
                case 15:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Bibliographies of works from specific places";
                    return item;
                case 16:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Bibliographies of works on specific subjects";
                    return item;
                case 17:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "General subject catalogs";
                    return item;
                case 18:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Catalogs arranged by author, date, etc.";
                    return item;
                case 19:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Bibliographies";
                    item.Low = "Dictionary catalogs";
                    return item;
                case 20:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Library & information sciences";
                    return item;
                case 21:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Library relationships";
                    return item;
                case 22:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Library relationships";
                    return item;
                case 23:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Library relationships";
                    return item;
                case 24:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "";
                    return item;
                case 25:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Library operations";
                    return item;
                case 26:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Libraries for specific subjects";
                    return item;
                case 27:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "General libraries";
                    return item;
                case 28:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "Reading & use of other information media";
                    return item;
                case 29:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Library & information sciences";
                    item.Low = "";
                    return item;
                case 30:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "General encyclopedic works";
                    return item;
                case 31:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in American English";
                    return item;
                case 32:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in English";
                    return item;
                case 33:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in other Germanic languages";
                    return item;
                case 34:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in French, Occitan, and Catalan";
                    return item;
                case 35:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in Italian, Romanian, and related languages";
                    return item;
                case 36:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in Spanish & Portuguese";
                    return item;
                case 37:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in Slavic languages";
                    return item;
                case 38:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in Scandinavian languages";
                    return item;
                case 39:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Encyclopedias & books of facts";
                    item.Low = "Encyclopedias in other languages";
                    return item;
                case int n when (n >= 40 && n <= 49):
                    item.High = "Computer science, information & general works";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case 50:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "General serial publications";
                    return item;
                case 51:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in American English";
                    return item;
                case 52:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in English";
                    return item;
                case 53:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in other Germanic languages";
                    return item;
                case 54:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in French, Occitan, and Catalan";
                    return item;
                case 55:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in Italian, Romanian, and related languages";
                    return item;
                case 56:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in Spanish & Portuguese";
                    return item;
                case 57:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in Slavic languages";
                    return item;
                case 58:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in Scandinavian languages";
                    return item;
                case 59:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Magazines, journals & serials";
                    item.Low = "Serials in other languages";
                    return item;
                case 60:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "General organizations & museum science";
                    return item;
                case 61:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in North America";
                    return item;
                case 62:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in British Isles; in England";
                    return item;
                case 63:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in central Europe; in Germany";
                    return item;
                case 64:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in France & Monaco";
                    return item;
                case 65:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in Italy & adjacent islands";
                    return item;
                case 66:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in Iberian peninsula & adjacent islands";
                    return item;
                case 67:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in eastern Europe; in Russia";
                    return item;
                case 68:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Organizations in other geographic areas";
                    return item;
                case 69:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Associations, organizations & museums";
                    item.Low = "Museum science";
                    return item;
                case 70:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "News media, journalism, and publishing";
                    return item;
                case 71:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in North America";
                    return item;
                case 72:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in British Isles; in England";
                    return item;
                case 73:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in central Europe; in Germany";
                    return item;
                case 74:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in France & Monaco";
                    return item;
                case 75:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in Italy & adjacent islands";
                    return item;
                case 76:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in Iberian peninsula & adjacent islands";
                    return item;
                case 77:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in eastern Europe; in Russia";
                    return item;
                case 78:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in Scandinavia";
                    return item;
                case 79:
                    item.High = "Computer science, information & general works";
                    item.Mid = "News media, journalism & publishing";
                    item.Low = "Newspapers in other geographic areas";
                    return item;
                case 80:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "General collections";
                    return item;
                case 81:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in American English";
                    return item;
                case 82:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in English";
                    return item;
                case 83:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in other Germanic languages";
                    return item;
                case 84:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in French, Occitan, Catalan";
                    return item;
                case 85:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in Italian, Romanian, & related languages";
                    return item;
                case 86:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in Spanish & Portuguese";
                    return item;
                case 87:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in Slavic languages";
                    return item;
                case 88:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in Scandinavian languages";
                    return item;
                case 89:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Quotations";
                    item.Low = "Collections in other languages";
                    return item;
                case 90:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Manuscripts and rare books";
                    return item;
                case 91:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Manuscripts";
                    return item;
                case 92:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Block books";
                    return item;
                case 93:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Incunabula";
                    return item;
                case 94:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Printed books";
                    return item;
                case 95:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Books notable for bindings";
                    return item;
                case 96:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Books notable for illustrations";
                    return item;
                case 97:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Books notable for ownership or origin";
                    return item;
                case 98:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Prohibited works, forgeries, and hoaxes";
                    return item;
                case 99:
                    item.High = "Computer science, information & general works";
                    item.Mid = "Manuscripts & rare books";
                    item.Low = "Books notable for format";
                    return item;
                case int n when (n >= 100 && n < 200):
                    item.High = "Philosophy & psychology";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 200 && n < 300):
                    item.High = "Religion";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 300 && n < 400):
                    item.High = "Social sciences";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 400 && n < 500):
                    item.High = "Language";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 500 && n < 600):
                    item.High = "Science";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 600 && n < 700):
                    item.High = "Technology";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 700 && n < 800):
                    item.High = "Arts & recreation";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 800 && n < 900):
                    item.High = "Literature";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                case int n when (n >= 900 && n < 1000):
                    item.High = "History & geography";
                    item.Mid = "";
                    item.Low = "";
                    return item;
                default:
                    item.High = "";
                    item.Mid = "";
                    item.Low = "";
                    return item;
            }
        }
    }
}