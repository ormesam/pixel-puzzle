using PixelPuzzle.Utility;

namespace PixelPuzzle.Logic {
    public class Cell : NotifyPropertyChangedBase {
        private bool? userValue;

        public int X { get; }
        public int Y { get; }
        public bool CorrectValue { get; }
        public bool? UserValue {
            get { return userValue; }
            set {
                if (userValue != value) {
                    userValue = value;
                    OnPropertyChanged(nameof(UserValue));
                }
            }
        }

        public Cell(int x, int y, bool correctValue) {
            X = x;
            Y = y;
            CorrectValue = correctValue;
        }

        public void Toggle() {
            if (UserValue == null) {
                UserValue = true;
                return;
            }

            UserValue = !UserValue;
        }
    }
}
