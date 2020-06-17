using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Home {
    public class MainScreenViewModel : ViewModelBase {
        public MainScreenViewModel(MainContext context) : base(context) {
        }

        public async Task GoToGame(Difficulty difficulty) {
            await Context.UI.GoToDifficulty(difficulty);
        }

        public async Task GoToTutorial() {
            await Context.UI.GoToTutorial();
        }
    }
}
