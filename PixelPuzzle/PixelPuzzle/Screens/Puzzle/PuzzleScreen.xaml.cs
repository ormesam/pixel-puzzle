using System.Linq;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using PixelPuzzle.Touch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        public PuzzleScreen(MainContext context) {
            InitializeComponent();
            BindingContext = new PuzzleScreenViewModel(context);
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            ViewModel.RenderPuzzle(GameGrid);
        }

        private void TouchEffect_TouchAction(object sender, TouchActionEventArgs args) {
            if (args.Type == TouchActionType.Pressed) {
                ViewModel.BeginTouch();
            }

            var gridCell = GameGrid.Children
                .Where(i => i.Bounds.X <= args.Location.X)
                .Where(i => i.Bounds.X + i.Width >= args.Location.X)
                .Where(i => i.Bounds.Y <= args.Location.Y)
                .Where(i => i.Bounds.Y + i.Width >= args.Location.Y)
                .FirstOrDefault();

            if (gridCell?.BindingContext is Logic.Cell cell) {
                ViewModel.SetCell(cell);
            }

            if (args.Type == TouchActionType.Released) {
                ViewModel.EndTouch();
            }
        }

        private void ValueFalse_Tapped(object sender, System.EventArgs e) {
            ViewModel.SelectedValue = CellValue.Blocked;
        }

        private void ValueTrue_Tapped(object sender, System.EventArgs e) {
            ViewModel.SelectedValue = CellValue.Filled;
        }
    }
}