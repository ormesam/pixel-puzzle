using System;
using System.Threading.Tasks;
using Android.Gms.Ads;
using Android.Gms.Ads.Rewarded;
using PixelPuzzle.Droid.Ads;
using PixelPuzzle.Utility;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(HintAd))]
namespace PixelPuzzle.Droid.Ads {
    public class HintAd : IHintAd {
        private RewardedAd ad;

        public void Load(Action onLoaded, Action onLoadedFailed) {
            ad = new RewardedAd(CrossCurrentActivity.Current.AppContext, Constants.HintAdMobKey);
#if DEBUG
            ad.LoadAd(new AdRequest.Builder().AddTestDevice("C9A23722CA1CA50E99E2084CB1B80DCF").Build(), new HintRewardedAdLoadCallback(onLoaded, onLoadedFailed));
#else
            ad.LoadAd(new AdRequest.Builder().Build(), new HintRewardedAdLoadCallback(onLoaded, onLoadedFailed));
#endif
        }

        public void Show(Func<Task> onRewarded, Func<Task> onClose) {
            if (ad == null || !ad.IsLoaded) {
                return;
            }

            var callback = new HintRewardedAdCallback(onRewarded, onClose);
            ad.Show(CrossCurrentActivity.Current.Activity, callback);
        }
    }
}