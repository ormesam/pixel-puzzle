using System;
using Android.Gms.Ads.Rewarded;

namespace PixelPuzzle.Droid.Ads {
    public class HintRewardedAdLoadCallback : RewardedAdLoadCallback {
        private readonly Action whenLoaded;

        public HintRewardedAdLoadCallback(Action whenLoaded) {
            this.whenLoaded = whenLoaded;
        }

        public override void OnRewardedAdLoaded() {
            base.OnRewardedAdLoaded();

            whenLoaded();
        }
    }
}