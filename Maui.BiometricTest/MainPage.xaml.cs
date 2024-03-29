﻿using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Maui.BiometricTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IFingerprint fingerprint)
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration("지문인증", "지문을 인식해주세요.");

            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                await DisplayAlert("지문인식 성공!", "접근가능", "OK");
            }
            else
            {
                await DisplayAlert("지문인식 실패!", "접근불가", "OK");
            }
        }
    }
}