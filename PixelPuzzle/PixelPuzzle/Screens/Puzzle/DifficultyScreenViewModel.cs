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

        public override string Title => Difficulty.ToString();

        public async Task GoToLevel(Level level) {
            await Context.UI.GoToGame(level);
        }

        public async Task GoToRandom() {
            await Context.UI.GoToGame(new Level(1, Difficulty, MapGenerator.GenerateRandom(GetRandomSize()), true));
        }

        private int GetRandomSize() {
            switch (Difficulty) {
                case Difficulty.Easy:
                    return Game.Small;
                case Difficulty.Medium:
                    return Game.Medium;
                case Difficulty.Hard:
                    return Game.Large;
                default:
                    return Game.Small;
            }
        }
    }
}
