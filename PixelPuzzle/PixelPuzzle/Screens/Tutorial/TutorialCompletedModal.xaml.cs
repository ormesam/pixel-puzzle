using System;
using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Tutorial {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialCompletedModal : ContentPage {
        public TutorialCompletedModal(MainContext context) {
            InitializeComponent();
            BindingContext = new TutorialCompleteModalViewModel(context);
        }

        private async void Continue_Clicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync();
        }
    }
}