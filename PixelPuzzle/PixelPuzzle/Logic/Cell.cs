using System;
using PixelPuzzle.Utility;

namespace PixelPuzzle.Logic {
    public class Cell : NotifyPropertyChangedBase {
        private CellValue userValue;
        private Guid? lastSetByTouchId;

        public int X { get; }
        public int Y { get; }
        public CellValue CorrectValue { get; }
        public CellValue UserValue {
            get { return userValue; }
            set {
                if (userValue != value) {
                    userValue = value;
                    OnPropertyChanged(nameof(UserValue));
                    OnPropertyChanged(nameof(IsBlocked));
                }
            }
        }

        public bool IsBlocked => UserValue == CellValue.Blocked;

        public Cell(int x, int y, CellValue correctValue) {
            X = x;
            Y = y;
            CorrectValue = correctValue;
            UserValue = CellValue.Blank;
        }

        public void SetValue(Guid touchId, int xRow, int yRow, CellValue selectedValue, CellValue? valueToSet) {
            if (valueToSet == null || lastSetByTouchId == touchId || (xRow != X && yRow != Y)) {
                return;
            }

            lastSetByTouchId = touchId;

            if (UserValue == CellValue.Blank) {
                UserValue = valueToSet.Value;
                return;
            }

            if (selectedValue == UserValue && valueToSet == CellValue.Blank) {
                UserValue = CellValue.Blank;
            }
        }

        public bool IsCorrect() {
            bool shouldBeFilled = CorrectValue == CellValue.Filled;
            bool isFilled = UserValue == CellValue.Filled;

            return shouldBeFilled == isFilled;
        }
    }
}
