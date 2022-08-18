using Maui.SearchBarTest.Services;
using Maui.SearchBarTest.ViewModels;

namespace Maui.SearchBarTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // MVVM
            this.BindingContext = new MainViewModel();

            // NO MVVM
            //this.collectionView.ItemsSource = DataService.GetResult();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                this.collectionView.ItemsSource = DataService.GetResult();
            }
            else
            {
                this.collectionView.ItemsSource = DataService.GetSearchResults(e.NewTextValue);
            }
        }
    }
}