using System.Collections.Generic;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class DifficultyScreenViewModel : ViewModelBase {
        public string Difficulty { get; }
        public IList<Level> Levels { get; }

        public DifficultyScreenViewModel(MainContext context, Difficulty difficulty) : base(context) {
            Difficulty = difficulty.ToString();
            Levels = Context.Model.GetLevels(difficulty);
        }

        public async Task GoToLevel(Level level) {
            await Context.UI.GoToGame(level);
        }
    }
}
