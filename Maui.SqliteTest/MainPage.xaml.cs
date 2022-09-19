using Maui.SqliteTest.ViewModels;

namespace Maui.SqliteTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }

    }
}