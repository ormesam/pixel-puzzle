using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuScreen : ContentPage {
        public MenuScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new MenuScreenViewModel(context);
        }

        public MenuScreenViewModel ViewModel => BindingContext as MenuScreenViewModel;

        private async void Tutorial_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToTutorial();
        }

        private async void Easy_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToGame(Difficulty.Easy);
        }

        private async void Medium_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToGame(Difficulty.Medium);
        }

        private async void Hard_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToGame(Difficulty.Hard);
        }
    }
}