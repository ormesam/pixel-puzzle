using System;
using System.Globalization;
using Xamarin.Forms;

namespace PixelPuzzle.Converters {
    public class CellColourConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return Color.White;
            }

            if (value is bool boolValue) {
                return boolValue ? Color.Black : Color.White;
            }

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
