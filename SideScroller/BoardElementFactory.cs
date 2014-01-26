using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SideScroller {
    public static class BoardElementFactory {
        public static BoardElement CreatePlatform(double width, double height, Pos pos){
            var toReturn = new BoardElement();
            var rect = new Rectangle() {
                Width = width, 
                Height = height,
                Fill = new SolidColorBrush(Colors.Red),
            };
            toReturn.Sprite = rect;
            toReturn.Position = pos;
            return toReturn;
        }
    }
}
