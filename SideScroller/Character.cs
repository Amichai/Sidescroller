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
    class Character {
        public Character() {
            this.Avatar = new Rectangle() {
                Width = 20,
                Height = 80,
                Fill = new SolidColorBrush(Colors.Green)
            };
            this.SetPosition(Pos.Zero());
            this.gravityTimer = new Timer(gravityUpdate, null, 0, 40);
        }

        public Rectangle Avatar { get; set; }

        private Pos position;
        public Pos Position {
            get { return position; }
        }
       

        public void SetPosition(Pos pos) {
            Canvas.SetLeft(Avatar, pos.X);
            Canvas.SetTop(Avatar, pos.Y);
            this.position = pos;
        }

        private Timer gravityTimer;
        
        public int gravityStrength = 1, gravityAccel = 1;
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
    }
}
