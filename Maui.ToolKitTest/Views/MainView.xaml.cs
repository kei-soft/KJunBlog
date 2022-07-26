using Maui.ToolKitTest.ViewModels;

namespace Maui.ToolKitTest.Views
{
    public partial class MainView : ContentPage
    {
        int count = 0;

        public MainView()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }
    }
}