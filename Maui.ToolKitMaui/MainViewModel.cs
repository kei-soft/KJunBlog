﻿using System.ComponentModel;
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

        double progress = 0;
        public double Progress
        {
            get
            {
                return this.progress;
            }
            set
            {
                this.progress = value;
                OnPropertyChanged();
            }
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

        public ICommand ProgressAnimationCommand => new Command(() => OnProgressAnimationCommand());

        private void OnProgressAnimationCommand()
        {
            if (this.Progress != 0.8)
            {
                this.Progress = 0.8;
            }
            else
            {
                this.Progress = 0.5;
            }
        }
        public ICommand DrawPageCommand => new Command(() => OnDrawPageCommand());

        private async void OnDrawPageCommand()
        {
            await Shell.Current.GoToAsync("drawpage");
        }
    }
}
