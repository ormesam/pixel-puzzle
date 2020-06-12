using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        private Level level;

        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public PuzzleScreenViewModel(MainContext context, Level level) : base(context) {
            this.level = level;

            PuzzleControlViewModel = new PuzzleControlViewModel(context, level.Map);

            if (Context.Model.SavedLevels.TryGetValue(Context.Model.CreateKey(level.LevelNumber, level.Difficulty), out SavedGame savedGame)) {
                PuzzleControlViewModel.Game.ApplyUserValues(savedGame.Map);
            }
        }

        public async Task SaveGameState() {
            await Context.Model.SaveLevel(level.LevelNumber, level.Difficulty, PuzzleControlViewModel.Game.GetUserMap(), PuzzleControlViewModel.IsComplete);
        }
    }
}
