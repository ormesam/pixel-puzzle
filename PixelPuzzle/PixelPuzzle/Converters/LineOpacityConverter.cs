using System;
using System.Globalization;
using Xamarin.Forms;

namespace PixelPuzzle.Converters {
    public class LineOpacityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return 0;
            }

            if (value is bool boolValue) {
                return boolValue ? .5 : 1;
            }

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
