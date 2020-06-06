using System.Collections.Generic;
using System.Linq;

namespace PixelPuzzle.Logic {
    public class Line {
        public Cell[] Cells { get; }
        public IList<int> Segments { get; private set; }
        public bool IsValid => GetIsValid();

        public Line(int gridLength) {
            Cells = new Cell[gridLength];
            Segments = new List<int>();
        }

        public void GenerateSegments() {
            int currentCount = 0;

            foreach (var cell in Cells) {
                if (cell.CorrectValue == CellValue.Filled) {
                    currentCount++;
                } else if (currentCount > 0) {
                    Segments.Add(currentCount);
                    currentCount = 0;
                }
            }

            if (currentCount > 0) {
                Segments.Add(currentCount);
            }
        }

        public bool GetIsValid() {
            int currentCount = 0;
            IList<int> segments = new List<int>();

            foreach (var cell in Cells) {
                if (cell.CorrectValue == CellValue.Filled) {
                    currentCount++;
                } else if (currentCount > 0) {
                    segments.Add(currentCount);
                    currentCount = 0;
                }
            }

            return Segments.SequenceEqual(segments);
        }
    }
}