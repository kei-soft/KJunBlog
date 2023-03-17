using System.Threading;

namespace Wpf.Test
{
    public class AsyncSampleData
    {
        private string fastValue;
        private string slowerValue;
        private string slowestValue;

        public string FastValue
        {
            get { return fastValue; }
            set { fastValue = value; }
        }

        public string SlowerValue
        {
            get
            {
                Thread.Sleep(3000);

                return this.slowerValue;
            }
            set
            {
                this.slowerValue = value;
            }
        }

        public string SlowestValue
        {
            get
            {
                Thread.Sleep(5000);

                return this.slowestValue;
            }
            set
            {
                this.slowestValue = value;
            }
        }
    }
}
