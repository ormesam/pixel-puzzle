using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Microsoft.AppCenter.Crashes;
using PixelPuzzle.Utility;
using Plugin.CurrentActivity;

namespace PixelPuzzle.Droid {
    [Activity(Label = "Pixel Puzzle", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        public MainActivity() {
            TaskScheduler.UnobservedTaskException += (sender, args) => {
                Crashes.TrackError(args.Exception);
            };

            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) => {
                Crashes.TrackError(args.Exception);
            };

            AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) => {
                if (e.ExceptionObject is Exception ex) {
                    Crashes.TrackError(ex);
                }
            };
        }

        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Android.Gms.Ads.MobileAds.Initialize(this, Constants.AdMobAppId);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}