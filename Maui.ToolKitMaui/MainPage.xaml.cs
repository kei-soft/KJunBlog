using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

using Font = Microsoft.Maui.Font;

namespace Maui.ToolKitMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.statusBar.StatusBarColor = Colors.White;
            this.statusBar.StatusBarStyle = StatusBarStyle.DarkContent;
        }

        private void snackbarButton_Clicked(object sender, EventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Black,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
                Font = Font.SystemFontOfSize(14),
                ActionButtonFont = Font.SystemFontOfSize(14),
                CharacterSpacing = 0.5,
            };

            string text = "Show Snackbar!!";
            string actionButtonText = "Click Here Action Execute";
            Action action = async () => await DisplayAlert("Snackbar ActionButton", "Snackbar ActionButton  Click", "OK");
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

            snackbar.Show(cancellationTokenSource.Token);
        }

        private void toastButton_Clicked(object sender, EventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Toast.Make("This is a Toast", ToastDuration.Short, 14).Show(cancellationTokenSource.Token);
        }

        private void ChangeStatusBarColorButton_Clicked(object sender, EventArgs e)
        {
            this.statusBar.StatusBarColor = Color.FromRgb(63, 81, 181);
            this.statusBar.StatusBarStyle = StatusBarStyle.LightContent;
        }
    }
}