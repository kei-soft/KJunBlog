using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Wpf.DevGridTest
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

        public MainViewModel()
        {
            items = new ObservableCollection<ItemModel>();
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Blue) });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Yellow) });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Green) });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Red) });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Purple) });

            this.Items = items;
        }
    }
}
