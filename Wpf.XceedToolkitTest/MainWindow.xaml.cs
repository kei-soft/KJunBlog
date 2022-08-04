using System.Windows;

namespace Wpf.XceedToolkitTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Hello world!", "WPF ToolKit MessageBox", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}
