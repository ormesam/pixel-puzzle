namespace PixelPuzzle.Contexts {
    public class MainContext {
        public MainContext() {
            UI = new UIContext(this);
        }

        public UIContext UI { get; }
    }
}
