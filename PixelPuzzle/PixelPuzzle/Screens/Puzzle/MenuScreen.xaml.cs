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
            await ViewModel.GoToGame(Game.Tutorial);
        }

        private async void Easy_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToGame(Game.Small);
        }

        private async void Medium_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToGame(Game.Medium);
        }

        private async void Hard_Clicked(object sender, EventArgs e) {
            await ViewModel.GoToGame(Game.Large);
        }
    }
}