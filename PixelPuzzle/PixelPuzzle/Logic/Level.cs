using PixelPuzzle.Utility;

namespace PixelPuzzle.Logic {
    public class Level : NotifyPropertyChangedBase {
        private bool isComplete;

        public int LevelNumber { get; set; }
        public Difficulty Difficulty { get; set; }
        public int[,] Map { get; set; }
        public CellValue[,] UserMap { get; set; }
        public bool IsComplete {
            get { return isComplete; }
            set {
                if (isComplete != value) {
                    isComplete = value;
                    OnPropertyChanged(nameof(IsComplete));
                }
            }
        }

        public string Key => $"{Difficulty}.{LevelNumber}";

        public Level(int levelNumber, Difficulty difficulty, int[,] map) {
            LevelNumber = levelNumber;
            Difficulty = difficulty;
            Map = map;
        }
    }
}
