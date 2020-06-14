using System;
using System.Linq;
using PixelPuzzle.Converters;
using PixelPuzzle.Logic;
using PixelPuzzle.Touch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PixelPuzzle.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PuzzleControl : ContentView {
        public PuzzleControl() {
            InitializeComponent();
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

        public void RenderGame() {
            gameGrid.Children.Clear();
            gameGrid.RowDefinitions.Clear();
            gameGrid.ColumnDefinitions.Clear();

            int gridLength = ViewModel.Game.GridLength;

            SetupGrid();
            AddHeaders();

            for (int row = 0; row < gridLength; row++) {
                for (int col = 0; col < gridLength; col++) {
                    var cell = ViewModel.Game.Rows[row].Cells[col];

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
            for (int i = 0; i < ViewModel.Game.GridLength; i++) {
                Grid border = new Grid() {
                    Padding = new Thickness(0, .5, .5, .5),
                    BackgroundColor = Color.Gray,
                };

                Grid container = new Grid() {
                    BindingContext = ViewModel.Game.Rows[i],
                    Padding = new Thickness(2, 2, 10, 2),
                    BackgroundColor = Color.White,
                    WidthRequest = 60,
                };

                container.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                container.SetBinding(StackLayout.OpacityProperty, nameof(Line.IsValid), converter: new LineOpacityConverter());

                for (int j = 0; j < ViewModel.Game.Rows[i].Segments.Count; j++) {
                    var segment = ViewModel.Game.Rows[i].Segments[j];

                    container.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

                    container.Children.Add(new Label {
                        Text = segment.ToString(),
                        FontSize = 8,
                        VerticalTextAlignment = TextAlignment.Center,
                    }, j + 1, 0);
                }

                border.Children.Add(container);
                gameGrid.Children.Add(border, 0, i + 1);
            }
        }

        private void AddColumnHeaders() {
            for (int i = 0; i < ViewModel.Game.GridLength; i++) {
                Grid border = new Grid() {
                    Padding = new Thickness(.5, 0, .5, .5),
                    BackgroundColor = Color.Gray,
                };

                Grid container = new Grid() {
                    BindingContext = ViewModel.Game.Columns[i],
                    Padding = new Thickness(2, 2, 2, 10),
                    BackgroundColor = Color.White,
                    HeightRequest = 60,
                };

                container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
                container.SetBinding(StackLayout.OpacityProperty, nameof(Line.IsValid), converter: new LineOpacityConverter());

                for (int j = 0; j < ViewModel.Game.Columns[i].Segments.Count; j++) {
                    var segment = ViewModel.Game.Columns[i].Segments[j];

                    container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                    container.Children.Add(new Label {
                        Text = segment.ToString(),
                        FontSize = 8,
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

            for (int i = 0; i < ViewModel.Game.GridLength; i++) {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
        }

        private void ValueFilled_Tapped(object sender, EventArgs e) {
            ViewModel.SelectedValue = CellValue.Filled;
        }

        private void ValueBlocked_Tapped(object sender, EventArgs e) {
            ViewModel.SelectedValue = CellValue.Blocked;

        }
    }
}