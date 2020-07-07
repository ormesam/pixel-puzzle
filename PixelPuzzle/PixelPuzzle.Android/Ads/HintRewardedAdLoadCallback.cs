using System;
using Android.Gms.Ads.Rewarded;

namespace PixelPuzzle.Droid.Ads {
    public class HintRewardedAdLoadCallback : RewardedAdLoadCallback {
        private readonly Action onLoaded;
        private readonly Action onLoadedFailed;

        public HintRewardedAdLoadCallback(Action onLoaded, Action onLoadedFailed) {
            this.onLoaded = onLoaded;
            this.onLoadedFailed = onLoadedFailed;
        }

        public override void OnRewardedAdLoaded() {
            base.OnRewardedAdLoaded();

            onLoaded();
        }

        public override void OnRewardedAdFailedToLoad(int p0) {
            onLoadedFailed();

            base.OnRewardedAdFailedToLoad(p0);
        }
    }
}