using Xamarin.Forms;

namespace PixelPuzzle.Touch {
    public class TouchEffect : RoutingEffect {
        public event TouchActionEventHandler TouchAction;

        public TouchEffect() : base("PixelPuzzle.TouchEffect") {
        }

        public bool Capture { set; get; } = true;

        public void OnTouchAction(Element element, TouchActionEventArgs args) {
            TouchAction?.Invoke(element, args);
        }
    }
}
