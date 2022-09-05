namespace Maui.MapTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void NavigateToMap()
        {
            var location = new Location(37.442018, 126.996245);
            var options = new MapLaunchOptions { Name = "관문체육공원" };

            try
            {
                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
            }
        }

        public async void DriveToMap()
        {
            var location = new Location(37.442018, 126.996245);
            var options = new MapLaunchOptions
            {
                Name = "관문체육공원",
                NavigationMode = NavigationMode.Driving
            };

            try
            {
                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
            }
        }

        private void LocationButton_Clicked(object sender, EventArgs e)
        {
            NavigateToMap();
        }

        private void DriveButton_Clicked(object sender, EventArgs e)
        {
            DriveToMap();
        }

    }
}