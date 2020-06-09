using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public PuzzleScreenViewModel(MainContext context, int size) : base(context) {
            PuzzleControlViewModel = new PuzzleControlViewModel(context, size);
        }
    }
}
