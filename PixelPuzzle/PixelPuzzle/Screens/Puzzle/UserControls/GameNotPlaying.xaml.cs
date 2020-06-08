using System;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle.UserControls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameNotPlaying : ContentView {
        public GameNotPlaying() {
            InitializeComponent();
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        private void Tutorial_Clicked(object sender, EventArgs e) {
            ViewModel.CreateGame(Game.Tutorial);
        }

        private void Easy_Clicked(object sender, EventArgs e) {
            ViewModel.CreateGame(Game.Small);
        }

        private void Medium_Clicked(object sender, EventArgs e) {
            ViewModel.CreateGame(Game.Medium);
        }

        private void Hard_Clicked(object sender, EventArgs e) {
            ViewModel.CreateGame(Game.Large);
        }
    }
}