using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle.UserControls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameComplete : ContentView {
        public GameComplete() {
            InitializeComponent();
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        private void Complete_Clicked(object sender, EventArgs e) {
            ViewModel.Restart();
        }
    }
}