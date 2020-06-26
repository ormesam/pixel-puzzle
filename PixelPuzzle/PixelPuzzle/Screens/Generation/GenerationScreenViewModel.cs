using System;
using System.Text;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;
using PixelPuzzle.Utility;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        public Task Generate() {
            var map = PuzzleControlViewModel.Game.GetUserMap();
            int size = (int)Math.Sqrt(map.Length);
            string difficulty = size == 8 ? "Small" : size == 12 ? "Medium" : size == 15 ? "Large" : "";

            IPromptUtility prompt = DependencyService.Get<IPromptUtility>();
            prompt.ShowInputDialog("What is this?", string.Empty, async (name) => {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("        public static int[,] " + difficulty.Replace(" ", "").Trim() + name + "() {");
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
            });

            return Task.CompletedTask;
        }
    }
}
