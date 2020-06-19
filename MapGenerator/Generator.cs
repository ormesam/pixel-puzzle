using System;
using System.Text;

namespace MapGenerator {
    public class Generator {
        private readonly int size;
        private readonly Random random;

        public Generator(int size) {
            this.size = size;
            random = new Random();
        }

        public void Run(int numberToCreate) {
            Console.WriteLine($"Generating {numberToCreate} maps at {size}x{size}");

            for (int i = 0; i < numberToCreate; i++) {
                int[,] map = GenerateMap();

                DisplayMap(map);
            }

            Console.WriteLine($"Finished generating {numberToCreate} maps");
        }

        private int[,] GenerateMap() {
            var map = CreateBlankMap();

            for (int row = 0; row < size; row++) {
                GenerateRow(map, row);
            }

            return map;
        }

        private int[,] CreateBlankMap() {
            var blankMap = new int[size, size];

            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    blankMap[row, col] = 0;
                }
            }

            return blankMap;
        }

        private void GenerateRow(int[,] map, int row) {
            for (int col = 0; col < size; col++) {
                map[row, col] = random.Next(1, 100) > 30 ? 1 : 0;
            }
        }

        private void DisplayMap(int[,] map) {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    sb.Append(map[row, col] + " ");
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
