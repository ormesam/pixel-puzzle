using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DifficultyScreen : ContentPage {
        public DifficultyScreen(MainContext context, Difficulty difficulty) {
            InitializeComponent();
            BindingContext = new DifficultyScreenViewModel(context, difficulty);
        }

        public DifficultyScreenViewModel ViewModel => BindingContext as DifficultyScreenViewModel;

        private async void Level_Tapped(object sender, EventArgs e) {
            var cell = sender as Button;
            var level = cell?.BindingContext as Level;

            if (level != null) {
                await ViewModel.GoToLevel(level);
            }
        }

        private async void Back_Clicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }
    }
}