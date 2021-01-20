using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace PixelPuzzle.Droid {
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            Intent intent = new Intent(Application.ApplicationContext, typeof(MainActivity));

            intent.ReplaceExtras(Intent);

            StartActivity(intent);
        }
    }
}