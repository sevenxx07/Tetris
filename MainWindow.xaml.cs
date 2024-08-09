using System;
using System.Collections.Generic;
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
using Tetris.ViewModel;
using Tetris.Models;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameViewModel Game
        {
            get { return this.DataContext as GameViewModel; }
            set { this.DataContext = value; }
        }

        public MainWindow()
        {
            this.InitializeComponent();
            this.Game = new GameViewModel(GameGrid);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Game.Game.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.D:
                    Game.Game.MoveBlockRight();
                    break;
                case Key.A:
                    Game.Game.MoveBlockLeft();
                    break;
                case Key.S:
                    Game.Game.MoveBlockDown();
                    break;
                case Key.W:
                    Game.Game.RotateBlockCW();
                    break;
                case Key.Z:
                    Game.Game.RotateBlockCCW();
                    break;
                case Key.Space:
                    Game.Game.DropBlock();
                    break;
                case Key.Left:
                    Game.Game.MoveBlockLeft();
                    break;
                case Key.Right:
                    Game.Game.MoveBlockRight();
                    break;
                case Key.Up:
                    Game.Game.RotateBlockCW();
                    break;
                case Key.Down:
                    Game.Game.MoveBlockDown();
                    break;
                case Key.Enter:
                    Game.stopGame();
                    break;
                default:
                    return;
            }

            Game.Draw(Game.Game);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Game.openSettings();

        }

        private void New_game_Click(object sender, RoutedEventArgs e)
        {
            Game.NewGame();
        }

        private void GameCanvasLoaded(object sender, RoutedEventArgs e)
        {
            Game.GameLoaded();
        }

    }
}
