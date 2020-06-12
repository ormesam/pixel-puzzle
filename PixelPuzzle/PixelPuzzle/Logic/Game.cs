using System;
using System.Collections.Generic;
using System.Linq;

namespace PixelPuzzle.Logic {
    public class Game {
        public static int Large => 15;
        public static int Medium => 12;
        public static int Small => 8;

        public int GridLength { get; }
        public IList<Cell> Cells { get; set; }
        public Line[] Rows { get; set; }
        public Line[] Columns { get; set; }

        public event EventHandler<EventArgs> GameCompleted;

        public Game(int[,] map) {
            GridLength = (int)Math.Sqrt(map.Length);
            GenerateMap(map);
        }

        private void GenerateMap(int[,] map) {
            Rows = new Line[GridLength];
            Columns = new Line[GridLength];
            Cells = new List<Cell>();

            for (int row = 0; row < GridLength; row++) {
                Rows[row] = new Line(GridLength);

                for (int col = 0; col < GridLength; col++) {
                    if (row == 0) {
                        Columns[col] = new Line(GridLength);
                    }

                    var cell = new Cell(row + 1, col + 1, map[row, col] == 1 ? CellValue.Filled : CellValue.Blocked);
                    var currentRow = Rows[row];
                    var currentColumn = Columns[col];

                    cell.PropertyChanged += (s, e) => {
                        if (e.PropertyName == nameof(Cell.UserValue)) {
                            currentRow.UpdateIsValid();
                            currentColumn.UpdateIsValid();
                        }
                    };

                    Cells.Add(cell);
                    currentRow.Cells[col] = cell;
                    currentColumn.Cells[row] = cell;
                }
            }

            foreach (var row in Rows) {
                row.GenerateSegments();
            }

            foreach (var col in Columns) {
                col.GenerateSegments();
            }
        }

        private bool IsComplete() {
            return Rows.All(i => i.IsValid) && Columns.All(i => i.IsValid);
        }

        internal void CheckIsComplete() {
            if (IsComplete()) {
                GameCompleted?.Invoke(this, new EventArgs());
            }
        }

        public CellValue[,] GetUserMap() {
            var map = new CellValue[GridLength, GridLength];

            foreach (var cell in Cells) {
                map[cell.X - 1, cell.Y - 1] = cell.UserValue;
            }

            return map;
        }

        public void ApplyUserValues(CellValue[,] map) {
            foreach (var cell in Cells) {
                cell.UserValue = map[cell.X - 1, cell.Y - 1];
            }
        }
    }
}
