using Maui.ToolKitTest.Views;

namespace Maui.ToolKitTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainView();
        }
    }
}