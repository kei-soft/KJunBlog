using Plugin.MauiMTAdmob;

namespace Maui.AdmobTest
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            /* Test ID

            Android
            https://developers.google.com/admob/android/test-ads?hl=ko
            앱 오프닝 광고	            ca-app-pub-3940256099942544/3419835294
            배너 광고	                ca-app-pub-3940256099942544/6300978111
            전면 광고	                ca-app-pub-3940256099942544/1033173712
            전면 동영상 광고	        ca-app-pub-3940256099942544/8691691433
            보상형 광고	                ca-app-pub-3940256099942544/5224354917
            보상형 전면 광고	        ca-app-pub-3940256099942544/5354046379
            네이티브 광고 고급형	    ca-app-pub-3940256099942544/2247696110
            네이티브 동영상 광고 고급형	ca-app-pub-3940256099942544/1044960115

            iOS
            https://developers.google.com/admob/ios/test-ads#demo_ad_units
            앱 오프닝 광고	            ca-app-pub-3940256099942544/5662855259
            배너 광고	                ca-app-pub-3940256099942544/2934735716
            전면 광고	                ca-app-pub-3940256099942544/4411468910
            전면 동영상 광고	        ca-app-pub-3940256099942544/5135589807
            보상형 광고	                ca-app-pub-3940256099942544/1712485313
            보상형 전면 광고	        ca-app-pub-3940256099942544/6978759866
            네이티브 광고 고급형	    ca-app-pub-3940256099942544/3986624511
            네이티브 동영상 광고 고급형	ca-app-pub-3940256099942544/2521693316
             */

            if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
            {
#if DEBUG
                this.mtAdView.AdsId = "ca-app-pub-3940256099942544/6300978111";
#else
                this.mtAdView.AdsId = "ca-app-pub-4681470946279796/8704183347";
#endif
            }
            else
            {
#if DEBUG
                this.mtAdView.AdsId = "ca-app-pub-3940256099942544/2934735716";
#else
                this.mtAdView.AdsId = "ca-app-pub-4681470946279796/2297437537";
#endif
            }

            CrossMauiMTAdmob.Current.OnInterstitialOpened += (s, e) => DisplayAlert("AdMobTest", "Interstitial Open", "OK");
            CrossMauiMTAdmob.Current.OnInterstitialClosed += (s, e) => DisplayAlert("AdMobTest", "Interstitial Close", "OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            /* 전면 광고 표시 */

            // 이미 로드되어있는 확인
            bool isInterstitialLoaded = CrossMauiMTAdmob.Current.IsInterstitialLoaded();

            if (!isInterstitialLoaded)
            {
                if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
                {
#if DEBUG
                    CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
#else
                CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
#endif
                }
                else
                {
#if DEBUG
                    CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/4411468910");
#else
                CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/4411468910");
#endif
                }
            }

            CrossMauiMTAdmob.Current.ShowInterstitial();
        }
    }
}