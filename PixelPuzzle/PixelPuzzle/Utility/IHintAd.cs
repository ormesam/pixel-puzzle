using System;
using System.Threading.Tasks;

namespace PixelPuzzle.Utility {
    public interface IHintAd {
        void Load(Action whenLoaded);

        void Show(Func<Task> whenComplete);
    }
}
