﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SideScroller {
    public static class BoardElementFactory {
        public static BoardElement CreatePlatform(double width, double height, Vec2 pos){
            var toReturn = new BoardElement(pos);
            var rect = new Rectangle() {
                Width = width, 
                Height = height,
                Fill = new SolidColorBrush(Colors.Red),
            };
            toReturn.Sprite = rect;
            return toReturn;
        }
    }
}
