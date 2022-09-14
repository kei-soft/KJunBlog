using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Maui.SearchBarTest.Models;
using Maui.SearchBarTest.Services;

namespace Maui.SearchBarTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<ItemModel> searchResults;
        public List<ItemModel> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchCommand => new Command<string>((query) =>
        {
            if (string.IsNullOrEmpty(query))
            {
                SearchResults = DataService.GetResult();
            }
            else
            {
                SearchResults = DataService.GetSearchResults(query);
            }
        });

        public MainViewModel()
        {
            SearchResults = DataService.GetResult();
        }
    }
}
