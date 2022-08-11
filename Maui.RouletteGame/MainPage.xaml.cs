namespace Maui.RouletteGame
{
    public partial class MainPage : ContentPage
    {
        #region Fields
        System.Timers.Timer timer = new System.Timers.Timer();
        #endregion

        #region MainPage
        public MainPage()
        {
            InitializeComponent();

            timer.Interval = 50;
            timer.Elapsed += Timer_Elapsed;
        }
        #endregion

        #region Timer_Elapsed
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                int ratation = (int)(this.circleImage.Rotation % 360);

                int value = ((ratation - 4) / 8) + 1;

                this.centerButton.Text = value.ToString();

            });
        }
        #endregion
        #region StartButton_Clicked
        private void StartButton_Clicked(object sender, EventArgs e)
        {
            timer.Start();
            Rotate();
        }
        #endregion
        #region StopButton_Clicked
        private async void StopButton_Clicked(object sender, EventArgs e)
        {
            uint duration = 1 * 1000;

            Random random = new Random();
            int no = random.Next(1, 45);

            this.centerButton.Text = no.ToString();

            await this.circleImage.RotateTo((2 * 360) + (no * 8 - 4), duration, Easing.SinOut);
            this.timer.Stop();
        }
        #endregion

        #region Rotate
        private async void Rotate()
        {
            uint duration = 10 * 60 * 1000;

            await Task.WhenAll(
             this.circleImage.RotateTo(2200 * 360, duration)
            );
        }
        #endregion
    }
}