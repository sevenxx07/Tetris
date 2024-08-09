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
using System.Windows.Shapes;
using Tetris.ViewModel;
using static System.Formats.Asn1.AsnWriter;

namespace Tetris
{
    /// <summary>
    /// Interakční logika pro SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {

        private GameViewModel mainWindow;

        private SettingsWindow()
        {
            InitializeComponent();
            mode_cb.SelectedIndex= 0;
        }

        public SettingsWindow(GameViewModel gameViewModel) : this()
        {
            this.mainWindow = gameViewModel;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mode_cb.SelectedIndex == 0)
            {
                mainWindow.Lightmode = true;
            }
            else
            {
                mainWindow.Lightmode = false;
            }
            DialogResult = true;
        }
    }
}
