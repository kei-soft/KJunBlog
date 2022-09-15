﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

using Maui.ControlTest.Models;

namespace Maui.ControlTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<ItemModel> items;
        public List<ItemModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                NotifyPropertyChanged();
            }
        }

        public Command SiteCommand { get; set; }

        public MainViewModel()
        {
            List<ItemModel> itemModels = new List<ItemModel>();
            itemModels.Add(new ItemModel() { Name = "Korea", ID = 1 });
            itemModels.Add(new ItemModel() { Name = "Sudan", ID = 2 });
            itemModels.Add(new ItemModel() { Name = "United States", ID = 3 });
            itemModels.Add(new ItemModel() { Name = "Greece", ID = 4 });

            Items = itemModels;

            SiteCommand = new Command(OnSiteCommand);
        }

        private async void OnSiteCommand()
        {
            Uri uri = new Uri("http://kjun.kr");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
