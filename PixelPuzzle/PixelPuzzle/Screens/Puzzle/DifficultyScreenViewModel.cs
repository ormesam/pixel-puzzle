using System.Collections.Generic;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class DifficultyScreenViewModel : ViewModelBase {
        private Difficulty difficulty;

        public string Difficulty => difficulty.ToString();
        public IList<Level> Levels => Context.Model.GetLevels(difficulty);

        public DifficultyScreenViewModel(MainContext context, Difficulty difficulty) : base(context) {
            this.difficulty = difficulty;
        }

        public async Task GoToLevel(Level level) {
            await Context.UI.GoToGame(level);
        }
    }
}
