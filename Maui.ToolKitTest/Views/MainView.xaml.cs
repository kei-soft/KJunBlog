using Maui.ToolKitTest.ViewModels;

namespace Maui.ToolKitTest.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }
    }
}