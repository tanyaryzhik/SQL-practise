using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _01._04_practise.Tools
{
    public class LanguageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (((Model.Language)value))
            {
                case Model.Language.English:
                    return new SolidColorBrush(Colors.Yellow);
                case Model.Language.Russian:
                    return new SolidColorBrush(Colors.Red);
                case Model.Language.Ukrainian:
                    return new SolidColorBrush(Colors.Blue);
                default: return new SolidColorBrush(Colors.Transparent);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
