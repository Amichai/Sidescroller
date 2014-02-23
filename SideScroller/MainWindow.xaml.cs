using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            var platform = BoardElementFactory.CreatePlatform(800, 50, Vec2.New(100, 600));
            boardLayout.Elements.Add(platform);
            this.currentBoardLayout = boardLayout;
            var left = this.Width / 2;
            this.mainCharacter = new Character(Vec2.New(left, 150));
            loadBoardLayout(boardLayout);
            collisionDetector = new CollisionDetector();
            collisionDetector.Add(this.mainCharacter);
            collisionDetector.AddRange(boardLayout.Elements);

            this.gravityTimer = new Timer(gameTimeUpdate, null, 0, 40);
        }

        private void gameTimeUpdate(object state) {
            this.mainCharacter.UpdatePosition();
            checkForCollision();

            try {
                this.currentBoardLayout.Right();
            } catch (Exception ex) {
                Debug.Print(ex.Message);
            }
        }

        private void checkForCollision() {
            try {
                App.Current.Dispatcher.Invoke((Action)(() => {
                    double restingPlane;
                    if (collisionDetector.CheckForCollision(out restingPlane)) {
                        this.mainCharacter.Rest(restingPlane);
                    } else {
                        this.mainCharacter.NotResting();
                    }
                }));
            } catch {

            }
        }

        public Timer gravityTimer;
        private CollisionDetector collisionDetector;
        private BoardLayout currentBoardLayout;
        private Character mainCharacter;

        private void loadBoardLayout(BoardLayout layout) {
            this.layoutRoot.Children.Add(layout.ImageControl);
            this.layoutRoot.Width = layoutRoot.Width;
            this.layoutRoot.Height = layoutRoot.Height;
            ///Sets the background image
            Canvas.SetLeft(this.currentBoardLayout.ImageControl, 0);
            Canvas.SetTop(this.currentBoardLayout.ImageControl, 0);

            foreach (var e in this.currentBoardLayout.Elements) {
                this.layoutRoot.Children.Add(e.Sprite);
                e.Redraw();
            }

            this.layoutRoot.Children.Add(this.mainCharacter.Sprite);
            this.mainCharacter.ResetPosition();
        }

        private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Left:
                    this.currentBoardLayout.Left();
                    break;
                case Key.Right:
                    this.currentBoardLayout.Right();
                    break;
                case Key.Up:
                    this.mainCharacter.Jump();
                    //this.currentBoardLayout.Up();
                    break;
                case Key.Down:
                    //this.currentBoardLayout.Down();
                    break;
                case Key.R:
                    reset();
                    break;
            }
        }

        private void reset() {
            this.mainCharacter.ResetPosition();
            this.currentBoardLayout.Reset();
        }

        private void window_SizeChanged_1(object sender, SizeChangedEventArgs e) {
            this.mainCharacter.ResetPosition();
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
