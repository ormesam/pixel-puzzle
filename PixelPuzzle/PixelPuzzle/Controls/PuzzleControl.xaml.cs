using System;
using System.Linq;
using System.Threading.Tasks;
using PixelPuzzle.Logic;
using PixelPuzzle.Touch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleControl : ContentView {
        private bool loaded = false;

        public PuzzleControl() {
            InitializeComponent();
        }

        public async Task OnLoad() {
            if (loaded) {
                return;
            }

            loaded = true;

            await ViewModel.Setup(gameGrid);
        }

        public PuzzleControlViewModel ViewModel => BindingContext as PuzzleControlViewModel;

        private void TouchEffect_TouchAction(object sender, TouchActionEventArgs args) {
            if (args.TouchId != 0) {
                return;
            }

            if (args.Type == TouchActionType.Pressed) {
                ViewModel.BeginTouch();
            }

            var gridCells = gameGrid.Children
                .Where(i => i.Bounds.X <= args.Location.X)
                .Where(i => i.Bounds.X + i.Width >= args.Location.X)
                .Where(i => i.Bounds.Y <= args.Location.Y)
                .Where(i => i.Bounds.Y + i.Width >= args.Location.Y)
                .ToList();

            foreach (var gridCell in gridCells) {
                if (gridCell.BindingContext is Logic.Cell cell) {
                    ViewModel.SetCell(cell);
                    continue;
                }
            }

            if (args.Type == TouchActionType.Released) {
                ViewModel.EndTouch();
            }
        }

        private async void Line_Tapped(object sender, EventArgs e) {
            var grid = sender as Grid;

            if (grid?.BindingContext is Line line) {
                await ViewModel.ShowHintModal(line);
            }
        }
    }
}