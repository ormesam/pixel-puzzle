namespace PixelPuzzle.Logic {
    public class Level {
        public int LevelNumber { get; set; }
        public Difficulty Difficulty { get; set; }
        public int[,] Map { get; set; }

        public Level(int levelNumber, Difficulty difficulty, int[,] map) {
            LevelNumber = levelNumber;
            Difficulty = difficulty;
            Map = map;
        }
    }
}
