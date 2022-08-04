using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Wpf.XceedToolkitTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private ObservableCollection<ItemModel> items;

        public ObservableCollection<ItemModel> Items
        {
            get => this.items;
            set
            {
                this.items = value;
                OnPropertyChanged();
            }
        }

        private ItemModel selectedValue;

        public ItemModel SelectedValue
        {
            get => this.selectedValue;
            set
            {
                this.selectedValue = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ItemModel> selectedItems;

        public ObservableCollection<ItemModel> SelectedItems
        {
            get => this.selectedItems;
            set
            {
                this.selectedItems = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            items = new ObservableCollection<ItemModel>();
            items.Add(new ItemModel() { Name = nameof(Color.Blue), Value = Color.Blue });
            items.Add(new ItemModel() { Name = nameof(Color.Yellow), Value = Color.Yellow });
            items.Add(new ItemModel() { Name = nameof(Color.Green), Value = Color.Green });
            items.Add(new ItemModel() { Name = nameof(Color.Red), Value = Color.Red });
            items.Add(new ItemModel() { Name = nameof(Color.Purple), Value = Color.Purple });
        }
    }

}
