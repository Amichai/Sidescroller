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
    {///new Character()
        public Character(Vec2 initialPosition) : base(initialPosition){
            this.Sprite = new Rectangle() {
                Width = 20,
                Height = 80,
                Fill = new SolidColorBrush(Colors.Green)
            };
        }

        public void SetPosition(Vec2 pos) {
            ///Update the position of the character on screen:
            App.Current.Dispatcher.BeginInvoke((Action)(() => {
                Canvas.SetLeft(Sprite, pos.X);
                Canvas.SetTop(Sprite, pos.Y);
            }));
            this.lastPosition = this.Position;
            this.Position = pos;

            if (this.timeSinceLastUpdate == 0) {
                return;
            }

            if (this.Position != null && this.lastPosition != null) {
                ///Calculate the current velocity of our character:
                ///
                double vx = (this.Position.X - this.lastPosition.X) / timeSinceLastUpdate;
                double vy = (this.Position.Y - this.lastPosition.Y) / timeSinceLastUpdate;
                this.Velocity = Vec2.New(vx, vy);
            } 

            ///Update position values:
            this.lastPositionUpdateTime = DateTime.Now;
            if (this.Velocity != null) {
                //Debug.Print(string.Format("New Position: {0}, dt: {1}, velocity: {2}", pos.ToString(), timeSinceLastUpdate.ToString(), this.Velocity.ToString()));
            }
        }



        public void UpdatePosition() {
                    positionUpdate();
            try {
                
            } catch (Exception ex) {

            }
        }

        private Vec2 lastPosition;
        private DateTime lastPositionUpdateTime;
        private double timeSinceLastUpdate {
            get {
                return (DateTime.Now - this.lastPositionUpdateTime).TotalMilliseconds;
            }
        }

        private const double ay = .001;

        private void positionUpdate() {
            ///y = y0 + vy * dt + .5 * ay * dt^2
            double vy = 0;
            if (this.Velocity != null) {
                vy = this.Velocity.Y;
            }
            double dy = vy * timeSinceLastUpdate + .5 * ay * Math.Pow(timeSinceLastUpdate, 2);

            if (this.resting) {
                dy = 0;
            }

            Vec2 newPosition = new Vec2() {
                X = this.Position.X,
                Y = this.Position.Y + dy,
            };

            try {
                SetPosition(newPosition);
            } catch {

            }
        }

        private void checkforCollision()
        {
            double characterBottom = this.Position.Y + this.Sprite.Height;
        }

        public override void ResetPosition() {
            base.ResetPosition();
            this.resting = false;
        }

        /// <summary>
        /// This variable is used to indicate if our character is "walking" on a platform
        /// </summary>
        private bool resting = false;

        /// <param name="restingPlane">This is the height of the platform that our character is walking on.</param>
        internal void Rest(double restingPlane) {
            this.resting = true;
            this.SetPosition(Vec2.New(this.Position.X, restingPlane - this.Height));
        }

        internal void Jump() {
            this.resting = false;
            this.Velocity = Vec2.New(0, -.4);
            
        }
    }
}
