using System;

namespace PixelPuzzle.Logic {
    public class SavedGame {
        public int LevelNumber { get; set; }
        public Difficulty Difficulty { get; set; }
        public CellValue[,] Map { get; set; }
        public bool IsComplete { get; set; }
        public DateTime SavedUtc { get; set; }

        public string Key => $"{Difficulty}.{LevelNumber}";
    }
}
