using System;
using PixelPuzzle.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RowHint : ContentView {
        public RowHint() {
            InitializeComponent();
        }

        public Line Line => BindingContext as Line;

        private void Line_Tapped(object sender, EventArgs e) {
        }
    }
}