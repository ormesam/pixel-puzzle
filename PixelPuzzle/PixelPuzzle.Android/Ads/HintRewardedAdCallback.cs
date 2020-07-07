using System;
using System.Threading.Tasks;
using Android.Gms.Ads.Rewarded;

namespace PixelPuzzle.Droid.Ads {
    public class HintRewardedAdCallback : RewardedAdCallback {
        private readonly Func<Task> whenComplete;
        private readonly Func<Task> onClose;

        public HintRewardedAdCallback(Func<Task> whenComplete, Func<Task> onClose) {
            this.whenComplete = whenComplete;
            this.onClose = onClose;
        }

        public override async void OnUserEarnedReward(IRewardItem p0) {
            base.OnUserEarnedReward(p0);

            await whenComplete?.Invoke();
        }

        public override async void OnRewardedAdClosed() {
            base.OnRewardedAdClosed();

            await onClose();
        }
    }
}