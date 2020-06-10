using System;
using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Tutorial {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialScreen : ContentPage {
        public TutorialScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new TutorialScreenViewModel(context);
        }

        public TutorialScreenViewModel ViewModel => BindingContext as TutorialScreenViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            PuzzleControl.RenderGame();
        }

        private async void Complete_Clicked(object sender, EventArgs e) {
            await Navigation.PopToRootAsync();
        }
    }
}