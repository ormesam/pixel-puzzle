using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        private double startX = 0;
        private double startY = 0;

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