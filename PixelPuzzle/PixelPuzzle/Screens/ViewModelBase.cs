using PixelPuzzle.Contexts;
using PixelPuzzle.Utility;
using Xamarin.Essentials;

namespace PixelPuzzle.Screens {
    public class ViewModelBase : NotifyPropertyChangedBase {
        public MainContext Context { get; }

        public ViewModelBase(MainContext context) {
            Context = context;
        }

        public void Refresh() {
            OnPropertyChanged();
        }

        public virtual string Title => "Pixel Puzzle";

        public double ScreenHeight => DeviceDisplay.MainDisplayInfo.Height;

        public double ScreenWidth => DeviceDisplay.MainDisplayInfo.Width;

        // Detect if this is a small phone which doesn;t have much height compared to the width
        // Might need to adjust the layout if this is true
        public bool IsSmallScreen => ScreenHeight < 500 && (ScreenHeight / ScreenWidth) < 1.7;
    }
}
