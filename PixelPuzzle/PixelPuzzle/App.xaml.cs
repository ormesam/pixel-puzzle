using System;
using Akavache;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PixelPuzzle.Contexts;
using PixelPuzzle.Screens.Puzzle;
using PixelPuzzle.Utility;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PixelPuzzle {
    public partial class App : Application {
        public static NavigationPage RootPage => Current.MainPage as NavigationPage;

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuScreen(new MainContext()));
        }

        protected override void OnStart() {
            AppCenter.Start(Constants.AppCentreKey, typeof(Analytics), typeof(Crashes));
            VersionTracking.Track();

#if DEBUG
            BlobCache.ApplicationName = "PixelPuzzleDev";
#else
            BlobCache.ApplicationName = "PixelPuzzle";
#endif
            BlobCache.EnsureInitialized();
            BlobCache.ForcedDateTimeKind = DateTimeKind.Utc;
        }

        protected override void OnSleep() {
            BlobCache.LocalMachine.Flush();
        }

        protected override void OnResume() {
        }
    }
}
