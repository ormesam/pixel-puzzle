using System;
using Xamarin.Forms;

namespace PixelPuzzle.Touch {
    public class TouchActionEventArgs : EventArgs {
        public long TouchId { get; private set; }
        public TouchActionType Type { get; private set; }
        public Point Location { get; private set; }
        public bool IsInContact { get; private set; }

        public TouchActionEventArgs(long id, TouchActionType type, Point location, bool isInContact) {
            TouchId = id;
            Type = type;
            Location = location;
            IsInContact = isInContact;
        }
    }
}
