using PixelPuzzle.Contexts;
using PixelPuzzle.Converters;
using PixelPuzzle.Logic;
using Xamarin.Forms;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        public Game Game { get; }
        public bool IsComplete => Game.IsComplete();

        public PuzzleScreenViewModel(MainContext context) : base(context) {
            var map = MapGenerator.Generate();
            Game = new Game(map);
        }

        public void RenderPuzzle(Grid gameGrid) {
            int gridLength = Game.GridLength;

            SetupGrid(gameGrid, gridLength);
            AddHeaders(gameGrid, gridLength);

            for (int row = 0; row < gridLength; row++) {
                for (int col = 0; col < gridLength; col++) {
                    var cell = Game.Rows[row].Cells[col];

                    BoxView boxView = new BoxView {
                        BindingContext = cell,
                    };

                    boxView.GestureRecognizers.Add(new TapGestureRecognizer {
                        Command = new Command(() => {
                            (boxView.BindingContext as Logic.Cell).Toggle();
                            OnPropertyChanged(nameof(IsComplete));
                        }),
                    });

                    boxView.SetBinding(BoxView.BackgroundColorProperty, nameof(Logic.Cell.UserValue), converter: new CellColourConverter());

                    Grid.SetRow(boxView, row + 1);
                    Grid.SetColumn(boxView, col + 1);

                    gameGrid.Children.Add(boxView);
                }
            }
        }

        private void AddHeaders(Grid gameGrid, int gridLength) {
        }

        private void SetupGrid(Grid gameGrid, int count) {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            for (int i = 0; i < count; i++) {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
        }
    }
}
