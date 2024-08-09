using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.ViewModel
{
    public class CellViewModel
    {
        private float _opacity;

        private string _color;
        public GameViewModel Game { get; set; }
        public string Color {
            get { return _color; }
            set 
            {   _color = value;
                Game.OnPropertyChanged(nameof(Color));
            } 
        }

        public float Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                Game.OnPropertyChanged(nameof(Opacity));
            }
        }
        public CellViewModel(GameViewModel game)
        {
            Game = game;
            Color = "WhiteSmoke";
            Opacity = 1.0f;

        }
    }
}
