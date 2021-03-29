using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleCell : ContentView {
        public PuzzleCell() {
            InitializeComponent();
        }
    }
}