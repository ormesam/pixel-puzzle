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
            int gridLength = ViewModel.Game.GridLength;

            SetupGrid();
            AddHeaders();

            for (int row = 0; row < gridLength; row++) {
                for (int col = 0; col < gridLength; col++) {
                    var cell = ViewModel.Game.Rows[row].Cells[col];

                    Image image = new Image();
                    image.Source = "cross.png";
                    image.VerticalOptions = LayoutOptions.Center;
                    image.HorizontalOptions = LayoutOptions.Center;

                    BoxView imageBackground = new BoxView();
                    imageBackground.BackgroundColor = Color.White;

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.BackgroundColorProperty, nameof(Logic.Cell.UserValue), converter: new CellColourConverter());

                    Grid cellView = new Grid();
                    cellView.BackgroundColor = Color.Gray;
                    cellView.Padding = .5;
                    cellView.BindingContext = cell;
                    cellView.Children.Add(imageBackground);
                    cellView.Children.Add(image);
                    cellView.Children.Add(boxView);

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
            for (int row = 0; row < ViewModel.Game.GridLength; row++) {
                Grid border = new Grid {
                    Padding = new Thickness(0, .5, .5, .5),
                    BackgroundColor = Color.Gray,
                };

                Label label = new Label() {
                    BindingContext = ViewModel.Game.Rows[row],
                    Padding = new Thickness(0, 0, 5, 0),
                    BackgroundColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.End,
                    Text = string.Join("  ", ViewModel.Game.Rows[row].Segments),
                    FontSize = 8,
                    WidthRequest = 60,
                };

                label.SetBinding(Label.OpacityProperty, nameof(Line.IsValid), converter: new LineOpacityConverter());

                border.Children.Add(label);

                gameGrid.Children.Add(border, 0, row + 1);
            }
        }

        private void AddColumnHeaders() {
            for (int col = 0; col < ViewModel.Game.GridLength; col++) {
                Grid border = new Grid {
                    BackgroundColor = Color.Gray,
                    Padding = new Thickness(.5, 0, .5, .5),
                };

                Label label = new Label() {
                    BindingContext = ViewModel.Game.Columns[col],
                    Padding = new Thickness(0, 0, 0, 5),
                    BackgroundColor = Color.White,
                    VerticalTextAlignment = TextAlignment.End,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = string.Join("\n", ViewModel.Game.Columns[col].Segments),
                    FontSize = 8,
                    HeightRequest = 60,
                };

                label.SetBinding(Label.OpacityProperty, nameof(Line.IsValid), converter: new LineOpacityConverter());

                border.Children.Add(label);

                gameGrid.Children.Add(border, col + 1, 0);
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