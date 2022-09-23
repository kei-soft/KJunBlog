using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using CommunityToolkit.Maui.Alerts;

namespace Maui.ToolKitMaui
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand AnimationCommand => new Command(() => OnAnimationCommand());

        private void OnAnimationCommand()
        {
            Snackbar.Make("Animation Command").Show();
        }

        public ICommand EventToCommand => new Command(() => OnEventToCommand());

        private void OnEventToCommand()
        {
            Toast.Make("Event To Command").Show();
        }
    }
}
