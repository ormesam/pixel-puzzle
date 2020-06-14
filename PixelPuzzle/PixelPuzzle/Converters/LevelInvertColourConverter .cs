using System;
using System.Globalization;
using Xamarin.Forms;

namespace PixelPuzzle.Converters {
    public class LevelInvertColourConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return Color.Default;
            }

            if (value is bool levelValue) {
                return levelValue ? Color.White : Color.Default;
            }

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
