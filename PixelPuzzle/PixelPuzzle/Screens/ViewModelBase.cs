using PixelPuzzle.Contexts;
using PixelPuzzle.Utility;
using Xamarin.Essentials;

namespace PixelPuzzle.Screens {
    public class ViewModelBase : NotifyPropertyChangedBase {
        public MainContext Context { get; }

        public ViewModelBase(MainContext context) {
            Context = context;
        }

        public virtual string Title => "Pixel Puzzle";

        public int ToolbarHeight => DeviceDisplay.MainDisplayInfo.Height <= 480 ? 45 : 60;

        public int ToolbarButtonSize => DeviceDisplay.MainDisplayInfo.Height <= 480 ? 40 : 50;
    }
}
