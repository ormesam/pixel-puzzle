using System;
using System.Threading.Tasks;

namespace PixelPuzzle.Utility {
    public interface IPromptUtility {
        void ShowInputDialog(string title, string defaultValue, Action<string> onOk);
        void ShowInputDialog(string title, string defaultValue, Func<string, Task<string>> onOk);
    }
}
