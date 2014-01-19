using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SideScroller {
    class Character {
        public Character() {
            this.Avatar = new Rectangle() {
                Width = 20,
                Height = 80,
                Fill = new SolidColorBrush(Colors.Green)
            };
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
    }
}
