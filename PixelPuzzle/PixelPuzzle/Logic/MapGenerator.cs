using System;

namespace PixelPuzzle.Logic {
    public static class MapGenerator {
        public static int[,] Generate(int size) {
            var map = new int[size, size];
            Random rnd = new Random();

            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    map[row, col] = rnd.Next(1, 101) > 33 ? 1 : 0; // Add weight to the filled squares
                }
            }

            return map;
        }
    }
}
