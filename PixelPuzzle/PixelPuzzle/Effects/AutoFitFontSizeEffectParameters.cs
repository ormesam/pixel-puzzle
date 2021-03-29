using Xamarin.Forms;

namespace PixelPuzzle.Effects {
    public class AutoFitFontSizeEffectParameters {
        public static BindableProperty MaxFontSizeProperty = BindableProperty.CreateAttached("MaxFontSize", typeof(int), typeof(AutoFitFontSizeEffectParameters), 14, BindingMode.Default);
        public static BindableProperty MinFontSizeProperty = BindableProperty.CreateAttached("MinFontSize", typeof(int), typeof(AutoFitFontSizeEffectParameters), 14, BindingMode.Default);

        public static int GetMaxFontSize(BindableObject bindable) {
            return (int)bindable.GetValue(MaxFontSizeProperty);
        }

        public static int GetMinFontSize(BindableObject bindable) {
            return (int)bindable.GetValue(MinFontSizeProperty);
        }

        public static void SetMaxFontSize(BindableObject bindable, int value) {
            bindable.SetValue(MaxFontSizeProperty, value);
        }

        public static void SetMinFontSize(BindableObject bindable, int value) {
            bindable.SetValue(MinFontSizeProperty, value);
        }
    }
}
