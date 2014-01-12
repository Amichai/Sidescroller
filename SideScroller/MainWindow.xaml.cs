using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SideScroller {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var boardLayout = new BoardLayout(@"..\..\Assets\background1.jpg") {
                BoardWidth = 1000,
                BoardHeight = 500,
            };
            this.currentBoardLayout = boardLayout;
            loadBoardLayout(boardLayout);
        }

        private BoardLayout currentBoardLayout;

        private void loadBoardLayout(BoardLayout layout) {
            this.layoutRoot.Children.Add(layout.ImageControl);
            this.layoutRoot.Width = layoutRoot.Width;
            this.layoutRoot.Height = layoutRoot.Height;
            Canvas.SetLeft(this.currentBoardLayout.ImageControl, 0);
            Canvas.SetTop(this.currentBoardLayout.ImageControl, 0);
        }

        private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e) {
            double l, t, m, screenMoveSpeed = 10;
            switch (e.Key) {
                case Key.Left:
                    l = Canvas.GetLeft(this.currentBoardLayout.ImageControl);
                    m = l + screenMoveSpeed;
                    if (m > 0) m = 0;
                    Canvas.SetLeft(this.currentBoardLayout.ImageControl, m);
                    break;
                case Key.Right:
                    l = Canvas.GetLeft(this.currentBoardLayout.ImageControl);
                    m = l - screenMoveSpeed;
                    if (-m > this.currentBoardLayout.BoardWidth) m = -this.currentBoardLayout.BoardWidth;
                    Canvas.SetLeft(this.currentBoardLayout.ImageControl, m);
                    break;
                case Key.Up:
                    t = Canvas.GetTop(this.currentBoardLayout.ImageControl);
                    m = t + screenMoveSpeed;
                    if (m > 0) m = 0;
                    Canvas.SetTop(this.currentBoardLayout.ImageControl, m);
                    break;
                case Key.Down:
                    t = Canvas.GetTop(this.currentBoardLayout.ImageControl);
                    m = t - screenMoveSpeed;
                    if (m < -this.currentBoardLayout.BoardHeight) m = -this.currentBoardLayout.BoardHeight;
                    Canvas.SetTop(this.currentBoardLayout.ImageControl, m);
                    break;
            }
        }
    }

    ///Architecture:
    ///1 - World
    /// a) Level configuration
    ///2 - Physics engine
    /// a) Gravity, collisions
    ///3 - Character
    /// a) Graphic, properties
}
