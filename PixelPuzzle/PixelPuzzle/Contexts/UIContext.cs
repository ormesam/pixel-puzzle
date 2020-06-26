using System.Threading.Tasks;
using PixelPuzzle.Logic;
using PixelPuzzle.Screens.About;
using PixelPuzzle.Screens.Generation;
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

        public async Task ShowModal(Page page) {
            if (isNavigating) {
                return;
            }

            isNavigating = true;

            await App.RootPage.Navigation.PushModalAsync(page);

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

        public async Task GoToAboutScreen() {
            await GoToScreenAsync(new InfoScreen(context));
        }

        public async Task GoToGenerationScreen(int size) {
            await GoToScreenAsync(new GenerationScreen(context, size));
        }

        public async Task ShowHintModal(Line line) {
            await ShowModal(new HintModal(context, line));
        }

        public async Task ShowCompletedModal() {
            await ShowModal(new CompletedModal(context));
        }
    }
}
