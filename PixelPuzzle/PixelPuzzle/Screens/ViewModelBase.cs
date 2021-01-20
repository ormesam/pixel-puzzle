using PixelPuzzle.Contexts;
using PixelPuzzle.Utility;

namespace PixelPuzzle.Screens {
    public class ViewModelBase : NotifyPropertyChangedBase {
        public MainContext Context { get; }

        public ViewModelBase(MainContext context) {
            Context = context;
        }

        public virtual string Title => "Pixel Puzzle";

        public int ToolbarButtonSize => App.IsSmallScreen ? 40 : 50;
    }
}
