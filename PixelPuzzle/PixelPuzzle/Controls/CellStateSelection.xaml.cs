using System;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellStateSelection : ContentView {
        public CellStateSelection() {
            InitializeComponent();
        }

        public PuzzleControlViewModel ViewModel => BindingContext as PuzzleControlViewModel;

        private void ValueFilled_Tapped(object sender, EventArgs e) {
            ViewModel.SelectedValue = CellValue.Filled;
        }

        private void ValueBlocked_Tapped(object sender, EventArgs e) {
            ViewModel.SelectedValue = CellValue.Blocked;
        }
    }
}