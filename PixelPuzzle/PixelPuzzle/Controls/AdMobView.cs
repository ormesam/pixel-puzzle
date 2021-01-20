using Xamarin.Forms;

namespace PixelPuzzle.Controls {
    public class AdMobView : View {
        public AdMobView() {
            BackgroundColor = Color.Black;
            HeightRequest = App.IsSmallScreen ? 30 : 60;
        }
    }
}
