using System.Collections.Generic;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class DifficultyScreenViewModel : ViewModelBase {
        private readonly int difficultySize;
        public Difficulty Difficulty { get; }
        public IList<Level> Levels => Context.Model.GetLevels(Difficulty);

        public DifficultyScreenViewModel(MainContext context, Difficulty difficulty) : base(context) {
            Difficulty = difficulty;
            difficultySize = GetDifficultySize();
        }

        public override string Title => $"{difficultySize} x {difficultySize}";

        public async Task GoToLevel(Level level) {
            await Context.UI.GoToGame(level);
        }

        public async Task GoToRandom() {
            await Context.UI.GoToGame(new Level(1, Difficulty, MapGenerator.GenerateRandom(difficultySize), true));
        }

#if DEBUG
        public bool CanSubmitPuzzles => true;
#else
        public bool CanSubmitPuzzles => false;
#endif

        public async Task GoToGenerationScreen() {
            await Context.UI.GoToGenerationScreen(difficultySize);
        }

        private int GetDifficultySize() {
            switch (Difficulty) {
                case Difficulty.Small:
                    return Game.Small;
                case Difficulty.Medium:
                    return Game.Medium;
                case Difficulty.Large:
                    return Game.Large;
                default:
                    return Game.Small;
            }
        }
    }
}
