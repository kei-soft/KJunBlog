using System.Text;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;

using Font = Microsoft.Maui.Font;

namespace Maui.ToolKitMaui
{
    public partial class MainPage : ContentPage
    {
        IFileSaver fileSaver;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainPage(IFileSaver fileSaver)
        {
            InitializeComponent();

            this.fileSaver = fileSaver;

            this.BindingContext = new MainViewModel();

            CheckPermission();

            this.statusBar.StatusBarColor = Colors.White;
            this.statusBar.StatusBarStyle = StatusBarStyle.DarkContent;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Thread t = new Thread(() =>
            {
                Thread.Sleep(500);
                if (this.BindingContext is MainViewModel mainViewModel)
                {
                    mainViewModel.Progress = 0.5;
                }
            });

            t.Start();
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
            Toast.Make("This is a Toast", ToastDuration.Short, 14).Show(cancellationTokenSource.Token);
        }

        private void ChangeStatusBarColorButton_Clicked(object sender, EventArgs e)
        {
            this.statusBar.StatusBarColor = Color.FromRgb(63, 81, 181);
            this.statusBar.StatusBarStyle = StatusBarStyle.LightContent;
        }

        private async void fileButton_Clicked(object sender, EventArgs e)
        {
            using var stream = new MemoryStream(Encoding.Default.GetBytes(this.saveEntry.Text));

            var result = await this.fileSaver.SaveAsync("test.txt", stream, cancellationTokenSource.Token);

            if (result.IsSuccessful)
            {
                this.savePathLabel.Text = result.FilePath;
            }
        }

        private async void pickButton_Clicked(object sender, EventArgs e)
        {
            var result = await FolderPicker.PickAsync(cancellationTokenSource.Token);

            if (result.IsSuccessful)
            {
                this.pickPathLabel.Text = result.Folder.Path;
            }
        }

        private async void CheckPermission()
        {
            PermissionStatus readStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (readStatus != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
                {
                    await DisplayAlert("Permission", "Need Permissions", "OK");
                }

                var status = await Permissions.RequestAsync<Permissions.StorageRead>();

                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permission Check", "Need Permissions", "OK");
                    return;
                }

                if (readStatus == PermissionStatus.Granted)
                {
                    PermissionStatus writeStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

                    if (writeStatus != PermissionStatus.Granted)
                    {
                        if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
                        {
                            await DisplayAlert("Permission", "Need Permissions", "OK");
                        }

                        status = await Permissions.RequestAsync<Permissions.StorageWrite>();

                        if (status != PermissionStatus.Granted)
                        {
                            await DisplayAlert("Permission Check", "Need Permissions", "OK");
                            return;
                        }
                    }
                }
            }
        }
    }
}