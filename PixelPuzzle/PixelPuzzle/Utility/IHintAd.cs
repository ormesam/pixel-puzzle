using System;
using System.Threading.Tasks;

namespace PixelPuzzle.Utility {
    public interface IHintAd {
        void Load(Action onLoaded, Action onLoadedFailed);

        void Show(Func<Task> onReward, Func<Task> onClose);
    }
}
