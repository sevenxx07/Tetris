using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tetris.Models;

namespace Tetris.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public Game Game { get; set; } = new Game();

        public NextFieldViewModel nextField = new NextFieldViewModel();

        private bool _lightmode;
        private int _score;
        private int _bestScore;
        private bool _gameOver;
        private ImageSource _nextImage;
        private bool _openedDialog;

        private readonly int maxDelay = 1000;
        private readonly int minDelay = 75;
        private readonly int delayDecrease = 5;

        private Canvas Game_canvas;

        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative))
        };

        private readonly Image[,] grid;
        
        public ImageSource NextImage 
        {
            get { return _nextImage; }
            set { _nextImage = value;
                OnPropertyChanged(nameof(NextImage));
            }
        }
        public bool GameOver
        {
            get { return _gameOver; }
            set
            {
                _gameOver = value;
                OnPropertyChanged(nameof(GameOver));
            }
        }
        public bool Lightmode { 
            get { return _lightmode; }
            set
            {
                _lightmode = value;
                OnPropertyChanged(nameof(Lightmode));
            } }
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
        public int BestScore
        {
            get { return _bestScore; }
            set
            {
                _bestScore = value;
                OnPropertyChanged(nameof(BestScore));
            }
        }

        public GameViewModel(Canvas gameGrid)
        {
            Lightmode = true;
            GameOver = false;
            Game_canvas = gameGrid;
            grid = SetupGame(Game.Field);
            BestScore = 0;
            Score = 0;
            _openedDialog = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }


        private Image[,] SetupGame(Field field)
        {
            Image[,] grid = new Image[field.Rows, field.Columns];
            int cellSize = 25;

            for (int r = 0; r < field.Rows; r++)
            {
                for (int c = 0; c < field.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    Game_canvas.Children.Add(imageControl);
                    grid[r, c] = imageControl;
                }
            }

            return grid;
        }

        private void DrawGrid(Field field)
        {
            for (int r = 0; r < field.Rows; r++)
            {
                for (int c = 0; c < field.Columns; c++)
                {
                    int id = field[r, c];
                    grid[r, c].Opacity = 1;
                    grid[r, c].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                grid[p.Row, p.Column].Opacity = 1;
                grid[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }

        public void Draw(Game gameState)
        {
            DrawGrid(Game.Field);
            DrawBlock(gameState.CurrentBlock);
            NextImage = nextField.DrawNextBlock(Game.NextBlock);
            Score = Game.Score;
            
        }

        private async Task GameLoop()
        {
            Draw(Game);

            while (!Game.GameOver)
            {
                while (_openedDialog)
                {
                    await Task.Delay(1000);
                }
                int delay = Math.Max(minDelay, maxDelay - (Game.Score * delayDecrease));
                await Task.Delay(delay);
                Game.MoveBlockDown();
                Draw(Game);
            }

            GameOver = true;
            if(Score > BestScore)
            {
                BestScore = Score;
            }
        }


        public void openSettings()
        {
            _openedDialog = true;
            var Settings = new SettingsWindow(this);

            Settings.ShowDialog();
            _openedDialog = false;
        }

        public async void NewGame()
        {
            Game = new Game();
            GameOver = false;
            Score = 0;
            await GameLoop();
        }

        public async void GameLoaded()
        {
            await GameLoop();
        }

        public void stopGame()
        {
            if (_openedDialog)
            {
                _openedDialog = false;
            }
            else
            {
                _openedDialog = true;
            }
        }


    }
}
