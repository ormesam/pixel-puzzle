using System;
using System.Threading.Tasks;

namespace PixelPuzzle.Logic {
    public class TutorialStep {
        public string Message { get; set; }
        public Func<Task> Before { get; set; }
        public Func<Task> After { get; set; }
    }
}
