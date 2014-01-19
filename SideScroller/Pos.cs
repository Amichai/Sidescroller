using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideScroller {
    public class Pos {
        public double X { get; set; }
        public double Y { get; set; }

        public static Pos New(double x, double y) {
            return new Pos() { X = x, Y = y };
        }
    }
}
