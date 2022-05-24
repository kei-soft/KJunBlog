namespace Maui.PopupTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new TestPopupPage());
        }
    }
}