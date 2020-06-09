using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Converters;
using PixelPuzzle.Logic;
using Xamarin.Forms;

namespace PixelPuzzle.Screens.Puzzle {
    public class PuzzleScreenViewModel : ViewModelBase {
        private readonly Grid gameGrid;
        private readonly int size;
        private CellValue selectedValue;
        private Guid? touchId;
        private CellValue? touchValue;
        private int? touchXRow;
        private int? touchYRow;
        private bool isComplete;

        public Game Game { get; set; }

        public CellValue SelectedValue {
            get { return selectedValue; }
            set {
                if (selectedValue != value) {
                    selectedValue = value;
                    OnPropertyChanged(nameof(SelectedValue));
                }
            }
        }

        public bool IsComplete {
            get { return isComplete; }
            set {
                if (isComplete != value) {
                    isComplete = value;
                    OnPropertyChanged(nameof(IsComplete));
                }
            }
        }

        public PuzzleScreenViewModel(MainContext context, Grid gameGrid, int size) : base(context) {
            selectedValue = CellValue.Filled;
            this.gameGrid = gameGrid;
            this.size = size;
        }

        #region Game Setup

        public void CreateGame() {
            var map = MapGenerator.Generate(size);
            Game = new Game(map);
            Game.GameCompleted += Game_GameCompleted;
            RenderGame();

            SelectedValue = CellValue.Filled;

            OnPropertyChanged();
        }

        private void Game_GameCompleted(object sender, EventArgs e) {
            IsComplete = true;
        }

        private void RenderGame() {
            gameGrid.Children.Clear();
            gameGrid.RowDefinitions.Clear();
            gameGrid.ColumnDefinitions.Clear();

            int gridLength = Game.GridLength;

            SetupGrid();
            AddHeaders();

            for (int row = 0; row < gridLength; row++) {
                for (int col = 0; col < gridLength; col++) {
                    var cell = Game.Rows[row].Cells[col];

                    Label text = new Label();
                    text.Text = "✘";
                    text.VerticalTextAlignment = TextAlignment.Center;
                    text.HorizontalTextAlignment = TextAlignment.Center;
                    text.SetBinding(Image.IsVisibleProperty, nameof(Logic.Cell.IsBlocked));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.BackgroundColorProperty, nameof(Logic.Cell.UserValue), converter: new CellColourConverter());

                    Grid cellView = new Grid();
                    cellView.BackgroundColor = Color.Gray;
                    cellView.Padding = .5;
                    cellView.BindingContext = cell;
                    cellView.Children.Add(boxView);
                    cellView.Children.Add(text);

                    Binding heightBinding = new Binding();
                    heightBinding.Source = cellView;
                    heightBinding.Path = nameof(Grid.Width);
                    cellView.SetBinding(Grid.HeightRequestProperty, heightBinding);

                    gameGrid.Children.Add(cellView, col + 1, row + 1);
                }
            }
        }

        private void AddHeaders() {
            AddRowHeaders();
            AddColumnHeaders();
        }

        private void AddRowHeaders() {
            for (int i = 0; i < Game.GridLength; i++) {
                Grid border = new Grid() {
                    Padding = new Thickness(0, .5, .5, .5),
                    BackgroundColor = Color.Gray,
                };

                Grid container = new Grid() {
                    BindingContext = Game.Rows[i],
                    Padding = new Thickness(2, 2, 10, 2),
                    BackgroundColor = Color.White,
                };

                container.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                container.SetBinding(StackLayout.OpacityProperty, nameof(Line.IsValid), converter: new LineOpacityConverter());

                for (int j = 0; j < Game.Rows[i].Segments.Count; j++) {
                    var segment = Game.Rows[i].Segments[j];

                    container.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

                    container.Children.Add(new Label {
                        Text = segment.ToString(),
                        FontSize = 10,
                        VerticalTextAlignment = TextAlignment.Center,
                    }, j + 1, 0);
                }

                border.Children.Add(container);
                gameGrid.Children.Add(border, 0, i + 1);
            }
        }

        private void AddColumnHeaders() {
            for (int i = 0; i < Game.GridLength; i++) {
                Grid border = new Grid() {
                    Padding = new Thickness(.5, 0, .5, .5),
                    BackgroundColor = Color.Gray,
                };

                Grid container = new Grid() {
                    BindingContext = Game.Columns[i],
                    Padding = new Thickness(2, 2, 2, 10),
                    BackgroundColor = Color.White,
                };

                container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
                container.SetBinding(StackLayout.OpacityProperty, nameof(Line.IsValid), converter: new LineOpacityConverter());

                for (int j = 0; j < Game.Columns[i].Segments.Count; j++) {
                    var segment = Game.Columns[i].Segments[j];

                    container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                    container.Children.Add(new Label {
                        Text = segment.ToString(),
                        FontSize = 10,
                        HorizontalTextAlignment = TextAlignment.Center,
                    }, 0, j + 1);
                }

                border.Children.Add(container);
                gameGrid.Children.Add(border, i + 1, 0);
            }
        }

        private void SetupGrid() {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            for (int i = 0; i < Game.GridLength; i++) {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
        }

        #endregion

        #region Interaction

        public void SetCell(Logic.Cell cell) {
            if (touchValue == null) {
                touchValue = GetTouchValue(cell);
                touchXRow = cell.X;
                touchYRow = cell.Y;
            }

            if (touchValue == null) {
                return;
            }

            cell.SetValue(touchId.Value, touchXRow.Value, touchYRow.Value, SelectedValue, touchValue.Value);
        }

        public void BeginTouch() {
            touchId = Guid.NewGuid();
        }

        public void EndTouch() {
            touchId = null;
            touchValue = null;
            touchXRow = null;
            touchYRow = null;

            Game.CheckIsComplete();
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

        #endregion
    }
}
