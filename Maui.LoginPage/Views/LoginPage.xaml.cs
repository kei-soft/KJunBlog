using Maui.LoginPage.ViewModels;

namespace Maui.LoginPage.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginPageModel();
        }
    }
}