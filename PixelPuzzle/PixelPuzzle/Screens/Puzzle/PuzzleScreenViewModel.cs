using System.Linq;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        private Level level;

        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public string CompletedPercentage {
            get {
                var levels = Context.Model.GetLevels(level.Difficulty);
                var complete = levels
                    .Where(i => i.IsComplete)
                    .Count();

                return $"{complete}/{levels.Count}";
            }
        }

        public PuzzleScreenViewModel(MainContext context, Level level) : base(context) {
            this.level = level;

            PuzzleControlViewModel = new PuzzleControlViewModel(context, level.Map);

            if (level.UserMap != null) {
                PuzzleControlViewModel.Game.ApplyUserValues(level.UserMap);
            }
        }

        public async Task SaveGameState() {
            await Context.Model.SaveLevel(level.LevelNumber, level.Difficulty, PuzzleControlViewModel.Game.GetUserMap(), PuzzleControlViewModel.IsComplete);
        }
    }
}
