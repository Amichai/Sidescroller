using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideScroller {
    public class Vec2 {
        public double X { get; set; }
        public double Y { get; set; }

        public static Vec2 New(double x, double y) {
            return new Vec2() { X = x, Y = y };
        }

        public Vec2 Clone() {
            return new Vec2() { X = X, Y = Y };
        }

        public static Vec2 Zero()
        {
            return new Vec2() { 
            X = 0,
            Y = 0,
            };
        }

        public override string ToString() {
            return string.Format("X: {0}, Y: {1}", this.X, this.Y);
        }
    }
}
