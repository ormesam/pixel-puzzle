namespace PixelPuzzle.Contexts {
    public class MainContext {
        public MainContext() {
            UI = new UIContext(this);
            // Model = new ModelContext();
        }

        public UIContext UI { get; }
        public ModelContext Model { get; }
    }
}
