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

        public GenerationScreenViewModel(MainContext context, int[,] map) : base(context) {
            PuzzleControlViewModel = new PuzzleControlViewModel(context, map, true);

            PuzzleControlViewModel.Game.Solve();
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

        public Task Share() {
            var map = PuzzleControlViewModel.Game.GetUserMap();
            int size = (int)Math.Sqrt(map.Length);

            IPromptUtility prompt = DependencyService.Get<IPromptUtility>();
            prompt.ShowInputDialog("What is this?", string.Empty, async (name) => {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("        public static int[,] " + name.Replace(" ", "").Trim() + "() {");
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

                await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest {
                    Text = sb.ToString(),
                    Title = "Share Puzzle"
                });
            });

            return Task.CompletedTask;
        }
    }
}
