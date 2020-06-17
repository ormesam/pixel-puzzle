using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Home {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreen : ContentPage {
        public MainScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new MainScreenViewModel(context);
        }

        public MainScreenViewModel ViewModel => BindingContext as MainScreenViewModel;

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