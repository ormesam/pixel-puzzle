using Android.Util;
using Android.Widget;
using PixelPuzzle.Effects;
using Xamarin.Forms.Platform.Android;

namespace PixelPuzzle.Droid.Effects {
    public class AutoFitFontSizeEffect : PlatformEffect {
        protected override void OnAttached() {
            if (this.Control is TextView textView) {
                var min = (int)AutoFitFontSizeEffectParameters.GetMinFontSize(this.Element);
                var max = (int)AutoFitFontSizeEffectParameters.GetMaxFontSize(this.Element);

                if (max <= min) {
                    return;
                }

                textView.SetAutoSizeTextTypeUniformWithConfiguration(min, max, 1, (int)ComplexUnitType.Sp);
            }
        }

        protected override void OnDetached() {
        }
    }
}