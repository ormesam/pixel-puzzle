using System.Threading.Tasks;
using PixelPuzzle.Logic;
using PixelPuzzle.Screens.Puzzle;
using PixelPuzzle.Screens.Tutorial;
using Xamarin.Forms;

namespace PixelPuzzle.Contexts {
    public class UIContext {
        private readonly MainContext context;
        private bool isNavigating;

        public UIContext(MainContext context) {
            this.context = context;
        }

        private async Task GoToScreenAsync(Page page) {
            if (isNavigating) {
                return;
            }

            isNavigating = true;

            await App.RootPage.Navigation.PushAsync(page);

            isNavigating = false;
        }

        public async Task GoToGame(Level level) {
            await GoToScreenAsync(new PuzzleScreen(context, level));
        }

        public async Task GoToTutorial() {
            await GoToScreenAsync(new TutorialScreen(context));
        }

        public async Task GoToDifficulty(Difficulty difficulty) {
            await GoToScreenAsync(new DifficultyScreen(context, difficulty));
        }
    }
}
