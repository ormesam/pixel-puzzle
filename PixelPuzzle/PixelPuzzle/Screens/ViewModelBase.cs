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

        /*
         * Detect if this is a small phone which doesn;t have much height compared to the width
         * Might need to adjust the layout if this is true
         * Inch  = Ratio
         * 3.4 = 1.8
         * 3.3 = 1.66666
         * 3.2 = 1.5
         * 2.7 = 2.2
        */
        public bool IsSmallScreen => ScreenHeight < 500 && (ScreenHeight / ScreenWidth) < 1.7;
    }
}
