using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Game;
using Xamarin.Forms;

namespace PixelPuzzle.Screens.Game {
    public class PuzzleScreenViewModel : ViewModelBase {
        public int[,] Puzzle { get; }

        public PuzzleScreenViewModel(MainContext context) : base(context) {
            Puzzle = GameGenerator.Generate();
        }

        public void RenderPuzzle(Grid gameGrid) {
            int gridLength = (int)Math.Sqrt(Puzzle.Length);

            SetupGrid(gameGrid, gridLength);

            for (int row = 0; row < gridLength; row++) {
                for (int col = 0; col < gridLength; col++) {
                    Console.WriteLine($"Row: {row}  Col: {col}  Value: {Puzzle[row, col]}");

                    BoxView boxView = new BoxView {
                        BackgroundColor = Puzzle[row, col] == 1 ? Color.Black : Color.White,
                    };

                    Grid.SetRow(boxView, row);
                    Grid.SetColumn(boxView, col);

                    gameGrid.Children.Add(boxView);
                }
            }
        }

        private void SetupGrid(Grid gameGrid, int count) {
            for (int i = 0; i < count; i++) {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
        }
    }
}
