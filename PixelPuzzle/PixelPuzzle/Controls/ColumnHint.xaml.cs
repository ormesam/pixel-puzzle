using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColumnHint : ContentView {
        public ColumnHint() {
            InitializeComponent();
        }

        private void Line_Tapped(object sender, EventArgs e) {

        }
    }
}