using System.Collections.Generic;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class DifficultyScreenViewModel : ViewModelBase {
        public Difficulty Difficulty { get; }
        public IList<Level> Levels => Context.Model.GetLevels(Difficulty);

        public DifficultyScreenViewModel(MainContext context, Difficulty difficulty) : base(context) {
            Difficulty = difficulty;
        }

        public async Task GoToLevel(Level level) {
            await Context.UI.GoToGame(level);
        }

        public override string Title => Difficulty.ToString();
    }
}
