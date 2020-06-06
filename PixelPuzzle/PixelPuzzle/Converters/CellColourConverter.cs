using System;
using System.Globalization;
using PixelPuzzle.Logic;
using Xamarin.Forms;

namespace PixelPuzzle.Converters {
    public class CellColourConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return Color.Default;
            }

            if (value is CellValue cellValue) {
                return cellValue == CellValue.Filled ? Color.Black : Color.White;
            }

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
