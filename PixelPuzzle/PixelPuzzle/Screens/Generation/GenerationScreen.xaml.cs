using System;
using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Generation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerationScreen : ContentPage {
        public GenerationScreen(MainContext context, int size) {
            InitializeComponent();
            BindingContext = new GenerationScreenViewModel(context, size);
        }
        public GenerationScreen(MainContext context, int[,] map) {
            InitializeComponent();
            BindingContext = new GenerationScreenViewModel(context, map);
        }

        public GenerationScreenViewModel ViewModel => BindingContext as GenerationScreenViewModel;

        private async void Back_Clicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }

        private async void Generate_Clicked(object sender, EventArgs e) {
            await ViewModel.Generate();
        }
    }
}