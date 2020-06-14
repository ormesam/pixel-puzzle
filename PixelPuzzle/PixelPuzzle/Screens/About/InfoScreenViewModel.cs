using PixelPuzzle.Contexts;
using Xamarin.Essentials;

namespace PixelPuzzle.Screens.About {
    public class InfoScreenViewModel : ViewModelBase {
        public string VersionNumber => VersionTracking.CurrentVersion;

        public InfoScreenViewModel(MainContext context) : base(context) {
        }
    }
}
