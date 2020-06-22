using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MapGenerator {
    public class Generator {
        private readonly int size;
        private readonly int difficulty;
        private int exportNumber;
        private readonly Random random;
        private readonly int initialWeight;
        private readonly int edgeBias;
        private string export;

        public Generator(int size, int difficulty, int exportNumber) {
            this.size = size;
            this.difficulty = difficulty;
            this.exportNumber = exportNumber;
            random = new Random();
            export = string.Empty;

            initialWeight = GetInitialWeight();
            edgeBias = GetEdgeBias();
        }

        private int GetInitialWeight() {
            switch (difficulty) {
                case 1:
                    return 65;
                case 2:
                    return 60;
                case 3:
                    return 55;
                default:
                    return 50;
            }
        }

        private int GetEdgeBias() {
            switch (difficulty) {
                case 3:
                    return 1;
                case 4:
                    return 2;
                default:
                    return 0;
            }
        }

        public void Run(int numberToCreate) {
            Console.WriteLine($"Generating {numberToCreate} maps at {size}x{size}");

            for (int i = 0; i < numberToCreate; i++) {
                int[,] map = GenerateMap();

                DisplayMap(map);
                Export(map);
            }

            Console.WriteLine($"Finished generating {numberToCreate} maps");

            if (!string.IsNullOrWhiteSpace(export)) {
                File.WriteAllText("export.txt", export);
            }
        }

        private int[,] GenerateMap() {
            var map = new int[size, size];

            GenerateRows(map);
            FillEmptyRows(map);
            FillEmptyColumns(map);
            MergeBrokenRowGroups(map);
            MergeBrokenColumnGroups(map);

            return map;
        }

        private void MergeBrokenRowGroups(int[,] map) {
            for (int row = 0; row < size; row++) {
                int[] cells = GetRowCells(map, row);

                int tryCount = 0;

                while (!cells.Except(new int[3] { 0, 1, 0 }).Any() && tryCount < 3) {
                    tryCount++;
                    bool replace = GetRandomBool();

                    if (!replace) {
                        continue;
                    }

                    bool goRight = GetRandomBool();

                    for (int col = goRight ? 1 : size - 2; goRight ? col < size - 2 : col >= 1; col += goRight ? 1 : -1) {
                        if (cells[col] == 1 && cells[col + 1] == 0 && cells[col - 1] == 0) {
                            bool regenerate = GetRandomBool();

                            if (regenerate) {
                                map[row, col - 1] = GenerateCell(map, row, col);
                                map[row, col + 1] = GenerateCell(map, row, col);
                            } else {
                                map[row, col - 1] = 0;
                                map[row, col + 1] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void MergeBrokenColumnGroups(int[,] map) {
            for (int col = 0; col < size; col++) {
                int[] cells = GetColumnCells(map, col);

                int tryCount = 0;

                while (!cells.Except(new int[3] { 0, 1, 0 }).Any() && tryCount < 3) {
                    tryCount++;
                    bool replace = GetRandomBool();

                    if (!replace) {
                        continue;
                    }

                    bool goRight = GetRandomBool();

                    for (int row = goRight ? 1 : size - 2; goRight ? row < size - 2 : row >= 1; row += goRight ? 1 : -1) {
                        if (cells[row] == 1 && cells[row + 1] == 0 && cells[row - 1] == 0) {
                            bool regenerate = GetRandomBool();

                            if (regenerate) {
                                map[row - 1, col] = GenerateCell(map, row, col);
                                map[row + 1, col] = GenerateCell(map, row, col);
                            } else {
                                map[row - 1, col] = 0;
                                map[row + 1, col] = 0;
                            }
                        }
                    }
                }
            }
        }

        private bool GetRandomBool() {
            return random.Next(0, 2) == 1;
        }

        private void FillEmptyRows(int[,] map) {
            for (int row = 0; row < size; row++) {
                int[] cells = GetRowCells(map, row);

                if (cells.All(i => i == 0)) {
                    for (int col = 0; col < size; col++) {
                        // try regenerate cells for row
                        map[row, col] = GenerateCell(map, row, col);
                    }
                }
            }
        }

        private void FillEmptyColumns(int[,] map) {
            for (int col = 0; col < size; col++) {
                int[] cells = GetColumnCells(map, col);

                if (cells.All(i => i == 0)) {
                    for (int row = 0; row < size; row++) {
                        // try regenerate cells for column
                        map[row, col] = GenerateCell(map, row, row);
                    }
                }
            }
        }

        private void GenerateRows(int[,] map) {
            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    map[row, col] = GenerateCell(map, row, col);
                }
            }
        }

        private int GenerateCell(int[,] map, int row, int col) {
            int weight = initialWeight;
            ApplyEdgeWeightAdjustment(row, col, ref weight);
            ApplySurroundingCellAdjustment(map, row, col, ref weight);

            return random.Next(1, 100) < weight ? 1 : 0;
        }

        private void ApplySurroundingCellAdjustment(int[,] map, int row, int col, ref int weight) {
            bool lastRowCellWasFilled = col > 0 && map[row, col - 1] == 1;
            bool lastColCellWasFilled = row > 0 && map[row - 1, col] == 1;

            if (lastRowCellWasFilled) {
                weight += 2;
            }

            if (lastColCellWasFilled) {
                weight += 2;
            }
        }

        private void ApplyEdgeWeightAdjustment(int row, int col, ref int weight) {
            int topEdge = edgeBias;
            int leftEdge = edgeBias;
            int rightEdge = size - 1 - edgeBias;
            int bottomEdge = size - 1 - edgeBias;

            bool isEdge = row < topEdge || col < leftEdge || row > rightEdge || col > bottomEdge;

            if (!isEdge) {
                return;
            }

            switch (difficulty) {
                case 3:
                    weight -= 5;
                    break;
                case 4:
                    weight -= 10;
                    break;
                default:
                    break;
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

        private void Export(int[,] map) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("        public static int[,] Game" + exportNumber++ + "() {");
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
            sb.AppendLine();

            export += sb.ToString();
        }

        private int[] GetRowCells(int[,] map, int row) {
            int[] cells = new int[size];

            for (int col = 0; col < size; col++) {
                cells[col] = map[row, col];
            }

            return cells;
        }

        private int[] GetColumnCells(int[,] map, int col) {
            int[] cells = new int[size];

            for (int row = 0; row < size; row++) {
                cells[row] = map[row, col];
            }

            return cells;
        }
    }
}
