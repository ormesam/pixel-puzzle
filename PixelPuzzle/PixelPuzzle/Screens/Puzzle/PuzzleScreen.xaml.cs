using System;
using System.Linq;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using PixelPuzzle.Touch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Screens.Puzzle {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleScreen : ContentPage {
        public PuzzleScreen(MainContext context, int size) {
            InitializeComponent();
            BindingContext = new PuzzleScreenViewModel(context, GameGrid, size);
        }

        public PuzzleScreenViewModel ViewModel => BindingContext as PuzzleScreenViewModel;

        protected override void OnAppearing() {
            base.OnAppearing();

            ViewModel.CreateGame();
        }

        private void TouchEffect_TouchAction(object sender, TouchActionEventArgs args) {
            if (args.TouchId != 0) {
                return;
            }

            if (args.Type == TouchActionType.Pressed) {
                ViewModel.BeginTouch();
            }

            var gridCells = GameGrid.Children
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

        private void ValueFalse_Tapped(object sender, EventArgs e) {
            ViewModel.SelectedValue = CellValue.Blocked;
        }

        private void ValueTrue_Tapped(object sender, EventArgs e) {
            ViewModel.SelectedValue = CellValue.Filled;
        }

        private async void Complete_Clicked(object sender, EventArgs e) {
            await Navigation.PopToRootAsync();
        }
    }
}