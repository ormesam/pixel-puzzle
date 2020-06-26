using System;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using PixelPuzzle.Screens;
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
                return;
            }

            await Context.UI.ShowHintModal(line);
        }
    }
}
