using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;

namespace PixelPuzzle.Screens.Tutorial {
    public class TutorialScreenViewModel : ViewModelBase {
        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public TutorialScreenViewModel(MainContext context) : base(context) {
            PuzzleControlViewModel = new PuzzleControlViewModel(context, CreateTutorialMap());
        }

        private int[,] CreateTutorialMap() {
            return new int[8, 8] {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 1, 1 },
                { 0, 1, 1, 1, 1, 1, 1, 0 },
                { 0, 0, 1, 1, 1, 1, 0, 0 },
            };
        }
    }
}
