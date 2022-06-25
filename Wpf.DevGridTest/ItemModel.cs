using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Wpf.DevGridTest
{
    public class ItemModel //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //private Brush cellColor;

        public Brush CellColor { get; set; }
        //{
        //    get => this.cellColor;
        //    set
        //    {
        //        this.cellColor = value;
        //        OnPropertyChanged();
        //    }
        //}
    }
}
