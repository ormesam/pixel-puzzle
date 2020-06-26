using System;
using System.Threading.Tasks;
using Android.Gms.Ads.Rewarded;

namespace PixelPuzzle.Droid.Ads {
    public class HintRewardedAdCallback : RewardedAdCallback {
        private readonly Func<Task> whenComplete;

        public HintRewardedAdCallback(Func<Task> whenComplete) {
            this.whenComplete = whenComplete;
        }

        public override async void OnUserEarnedReward(IRewardItem p0) {
            base.OnUserEarnedReward(p0);

            await whenComplete?.Invoke();
        }
    }
}