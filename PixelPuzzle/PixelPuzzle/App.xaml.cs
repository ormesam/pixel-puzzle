using PixelPuzzle.Contexts;
using PixelPuzzle.Screens.Puzzle;
using Xamarin.Forms;

namespace PixelPuzzle {
    public partial class App : Application {
        public static NavigationPage RootPage => Current.MainPage as NavigationPage;

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuScreen(new MainContext()));
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
