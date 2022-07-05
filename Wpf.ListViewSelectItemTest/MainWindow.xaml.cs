using System.Collections.Generic;
using System.Windows;

namespace Wpf.ListViewSelectItemTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> Datas { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            Datas = new List<string>();
            Datas.Add("1");
            Datas.Add("2");
            Datas.Add("3");
            Datas.Add("4");

            this.DataContext = this;
        }
    }
}
