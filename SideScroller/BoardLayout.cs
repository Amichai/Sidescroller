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

    }
}
