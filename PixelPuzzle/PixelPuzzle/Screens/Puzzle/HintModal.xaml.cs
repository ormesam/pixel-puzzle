using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HintModal : ContentPage {
        public HintModal(MainContext context, Line line) {
            InitializeComponent();
            BindingContext = new HintModalViewModel(context, line);
        }

        public HintModalViewModel ViewModel => BindingContext as HintModalViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            ViewModel.LoadAd();
        }

        private void DisplayHintAd_Clicked(object sender, EventArgs e) {
            ViewModel.ShowAd(Navigation);
        }
    }
}