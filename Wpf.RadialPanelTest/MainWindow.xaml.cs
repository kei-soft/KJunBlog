using System.Windows;
using System.Windows.Controls;

namespace Wpf.RadialPanelTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Content = "Button " + (i + 1);
                byHeightRadialPanel.Children.Add(btn);
            }

            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Content = "Button " + (i + 1);
                byWidthRadialPanel.Children.Add(btn);
            }
        }
    }
}
