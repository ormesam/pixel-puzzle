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

        public void Load(Action whenLoaded) {
            ad = new RewardedAd(CrossCurrentActivity.Current.AppContext, Constants.HintAdMobKey);
#if DEBUG
            ad.LoadAd(new AdRequest.Builder().AddTestDevice("25A827ECEB216919C8A883CDC21B651A").Build(), new HintRewardedAdLoadCallback(whenLoaded));
#else
            ad.LoadAd(new AdRequest.Builder().Build(), new HintRewardedAdLoadCallback(whenLoaded));
#endif
        }

        public void Show(Func<Task> whenComplete) {
            if (ad == null || !ad.IsLoaded) {
                return;
            }

            var callback = new HintRewardedAdCallback(whenComplete);
            ad.Show(CrossCurrentActivity.Current.Activity, callback);
        }
    }
}