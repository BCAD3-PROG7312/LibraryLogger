using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogger.Functions {
    public class DeweyDecimalSystem {
        public string High, Mid, Low;

        public DeweyDecimalSystem() { }

        public DeweyDecimalSystem(string high, string mid, string low) {
            High = high;
            Mid = mid;
            Low = low;
        }
    }
}
