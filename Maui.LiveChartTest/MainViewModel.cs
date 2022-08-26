using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Maui.LiveChartTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ISeries> series = new ObservableCollection<ISeries>();
        public ObservableCollection<ISeries> Series
        {
            get { return this.series; }
            set
            {
                series = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Series.Add(new PieSeries<double> { Values = new double[] { 2 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 4 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 1 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 4 } });
            Series.Add(new PieSeries<double> { Values = new double[] { 3 } });
        }
    }
}
