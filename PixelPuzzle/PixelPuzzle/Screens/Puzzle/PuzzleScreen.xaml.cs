using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        public PuzzleScreen(MainContext context, Level level) {
            InitializeComponent();
            BindingContext = new PuzzleScreenViewModel(context, level);
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            PuzzleControl.RenderGame();
        }

        protected async override void OnDisappearing() {
            await ViewModel.SaveGameState();

            base.OnDisappearing();
        }

        private async void Complete_Clicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }

        private async void Reset_Clicked(object sender, EventArgs e) {
            bool reset = await DisplayAlert("Reset", "Reset progress?", "Yes", "No");

            if (reset) {
                ViewModel.Reset();
            }
        }

        private async void Info_Clicked(object sender, EventArgs e) {
            await ViewModel.Context.UI.GoToAboutScreen();
        }

        private async void Back_Clicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }
    }
}