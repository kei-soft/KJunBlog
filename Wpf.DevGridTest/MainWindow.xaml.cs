using System;
using System.Windows;
using System.Windows.Media.Imaging;

using DevExpress.Xpf.Bars;

namespace Wpf.DevGridTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void TableView_CanSelectCell(object sender, DevExpress.Xpf.Grid.CanSelectCellEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                e.CanSelectCell = false;
            }
        }

        private void TableView_ShowGridMenu(object sender, DevExpress.Xpf.Grid.GridMenuEventArgs e)
        {
            BarButtonItem menu1 = new BarButtonItem();
            menu1.Name = "menu1";
            menu1.Content = "Menu1";
            menu1.ItemClick += Menu1_ItemClick;
            menu1.Glyph = new BitmapImage(new Uri("pack://application:,,,/kei.png"));


            BarButtonItem menu2 = new BarButtonItem();
            menu2.Name = "menu2";
            menu2.Content = "Menu2";
            menu2.ItemClick += Menu2_ItemClick;
            menu2.Glyph = new BitmapImage(new Uri("pack://application:,,,/kei.png"));

            e.Customizations.Add(menu1);
            e.Customizations.Add(menu2);
        }

        private void Menu1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Menu2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

    }
}
