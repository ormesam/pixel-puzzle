using System;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using PixelPuzzle.Screens;
using Xamarin.Essentials;
using Xamarin.Forms;
using Cell = PixelPuzzle.Logic.Cell;

namespace PixelPuzzle.Controls {
    public class PuzzleControlViewModel : ViewModelBase {
        private readonly bool showHintAd;
        private CellValue selectedValue;
        private Guid? touchId;
        private CellValue? touchValue;
        private int? touchXRow;
        private int? touchYRow;

        public PuzzleControlViewModel(MainContext context, int[,] map, bool showHintAd) : base(context) {
            selectedValue = CellValue.Filled;
            this.showHintAd = showHintAd;

            Game = new Game(map);
        }

        public Game Game { get; }

        public CellValue SelectedValue {
            get { return selectedValue; }
            set {
                if (selectedValue != value) {
                    selectedValue = value;
                    OnPropertyChanged(nameof(SelectedValue));
                    OnPropertyChanged(nameof(SelectedValueIsFilled));
                    OnPropertyChanged(nameof(SelectedValueIsBlocked));
                }
            }
        }

        public bool SelectedValueIsFilled => SelectedValue == CellValue.Filled;
        public bool SelectedValueIsBlocked => SelectedValue == CellValue.Blocked;

        public int CellStateSelectedSize => DeviceDisplay.MainDisplayInfo.Height <= 480 ? 45 : 60;
        public int CellStateBorderSize => CellStateSelectedSize - 10;
        public int CellStateFillSize => CellStateBorderSize - 10;

        public void SetCell(Cell cell) {
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

        private CellValue? GetTouchValue(Cell cell) {
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

        public async Task ShowHintModal(Line line) {
            if (!showHintAd) {
                await line.ShowHint();
                Game.CheckIsComplete();
                return;
            }

            await Context.UI.ShowHintModal(Game, line);
        }

        public int HintElementSize {
            get {
                var dpHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

                if (dpHeight <= 480) {
                    return 75;
                }

                return 92;
            }
        }

        public Task Setup(Grid grid) {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(75, GridUnitType.Absolute), });

            foreach (var row in Game.Rows) {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                grid.Children.Add(new RowHint { BindingContext = row }, 0, row.Number + 1);
            }

            foreach (var col in Game.Columns) {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                grid.Children.Add(new ColumnHint { BindingContext = col }, col.Number + 1, 0);
            }

            foreach (var cell in Game.Cells) {
                var cellControl = new PuzzleCell {
                    BindingContext = cell,
                };

                grid.Children.Add(cellControl, cell.X + 1, cell.Y + 1);
            }

            return Task.CompletedTask;
        }
    }
}
