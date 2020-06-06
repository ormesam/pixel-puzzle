using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Converters;
using PixelPuzzle.Logic;
using Xamarin.Forms;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        private CellValue selectedValue;
        private Guid? touchId;
        private CellValue? touchValue;

        public Game Game { get; }
        public bool IsComplete => Game.IsComplete();

        public CellValue SelectedValue {
            get { return selectedValue; }
            set {
                if (selectedValue != value) {
                    selectedValue = value;
                    OnPropertyChanged(nameof(SelectedValue));
                }
            }
        }

        public PuzzleScreenViewModel(MainContext context) : base(context) {
            var map = MapGenerator.Generate();
            Game = new Game(map);
            selectedValue = CellValue.Filled;
        }

        public void RenderPuzzle(Grid gameGrid) {
            int gridLength = Game.GridLength;

            SetupGrid(gameGrid);
            AddHeaders(gameGrid);

            for (int row = 0; row < gridLength; row++) {
                for (int col = 0; col < gridLength; col++) {
                    var cell = Game.Rows[row].Cells[col];

                    BoxView boxView = new BoxView {
                        BindingContext = cell,
                    };

                    boxView.SetBinding(BoxView.BackgroundColorProperty, nameof(Logic.Cell.UserValue), converter: new CellColourConverter());

                    Grid.SetRow(boxView, row + 1);
                    Grid.SetColumn(boxView, col + 1);

                    gameGrid.Children.Add(boxView);
                }
            }
        }

        private void AddHeaders(Grid gameGrid) {
            AddHeader(gameGrid, Game.Rows, StackOrientation.Horizontal);
            AddHeader(gameGrid, Game.Columns, StackOrientation.Vertical);
        }

        private void AddHeader(Grid gameGrid, Line[] lines, StackOrientation orientation) {
            for (int i = 0; i < Game.GridLength; i++) {
                StackLayout layout = new StackLayout {
                    Orientation = orientation,
                };

                foreach (var segment in lines[i].Segments) {
                    layout.Children.Add(new Label {
                        Text = segment.ToString(),
                    });
                }

                if (orientation == StackOrientation.Horizontal) {
                    Grid.SetRow(layout, i + 1);
                    layout.HorizontalOptions = LayoutOptions.End;
                    layout.VerticalOptions = LayoutOptions.Center;
                } else {
                    Grid.SetColumn(layout, i + 1);
                    layout.HorizontalOptions = LayoutOptions.Center;
                    layout.VerticalOptions = LayoutOptions.End;
                }

                gameGrid.Children.Add(layout);
            }
        }

        private void SetupGrid(Grid gameGrid) {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            for (int i = 0; i < Game.GridLength; i++) {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
        }

        public void SetCell(Logic.Cell cell) {
            if (touchValue == null) {
                touchValue = GetTouchValue(cell);
            }

            if (touchValue == null) {
                return;
            }

            cell.SetValue(touchId.Value, SelectedValue, touchValue.Value);
        }

        public void BeginTouch() {
            touchId = Guid.NewGuid();
        }

        public void EndTouch() {
            touchId = null;
            touchValue = null;
        }

        private CellValue? GetTouchValue(Logic.Cell cell) {
            if (SelectedValue == CellValue.Filled) {
                if (cell.UserValue == CellValue.Filled) {
                    return CellValue.Blank;
                } else if (cell.UserValue == CellValue.Blank) {
                    return CellValue.Filled;
                }
            } else {
                if (cell.UserValue == CellValue.Blocked) {
                    return CellValue.Blank;
                } else if (cell.UserValue == CellValue.Blank) {
                    return CellValue.Blocked;
                }
            };

            return null;
        }
    }
}
