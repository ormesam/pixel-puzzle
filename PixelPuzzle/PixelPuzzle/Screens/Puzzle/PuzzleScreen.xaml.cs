using System;
using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        public PuzzleScreen(MainContext context, int size) {
            InitializeComponent();
            BindingContext = new PuzzleScreenViewModel(context, size);
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            PuzzleControl.RenderGame();
        }

        private async void Complete_Clicked(object sender, EventArgs e) {
            await Navigation.PopToRootAsync();
        }
    }
}