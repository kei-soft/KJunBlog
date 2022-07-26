using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Maui.ToolKitTest.ViewModels
{
    [INotifyPropertyChanged]
    internal partial class MainViewModel
    {
        [ObservableProperty]
        private string inputText = "";

        [RelayCommand]
        private void Reset()
        {
            InputText = "";
        }

        public MainViewModel()
        {
        }
    }
}
