using PixelPuzzle.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.About {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScreen : ContentPage {
        public InfoScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new InfoScreenViewModel(context);
        }
    }
}