using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Game {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        public PuzzleScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new PuzzleScreenViewModel(context);
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            ViewModel.RenderPuzzle(GameGrid);
        }
    }
}