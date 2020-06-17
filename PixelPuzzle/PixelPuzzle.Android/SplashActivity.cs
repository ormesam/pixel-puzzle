
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PixelPuzzle.Droid {
    [Activity(Theme = "@style/MainTheme.Splash", Icon = "@mipmap/ic_launcher", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, Label = "Pixel Puzzle", NoHistory = true)]
    public class SplashActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            StartActivity(typeof(MainActivity));
        }
    }
}