using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace Wpf.FontTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FontList();
        }

        /// <summary>
        /// 설치된 글꼴 명칭 확인
        /// </summary>
        private void FontList()
        {
            List<string> fontList = new List<string>();
            foreach (FontFamily font in Fonts.SystemFontFamilies)
            {
                fontList.Add(string.Join(",", font.FamilyNames.Values));
                Debug.WriteLine(string.Join(",", font.FamilyNames.Values));
            }
        }
    }
}
