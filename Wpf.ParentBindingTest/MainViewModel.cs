using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Wpf.ParentBindingTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private bool isShowPopup = false;

        public bool IsShowPopup
        {
            get => this.isShowPopup;
            set
            {
                this.isShowPopup = value;
                OnPropertyChanged();
            }
        }

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
            items.Add(new ItemModel() { Name = nameof(Color.Blue), Value = Color.Blue.GetHue() });
            items.Add(new ItemModel() { Name = nameof(Color.Yellow), Value = Color.Yellow.GetHue() });
            //items.Add(new ItemModel() { Name = nameof(Color.Green), Value = Color.Green.GetHue() });
            //items.Add(new ItemModel() { Name = nameof(Color.Red), Value = Color.Red.GetHue() });
            //items.Add(new ItemModel() { Name = nameof(Color.Purple), Value = Color.Purple.GetHue() });
        }
    }
}
