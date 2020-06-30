using System;
using PuzzleGeneration;

namespace PixelPuzzle.Logic {
    public static class MapGenerator {
        public static int[,] GenerateRandom(int size) {
            Random rnd = new Random();
            int difficulty = rnd.Next(1, 5);

            Generator generator = new Generator(size, difficulty, null);
            return generator.GenerateMap();
        }
    }
}
