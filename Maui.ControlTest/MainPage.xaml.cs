using Maui.ControlTest.ViewModels;

namespace Maui.ControlTest
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