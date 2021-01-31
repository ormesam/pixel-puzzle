using Xamarin.Forms;

namespace PixelPuzzle.Controls {
    public class AdMobViewWrapper : StackLayout {
        public AdMobViewWrapper() {
            VerticalOptions = LayoutOptions.End;

            Children.Add(new AdMobView {
                VerticalOptions = LayoutOptions.End,
            });
        }
    }
}
