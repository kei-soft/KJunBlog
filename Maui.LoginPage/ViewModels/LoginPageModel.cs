using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.LoginPage.ViewModels
{
    public class LoginPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand MenuCommand => new Command<string>(p=>OnMenuCommand(p));

        private void OnMenuCommand(string menu)
        {
            Shell.Current.GoToAsync("//App/" + menu);
        }
    }
}