using PixelPuzzle.Contexts;
using PixelPuzzle.Logic;
using PixelPuzzle.Utility;
using Xamarin.Forms;

namespace PixelPuzzle.Screens.Puzzle {
    public class HintModalViewModel : ViewModelBase {
        private bool adLoaded;
        private bool adFailedToLoad;
        private readonly IHintAd ad;
        private readonly Game game;
        private readonly Line line;

        public HintModalViewModel(MainContext context, Game game, Line line) : base(context) {
            ad = DependencyService.Get<IHintAd>();
            this.line = line;
            this.game = game;
        }

        public bool AdLoaded {
            get { return adLoaded; }
            set {
                if (adLoaded != value) {
                    adLoaded = value;
                    OnPropertyChanged(nameof(AdLoaded));
                    OnPropertyChanged(nameof(WatchText));
                }
            }
        }

        public bool AdFailedToLoad {
            get { return adFailedToLoad; }
            set {
                if (adFailedToLoad != value) {
                    adFailedToLoad = value;
                    OnPropertyChanged(nameof(AdFailedToLoad));
                    OnPropertyChanged(nameof(WatchText));
                }
            }
        }

        public string WatchText => AdLoaded ? "Watch Ad" : AdFailedToLoad ? "Ad failed to load" : "Loading...";

        public void LoadAd() {
            ad.Load(() => {
                AdLoaded = true;
            }, () => {
                AdFailedToLoad = true;
            });
        }

        public void ShowAd(INavigation nav) {
            ad.Show(async () => {
                await line.ShowHint();
            }, async () => {
                await nav.PopModalAsync();

                game.CheckIsComplete();
            });
        }
    }
}
