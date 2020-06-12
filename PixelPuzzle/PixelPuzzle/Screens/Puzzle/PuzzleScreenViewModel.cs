using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public PuzzleScreenViewModel(MainContext context, Level level) : base(context) {
            PuzzleControlViewModel = new PuzzleControlViewModel(context, level.Map);
        }
    }
}
