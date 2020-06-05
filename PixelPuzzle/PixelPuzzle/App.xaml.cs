using PixelPuzzle.Contexts;
using PixelPuzzle.Screens.Puzzle;
using Xamarin.Forms;

namespace PixelPuzzle {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new PuzzleScreen(new MainContext());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
