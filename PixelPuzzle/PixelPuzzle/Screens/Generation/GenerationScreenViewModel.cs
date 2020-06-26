using System;
using System.Text;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;
using Xamarin.Essentials;

namespace PixelPuzzle.Screens.Generation {
    public class GenerationScreenViewModel : ViewModelBase {
        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public GenerationScreenViewModel(MainContext context, int size) : base(context) {
            PuzzleControlViewModel = new PuzzleControlViewModel(context, GetMap(size), true);
        }

        private int[,] GetMap(int size) {
            var map = new int[size, size];

            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    map[row, col] = 0;
                }
            }

            return map;
        }

        public async Task Generate() {
            var map = PuzzleControlViewModel.Game.GetUserMap();
            int size = (int)Math.Sqrt(map.Length);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("        public static int[,] Game() {");
            sb.AppendLine("            return new int[" + size + "," + size + "] {");

            for (int row = 0; row < size; row++) {
                sb.Append("                { ");

                for (int col = 0; col < size; col++) {
                    sb.Append((map[row, col] == Logic.CellValue.Filled ? "1" : "0") + (col < size - 1 ? ", " : " "));
                }

                sb.Append("},");
                sb.AppendLine();
            }

            sb.AppendLine("            };");
            sb.AppendLine("        }");
            sb.AppendLine();

            await Share.RequestAsync(new ShareTextRequest {
                Text = sb.ToString(),
                Title = "Puzzle!"
            });
        }
    }
}
