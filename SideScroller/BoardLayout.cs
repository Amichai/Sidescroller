using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SideScroller {
    class BoardLayout {
        public BoardLayout(string backgroundImgPath) {
            this.BackgroundImageFilepath = backgroundImgPath;
            this.ImageControl = new Image();
            this.ImageControl.Source = new BitmapImage(new Uri(this.BackgroundImageFilepath, UriKind.Relative));
            this.Elements = new List<BoardElement>();
        }

        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        /// <summary>
        /// The filepath to the background image for this board
        /// </summary>
        public string BackgroundImageFilepath { get; private set; }

        /// <summary>
        /// This is the WPF control that will be added to layoutRoot game Canvas
        /// This control is rendered from the backgroundImage filepath property
        /// </summary>
        public Image ImageControl { get; private set; }

        public List<BoardElement> Elements { get; set; }


        public void Left() {
            double l, m;
            l = Canvas.GetLeft(this.ImageControl);
            m = l + stepSize;
            if (m > 0) {
                m = 0;
                Canvas.SetLeft(this.ImageControl, m);
                return;
            }

            Canvas.SetLeft(this.ImageControl, m);
            foreach (var e in Elements) {
                e.Position.X += stepSize;
                e.Redraw();
            }
        }

        private double stepSize = 10;

        public void Right() {
            double l, m;
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                l = Canvas.GetLeft(this.ImageControl);
                m = l - stepSize;
                if (-m > this.BoardWidth)
                {
                    m = -this.BoardWidth;
                    Canvas.SetLeft(this.ImageControl, m);
                    return;
                }
                Canvas.SetLeft(this.ImageControl, m);
            foreach (var e in Elements) {
                e.Position.X -= stepSize;
                e.Redraw();
            }
            }));
        }

        public void Up() {
            double t, m;
            t = Canvas.GetTop(this.ImageControl);
            m = t + stepSize;
            if (m > 0) {
                m = 0;
                Canvas.SetTop(this.ImageControl, m);
                return;
            }
            Canvas.SetTop(this.ImageControl, m);
        }

        internal void Down() {
            double t, m;
            t = Canvas.GetTop(this.ImageControl);
            m = t - stepSize;
            if (m < -this.BoardHeight) m = -this.BoardHeight;
            Canvas.SetTop(this.ImageControl, m);
        }

        public void Reset()
        {
            Canvas.SetTop(this.ImageControl, 0);
            Canvas.SetLeft(this.ImageControl, 0);
        }
    }
}
