using System.Collections.ObjectModel;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Maui.LiveChartTest
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();
        public MainPage()
        {
            InitializeComponent();

            Series.Add(new PieSeries<double> { Values = new double[] { 2 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 4 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 1 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 4 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 3 } });

            this.BindingContext = this;
        }
    }
}