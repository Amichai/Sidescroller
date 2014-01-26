using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SideScroller {
    class Character : BoardElement
    {
        public Character() {
            this.Sprite = new Rectangle() {
                Width = 20,
                Height = 80,
                Fill = new SolidColorBrush(Colors.Green)
            };
            this.SetPosition(Pos.Zero());
            this.gravityTimer = new Timer(gravityUpdate, null, 0, 40);
        }

        public void SetPosition(Pos pos) {
            Canvas.SetLeft(Sprite, pos.X);
            Canvas.SetTop(Sprite, pos.Y);
            this.Position = pos;
        }

        
        public double gravityStrength = 0.5, gravityAccel = 0.1;
        public bool accel = false;

        private void gravityUpdate(object state)
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                gravityStrength += gravityAccel;
                if (accel)
                {
                    gravityAccel++;
                    accel = false;
                }
                else accel = true;
                    
                SetPosition(new Pos()
                {
                    X = this.Position.X,
                    Y = this.Position.Y + gravityStrength,
                });


            }));
        }

        private void checkforCollision()
        {
            double characterBottom = this.Position.Y + this.Sprite.Height;
        }

        public void reset()
        {
            gravityStrength = 0;
            gravityAccel = 0;
        }
    }
}
