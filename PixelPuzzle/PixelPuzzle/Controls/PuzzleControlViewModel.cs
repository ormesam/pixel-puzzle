using System;
using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using PixelPuzzle.Screens;

namespace PixelPuzzle.Controls {
    public class PuzzleControlViewModel : ViewModelBase {
        private CellValue selectedValue;
        private Guid? touchId;
        private CellValue? touchValue;
        private int? touchXRow;
        private int? touchYRow;
        private bool isComplete;

        public PuzzleControlViewModel(MainContext context, int[,] map) : base(context) {
            selectedValue = CellValue.Filled;

            Game = new Game(map);
            Game.GameCompleted += Game_GameCompleted;
        }

        public PuzzleControlViewModel(MainContext context, int size)
            : this(context, MapGenerator.Generate(size)) {
        }

        public Game Game { get; private set; }

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

        private void Game_GameCompleted(object sender, EventArgs e) {
            IsComplete = true;
        }

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
