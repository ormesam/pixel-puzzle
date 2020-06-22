using System;
using System.Globalization;
using PixelPuzzle.Logic;
using Xamarin.Forms;

namespace PixelPuzzle.Converters {
    public class CellColourConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return Color.White;
            }

            if (value is CellValue cellValue) {
                switch (cellValue) {
                    case CellValue.Filled:
                        return Color.Black;
                    case CellValue.Blocked:
                        return Color.Transparent;
                    case CellValue.Blank:
                        return Color.White;
                    default:
                        return Color.Default;
                }
            }

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
