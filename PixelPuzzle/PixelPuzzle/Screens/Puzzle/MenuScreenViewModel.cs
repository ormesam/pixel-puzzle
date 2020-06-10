using System.Threading.Tasks;
using PixelPuzzle.Contexts;

namespace PixelPuzzle.Screens.Puzzle {
    public class MenuScreenViewModel : ViewModelBase {
        public MenuScreenViewModel(MainContext context) : base(context) {
        }

        public async Task GoToGame(int size) {
            await Context.UI.GoToGame(size);
        }

        public async Task GoToTutorial() {
            await Context.UI.GoToTutorial();
        }
    }
}
