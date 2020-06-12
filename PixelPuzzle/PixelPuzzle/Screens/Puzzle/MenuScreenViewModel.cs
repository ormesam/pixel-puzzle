using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Puzzle {
    public class MenuScreenViewModel : ViewModelBase {
        public MenuScreenViewModel(MainContext context) : base(context) {
        }

        public async Task GoToGame(Difficulty difficulty) {
            await Context.UI.GoToDifficulty(difficulty);
        }

        public async Task GoToTutorial() {
            await Context.UI.GoToTutorial();
        }
    }
}
