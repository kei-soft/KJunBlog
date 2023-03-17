namespace Maui.ToolKitMaui;

public partial class DrawPage : ContentPage
{
    public DrawPage()
    {
        InitializeComponent();

        this.BindingContext = new DrawViewModel();
    }
}