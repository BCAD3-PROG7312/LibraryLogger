using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogger.Functions {
    public class DeweyDecimalSystem {
        private String High;
        private String Mid;
        private String Low;

        public DeweyDecimalSystem() {}

        public DeweyDecimalSystem(string high, string mid, string low) {
            High = high;
            Mid = mid;
            Low = low;
        }

        public string High1 { get => High; set => High = value; }
        public string Mid1 { get => Mid; set => Mid = value; }
        public string Low1 { get => Low; set => Low = value; }
    }
}
