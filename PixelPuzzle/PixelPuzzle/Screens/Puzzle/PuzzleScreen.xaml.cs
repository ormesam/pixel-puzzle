using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        public PuzzleScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new PuzzleScreenViewModel(context, GamePlaying.GetGameGrid());
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;
    }
}