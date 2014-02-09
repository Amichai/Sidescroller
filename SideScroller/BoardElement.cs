﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SideScroller {
    /// <summary>
    /// This class encapsulates enemies and platforms etc.
    /// </summary>
    public class BoardElement {
        public Rectangle Sprite { get; set; }
        public Vec2 Position { get; set; }

        public Vec2 Velocity { get; set; }

        public double Height {
            get {
                return this.Sprite.Height;
            }
        }

        public double Width {
            get {
                return this.Sprite.Width;
            }
        }

        internal void Redraw() {
            Canvas.SetLeft(Sprite, Position.X);
            Canvas.SetTop(Sprite, Position.Y);
        }
    }
}
