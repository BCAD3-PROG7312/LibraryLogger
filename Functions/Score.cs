using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogger.Functions {
    public class Score {
        public String getScoreStatement(int temp1, int temp2) {
            Double correct = Convert.ToDouble(temp1);
            Double matches = Convert.ToDouble(temp2);
            int score = (int)((correct / matches) *10);
            String statement = "";
            switch (score) {
                case 0: 
                    statement = "Terrible";
                    break;
                case 1:
                    statement = "Still not good";
                    break;
                case 2:
                    statement = "Almost not bad";
                    break;
                case 3:
                    statement = "Could be worse I guess";
                    break;
                case 4:
                    statement = "You can do better";
                    break;
                case 5:
                    statement = "Not the score I was looking for";
                    break;
                case 6:
                    statement = "Eh";
                    break;
                case 7:
                    statement = "Not bad";
                    break;
                case 8:
                    statement = "Pretty good";
                    break;
                case 9:
                    statement = "Noice";
                    break;
                case 10:
                    statement = "5/7";
                    break;
            }
            return statement;
        }
    }
}
