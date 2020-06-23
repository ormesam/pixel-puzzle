using System;
using System.Globalization;
using PixelPuzzle.Logic;
using Xamarin.Forms;

namespace PixelPuzzle.Converters {
    public class LevelBackgroundConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return "bg_tutorial.png";
            }

            if (value is Difficulty difficulty) {
                switch (difficulty) {
                    case Difficulty.Small:
                        return "bg_easy.png";
                    case Difficulty.Medium:
                        return "bg_medium.png";
                    case Difficulty.Large:
                        return "bg_hard.png";
                    default:
                        break;
                }
            }

            return "bg_tutorial.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
