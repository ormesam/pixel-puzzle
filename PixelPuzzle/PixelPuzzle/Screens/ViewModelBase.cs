using PixelPuzzle.Contexts;
using PixelPuzzle.Utility;

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
    }
}
