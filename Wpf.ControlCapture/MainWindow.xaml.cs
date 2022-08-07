using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wpf.ControlCapture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CaputreControl(this.captureGrid, "D:\\test.png");
        }

        /// <summary>
        /// Element 를 Capture 하여 저장합니다.
        /// </summary>
        /// <param name="element">컨트롤명</param>
        /// <param name="filePath">저장파일명</param>
        private void CaputreControl(FrameworkElement element, string filePath)
        {
            Rect rectangle = new Rect(0, 0, element.ActualWidth, element.ActualHeight);

            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext context = visual.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(element);

                context.DrawRectangle(brush, null, new Rect(rectangle.Size));
            }

            int width = (int)element.ActualWidth;
            int height = (int)element.ActualHeight;

            RenderTargetBitmap bitmap = new RenderTargetBitmap
            (
                width,
                height,
                96,
                96,
                PixelFormats.Pbgra32
            );

            bitmap.Render(visual);

            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                encoder.Save(stream);
            }
        }
    }
}
