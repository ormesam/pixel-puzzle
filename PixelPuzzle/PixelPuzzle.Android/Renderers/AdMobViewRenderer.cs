using System.ComponentModel;
using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using PixelPuzzle.Controls;
using PixelPuzzle.Droid.Renderers;
using PixelPuzzle.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace PixelPuzzle.Droid.Renderers {
    public class AdMobViewRenderer : ViewRenderer<AdMobView, AdView> {
        public AdMobViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control == null) {
                var ad = new AdView(Context) {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = Constants.BannerAdMobKey,
                };

                ad.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                ad.LoadAd(new AdRequest.Builder().Build());
                e.NewElement.HeightRequest = GetSmartBannerDpHeight();

                SetNativeControl(ad);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(AdView.AdUnitId)) {
                Control.AdUnitId = Constants.BannerAdMobKey;
            }
        }

        private int GetSmartBannerDpHeight() {
            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            if (dpHeight <= 400) {
                return 32;
            }

            if (dpHeight > 400 && dpHeight <= 720) {
                return 50;
            }

            return 90;
        }
    }
}