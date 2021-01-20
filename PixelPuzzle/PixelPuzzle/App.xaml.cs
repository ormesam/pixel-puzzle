using System;
using Akavache;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PixelPuzzle.Contexts;
using PixelPuzzle.Screens.Home;
using PixelPuzzle.Utility;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PixelPuzzle {
    public partial class App : Application {
        public MainContext MainContext { get; }
        public static NavigationPage RootPage => Current.MainPage as NavigationPage;

        /*
         * Detect if this is a small phone which doesn't have much height compared to the width
         * Might need to adjust the layout if this is true
         * Inch  = Ratio
         * 3.4 = 1.8
         * 3.3 = 1.66666
         * 3.2 = 1.5
         * 2.7 = 2.2
        */
        public static bool IsSmallScreen {
            get {
                var screenHeight = DeviceDisplay.MainDisplayInfo.Height;
                var screenWidth = DeviceDisplay.MainDisplayInfo.Width;

                return screenHeight < 500 && (screenHeight / screenWidth) < 1.7;
            }
        }

        public App() {
            InitializeComponent();

            MainContext = new MainContext();

            MainPage = new NavigationPage(new MainScreen(MainContext));
        }

        protected override void OnStart() {
            AppCenter.Start(Constants.AppCentreKey, typeof(Analytics), typeof(Crashes));
            VersionTracking.Track();

            Analytics.TrackEvent("App Started");

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
