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
                    cellView.BindingContext = cell;
                    cellView.Children.Add(boxView);
                    cellView.Children.Add(text);

                    Binding heightBinding = new Binding();
                    heightBinding.Source = cellView;
                    heightBinding.Path = nameof(Grid.Width);
                    cellView.SetBinding(Grid.HeightRequestProperty, heightBinding);

                    Grid.SetRow(cellView, row + 1);
                    Grid.SetColumn(cellView, col + 1);

                    gameGrid.Children.Add(cellView);
                }
            }
        }

        private void AddHeaders() {
            AddHeader(Game.Rows, StackOrientation.Horizontal);
            AddHeader(Game.Columns, StackOrientation.Vertical);
        }

        private void AddHeader(Line[] lines, StackOrientation orientation) {
            for (int i = 0; i < Game.GridLength; i++) {
                StackLayout layout = new StackLayout {
                    Orientation = orientation,
                    BindingContext = lines[i],
                };

                layout.SetBinding(StackLayout.BackgroundColorProperty, nameof(Line.IsValid), converter: new LineColourConverter());

                foreach (var segment in lines[i].Segments) {
                    layout.Children.Add(new Label {
                        Text = segment.ToString(),
                        FontSize = 10,
                        VerticalTextAlignment = orientation == StackOrientation.Horizontal ? TextAlignment.Center : TextAlignment.End,
                        HorizontalTextAlignment = orientation == StackOrientation.Vertical ? TextAlignment.Center : TextAlignment.End,
                    });
                }

                if (orientation == StackOrientation.Horizontal) {
                    Grid.SetRow(layout, i + 1);
                    layout.HorizontalOptions = LayoutOptions.EndAndExpand;
                } else {
                    Grid.SetColumn(layout, i + 1);
                    layout.VerticalOptions = LayoutOptions.EndAndExpand;
                }

                gameGrid.Children.Add(layout);
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
