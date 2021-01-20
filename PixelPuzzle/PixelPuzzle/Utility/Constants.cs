namespace PixelPuzzle.Utility {
    public static class Constants {
        public const string AdMobAppId = "ca-app-pub-1992270298763477~2946433905";
#if DEBUG
        public static string BannerAdMobKey => "ca-app-pub-3940256099942544/6300978111";
        public static string AppCentreKey => "android=1a4d8847-20f0-45c7-95af-51d93965d116;";
        public static string HintAdMobKey => "ca-app-pub-3940256099942544/5224354917";
#else
        public static string BannerAdMobKey => "ca-app-pub-1992270298763477/8708583393";
        public static string HintAdMobKey => "ca-app-pub-1992270298763477/9358232347";
        public static string AppCentreKey => "android=9c6930a2-f8b1-4993-8f0a-3d4631c184dc;";
#endif
    }
}
