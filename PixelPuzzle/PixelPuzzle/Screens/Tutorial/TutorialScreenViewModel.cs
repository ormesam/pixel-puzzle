using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PixelPuzzle.Contexts;
using PixelPuzzle.Controls;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Screens.Tutorial {
    public class TutorialScreenViewModel : ViewModelBase {
        private bool isMovingStep;
        private readonly Queue<TutorialStep> steps;
        private TutorialStep currentStep;
        private bool isTutorialComplete;
        public event EventHandler<EventArgs> TutorialComplete;

        public PuzzleControlViewModel PuzzleControlViewModel { get; }

        public TutorialStep CurrentStep {
            get { return currentStep; }
            set {
                if (currentStep != value) {
                    currentStep = value;
                    OnPropertyChanged(nameof(CurrentStep));
                }
            }
        }

        public bool IsTutorialComplete {
            get { return isTutorialComplete; }
            set {
                if (isTutorialComplete != value) {
                    isTutorialComplete = value;
                    OnPropertyChanged(nameof(IsTutorialComplete));
                }
            }
        }

        public TutorialScreenViewModel(MainContext context) : base(context) {
            steps = new Queue<TutorialStep>();
            PuzzleControlViewModel = new PuzzleControlViewModel(context, CreateTutorialMap(), false);
            PuzzleControlViewModel.Game.GameCompleted += Game_GameCompleted;

            RegisterStep("Welcome to Pixel Puzzle!", null, null);
            RegisterStep("Here is a quick guide to help you on your way.", null, null);
            RegisterStep("The numbers around the grid tell you how many grouped, filled pixels are on each row or column.", null, null);
            RegisterStep("You can fill or block out a pixel by selecting these boxes.", async () => { await BlinkSelectedValue(); }, null);
            RegisterStep("For example, we know this row has 8 filled pixels.", async () => { await FillRow(4); }, null);
            RegisterStep("The row's number is grayed out when the row is logically complete.", null, null);
            RegisterStep("If you know a pixel cannot be filled, mark it with an X.", null, null);
            RegisterStep("We know these rows cannot have any pixels in them.", async () => { await BlockRow(0); await BlockRow(3); }, null);
            RegisterStep("We also know the first column only has 2 filled pixes, so the second pixel must go here.",
                async () => { await FillCells(PuzzleControlViewModel.Game.Rows[5].Cells[0]); }, null);
            RegisterStep("And now we can block out the remaining pixels in that column.", async () => { await BlockColumn(0); }, null);
            RegisterStep("And similary on the other side.",
                async () => { await FillCells(PuzzleControlViewModel.Game.Rows[5].Cells[7]); await BlockColumn(7); }, null);
            RegisterStep("The second column has a group of 2, and a group of 3 pixels. There is only one way to fit them in.",
                async () => {
                    await FillCells(
                        PuzzleControlViewModel.Game.Rows[1].Cells[1],
                        PuzzleControlViewModel.Game.Rows[2].Cells[1],
                        PuzzleControlViewModel.Game.Rows[5].Cells[1],
                        PuzzleControlViewModel.Game.Rows[6].Cells[1]);
                    await BlockColumn(1);
                }, null);
            RegisterStep("And similary on the other side.",
                async () => {
                    await FillCells(
                        PuzzleControlViewModel.Game.Rows[1].Cells[6],
                        PuzzleControlViewModel.Game.Rows[2].Cells[6],
                        PuzzleControlViewModel.Game.Rows[5].Cells[6],
                        PuzzleControlViewModel.Game.Rows[6].Cells[6]);
                    await BlockColumn(6);
                }, null);
            RegisterStep("This row is now logically complete.", async () => { await BlockRow(5); }, null);
            RegisterStep("And we know this row has 6 filled pixels.", async () => { await FillRow(6); }, null);
            RegisterStep("As we blocked off the other pixels we know the group of 4 can only go here.", async () => { await FillRow(7); }, null);
            RegisterStep("There is always a way to complete the puzzle.", null, null);
            RegisterStep("Can you complete the rest of this puzzle?", async () => { IsTutorialComplete = true; }, null);
        }

        private async void Game_GameCompleted(object sender, EventArgs e) {
            var modal = new TutorialCompletedModal(Context);

            modal.Disappearing += (s, ev) => {
                TutorialComplete?.Invoke(s, ev);
            };

            await Context.UI.ShowModal(modal);
        }

        private Task FillRow(int rowIdx) {
            return FillCells(PuzzleControlViewModel.Game.Rows[rowIdx].Cells);
        }

        private Task BlockRow(int rowIdx) {
            return BlockCells(PuzzleControlViewModel.Game.Rows[rowIdx].Cells);
        }

        private Task BlockColumn(int rowIdx) {
            return BlockCells(PuzzleControlViewModel.Game.Columns[rowIdx].Cells);
        }

        private async Task FillCells(params Cell[] cells) {
            PuzzleControlViewModel.SelectedValue = CellValue.Filled;

            foreach (Cell cell in cells) {
                if (cell.UserValue != CellValue.Blank) {
                    continue;
                }

                await Task.Delay(100);
                cell.UserValue = CellValue.Filled;
            }
        }

        private async Task BlockCells(Cell[] cells) {
            PuzzleControlViewModel.SelectedValue = CellValue.Blocked;

            foreach (Cell cell in cells) {
                if (cell.UserValue != CellValue.Blank) {
                    continue;
                }

                await Task.Delay(100);
                cell.UserValue = CellValue.Blocked;
            }
        }

        private async Task BlinkSelectedValue() {
            for (int i = 0; i < 4; i++) {
                await Task.Delay(500);
                PuzzleControlViewModel.SelectedValue = PuzzleControlViewModel.SelectedValueIsBlocked ? CellValue.Filled : CellValue.Blocked;
            }
        }

        public async Task MoveNext() {
            if (isMovingStep || isTutorialComplete) {
                return;
            }

            isMovingStep = true;

            if (CurrentStep?.After != null) {
                await CurrentStep.After.Invoke();
            }

            CurrentStep = steps.Dequeue();

            if (CurrentStep?.Before != null) {
                await CurrentStep.Before.Invoke();
            }

            isMovingStep = false;
        }

        private void RegisterStep(string message, Func<Task> before, Func<Task> after) {
            steps.Enqueue(new TutorialStep {
                Message = message,
                Before = before,
                After = after,
            });
        }

        private int[,] CreateTutorialMap() {
            return new int[8, 8] {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 0, 0, 0, 0, 1, 1 },
                { 0, 1, 1, 1, 1, 1, 1, 0 },
                { 0, 0, 1, 1, 1, 1, 0, 0 },
            };
        }
    }
}
