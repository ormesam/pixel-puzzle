using Xamarin.Forms;

namespace PixelPuzzle.Controls {
    public class AdMobView : View {
        public AdMobView() {
            var size = 60;

            switch (App.PhoneScreenSize) {
                case Utility.ScreenSize.Small:
                    size = 32;
                    break;
                case Utility.ScreenSize.Medium:
                    size = 50;
                    break;
            }

            HeightRequest = size;
        }
    }
}
