using Xamarin.Forms;

namespace PixelPuzzle.Controls {
    public class AdMobView : View {
        public AdMobView() {
            HeightRequest = App.IsSmallScreen ? 30 : 60;
        }
    }
}
