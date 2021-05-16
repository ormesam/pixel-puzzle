using System;
using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedModal : ContentPage {
        bool closing = false;

        public CompletedModal(MainContext context) {
            InitializeComponent();
            BindingContext = new TutorialCompleteModalViewModel(context);
        }

        private async void Continue_Clicked(object sender, EventArgs e) {
            if (closing) {
                return;
            }

            closing = true;

            await Navigation.PopModalAsync();
        }
    }
}