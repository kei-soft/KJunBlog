namespace Maui.ScreenShotTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnScreenShot(object sender, EventArgs e)
        {
            this.image.Source = await TakeScreenshotAsync();
        }

        public async Task<ImageSource> TakeScreenshotAsync()
        {
            if (Screenshot.Default.IsCaptureSupported)
            {
                IScreenshotResult screenShotResult = await Screenshot.Default.CaptureAsync();
                Stream stream = await screenShotResult.OpenReadAsync();

                return ImageSource.FromStream(() => stream);
            }

            return null;
        }
    }
}