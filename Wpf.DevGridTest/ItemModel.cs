using System.Drawing;

namespace Wpf.DevGridTest
{
    public class ItemModel //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //private Brush cellColor;

        public Brush CellColor { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
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
