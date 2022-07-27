using System.Diagnostics;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Maui.ToolKitTest.ViewModels
{
    [INotifyPropertyChanged]
    internal partial class MainViewModel
    {
        [ObservableProperty]
        private string inputText = "";

        [ObservableProperty]
        private string name;

        partial void OnNameChanging(string value)
        {
            InputText = "CHANGING";
            Debug.WriteLine($"Name is about to change to {value}");
        }

        partial void OnNameChanged(string value)
        {
            InputText = "CHANGED : " + Name;
            Debug.WriteLine($"Name has changed to {value}");
        }

        [RelayCommand]
        private void Reset()
        {
            InputText = "";
        }

        [RelayCommand]
        private void ChangeText(string text)
        {
            InputText = text;
        }

        public MainViewModel()
        {
        }
    }
}
