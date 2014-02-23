using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public BoardElement(Vec2 pos) {
            this.Position = pos;
            this.initialPosition = pos.Clone();
            this.initialVelocity = Vec2.Zero();
        }

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

        private Vec2 initialPosition;
        private Vec2 initialVelocity;

        public virtual void ResetPosition() {
            this.Position = initialPosition.Clone();
            this.Velocity = initialVelocity.Clone();
        }
    }
}
