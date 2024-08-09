using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Tetris.Convertor
{
    public class intToColorConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int color = (int)value;
            
            if (color == 0 && parameter == null)
            {
                return "White";
            }
            else if(color == 1 && parameter == null)
            {
                return "DarkBlue";
            }else if(color == 0) 
            {
                return "Black";
            }
            else
            {
                return "White";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
