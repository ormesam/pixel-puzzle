using System;
using System.IO;
using System.Text;

namespace MapGenerator {
    public class Generator {
        private readonly int size;
        private readonly int difficulty;
        private readonly Random random;
        private readonly int threshold;
        private readonly int edgeBias;
        private readonly int minFreedom;
        private string export;

        public Generator(int size, int difficulty) {
            this.size = size;
            this.difficulty = difficulty;
            random = new Random();
            export = string.Empty;

            threshold = GetWeight();
            edgeBias = GetEdgeBias();
            minFreedom = GetMinFreedom();
        }

        public void Run(int numberToCreate) {
            Console.WriteLine($"Generating {numberToCreate} maps at {size}x{size}");

            for (int i = 0; i < numberToCreate; i++) {
                int[,] map = GenerateMap();

                DisplayMap(map);

                Console.WriteLine("Export?");

                if (Console.ReadLine().ToLower() == "y") {
                    Export(map);
                }
            }

            Console.WriteLine($"Finished generating {numberToCreate} maps");

            if (!string.IsNullOrWhiteSpace(export)) {
                File.WriteAllText("export.txt", export);
            }
        }

        private int[,] GenerateMap() {
            var map = new int[size, size];

            GenerateRows(map);
            GenerateColumns(map);

            if (minFreedom > 0) {
                AdjustRowRegions(map);
                AdjustColumnRegions(map);
            }

            AvoidEmptyRowRegions(map);
            AvoidEmptyColumnRegions(map);

            return map;
        }

        private void GenerateRows(int[,] map) {
            var randomCells = GenerateRandomCells();
            int index = 0;

            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    map[row, col] = randomCells[index];
                    index++;
                }
            }
        }

        private void GenerateColumns(int[,] map) {
            var randomCells = GenerateRandomCells();
            int index = 0;

            for (int col = 0; col < size; col++) {
                for (int row = 0; row < size; row++) {
                    map[row, col] = randomCells[index];
                    index++;
                }
            }
        }

        private int[] GenerateRandomCells() {
            int[] cells = new int[size * size];
            int total = cells.Length;
            int index = 0;

            while (index < total) {
                var cs = random.Next(0, 99) > threshold ? 1 : 0;
                var length = random.Next(1, 3);

                while (length > 0 && index < total) {
                    cells[index] = cs;
                    index++;
                    length--;
                }
            }

            return cells;
        }

        private void AdjustRowRegions(int[,] map) {
            for (int i = 0; i < size; i++) {
                int[] cells = GetRowCells(map, i);

                int df = FreedomFromArray(cells);

                if (df == size) {
                    /* Do not want completely empty region */
                    InsertFilled(cells);
                    continue;
                }

                /* Do not want to produce totally empty regions */
                int min = Math.Min(size - 1, minFreedom + (i < 2 || i > size - 3 ? edgeBias : 0));

                if (df >= min) {
                    continue;
                }

                InsertEmpty(min - df, cells);

                ResetRow(map, i, cells);
            }
        }

        private void AdjustColumnRegions(int[,] map) {
            for (int i = 0; i < size; i++) {
                int[] cells = GetColumnCells(map, i);

                int df = FreedomFromArray(cells);

                if (df == size) {
                    /* Do not want completely empty region */
                    InsertFilled(cells);
                    continue;
                }

                /* Do not want to produce totally empty regions */
                int min = Math.Min(size - 1, minFreedom + (i < 2 || i > size - 3 ? edgeBias : 0));

                if (df >= min) {
                    continue;
                }

                InsertEmpty(min - df, cells);

                ResetColumn(map, i, cells);
            }
        }

        private int[] GetRowCells(int[,] map, int rowIdx) {
            int[] row = new int[size];

            for (int col = 0; col < size; col++) {
                row[col] = map[rowIdx, col];
            }

            return row;
        }

        private void ResetRow(int[,] map, int rowIdx, int[] cells) {
            for (int col = 0; col < size; col++) {
                map[rowIdx, col] = cells[col];
            }
        }

        private int[] GetColumnCells(int[,] map, int colIdx) {
            int[] col = new int[size];

            for (int row = 0; row < size; row++) {
                col[row] = map[row, colIdx];
            }

            return col;
        }

        private void ResetColumn(int[,] map, int colIdx, int[] cells) {
            for (int row = 0; row < size; row++) {
                map[row, colIdx] = cells[row];
            }
        }

        private void AvoidEmptyRowRegions(int[,] map) {
            for (int i = 0; i < size; i++) {
                int[] cells = GetRowCells(map, i);

                int df = FreedomFromArray(cells);
                if (df >= size) {
                    InsertFilled(cells);
                    ResetRow(map, i, cells);
                    continue;
                }
            }
        }

        private void AvoidEmptyColumnRegions(int[,] map) {
        }

        private int GetWeight() {
            switch (difficulty) {
                case 1: return 30;
                case 2: return 35;
                case 3: return 40;
                default: return 0;
            }
        }

        private int GetEdgeBias() {
            switch (difficulty) {
                case 3: return 1;
                default: return 0;
            }
        }

        private int GetMinFreedom() {
            switch (difficulty) {
                case 2:
                case 3: return 2;
                default: return 1;
            }
        }

        public void InsertEmpty(int replace, int[] cells) {
            int count = 0;
            int lim = cells.Length - 2;

            for (int i = 1; i <= lim / 2 + 1; i++) {
                int idx = i;

                if (cells[idx] == 1) {
                    cells[idx] = 0;
                    if (++count == replace) {
                        break;
                    }
                }

                idx = lim - idx;

                if (cells[idx] == 1) {
                    cells[idx] = 0;
                    if (++count == replace) {
                        break;
                    }
                }
            }
        }

        private void InsertFilled(int[] cells) {
            int lim = cells.Length - 2;

            var ptr = random.Next(1, lim);
            cells[ptr] = 1;
        }

        private int FreedomFromArray(int[] cells) {
            var filled = 0; // count of filled cells
            var blocks = 0; // count of filled groups
            int length = cells.Length;

            for (int i = 0; i < length; i++) {
                if (cells[i] == 1) {
                    filled++;

                    if (i == 0 || cells[i - 1] == 0) {
                        blocks++;
                    }
                }
            }

            return (length - filled - (blocks - 1));
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

        private void Export(int[,] map) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("        public static int[,] Game() {");
            sb.AppendLine("            return new int[" + size + "," + size + "] {");

            for (int row = 0; row < size; row++) {
                sb.Append("                { ");

                for (int col = 0; col < size; col++) {
                    sb.Append(map[row, col] + (col < size - 1 ? ", " : " "));
                }

                sb.Append("},");
                sb.AppendLine();
            }

            sb.AppendLine("            };");
            sb.AppendLine("        }");

            Console.WriteLine(sb.ToString());

            export += sb.ToString();
        }
    }
}
