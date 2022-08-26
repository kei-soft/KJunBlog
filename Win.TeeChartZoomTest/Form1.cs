using Steema.TeeChart.Styles;

namespace Win.TeeChartZoomTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set Sample
            for (int i = 0; i < 10; i++)
            {
                Points points = new Points(this.tChart1.Chart);

                points.FillSampleValues(20);
            }

            SetMinMaxChart();

            // Zoom In
            this.tChart1.Zoomed += TChart1_Zoomed;

            // Zoom Cancel
            this.tChart1.UndoneZoom += (s, e) => SetMinMaxChart();
        }

        private void SetMinMaxChart()
        {
            this.xminLabel.Text = this.tChart1.Axes.Bottom.MinXValue.ToString();
            this.xmaxLabel.Text = this.tChart1.Axes.Bottom.MaxXValue.ToString();

            this.yminLabel.Text = this.tChart1.Axes.Left.MinYValue.ToString();
            this.ymaxLabel.Text = this.tChart1.Axes.Left.MaxYValue.ToString();
        }

        private void TChart1_Zoomed(object? sender, EventArgs e)
        {
            // Chart.Zoom 의 x0 x1 y0 y1 값을 가지고 각 축의 CalcPosPoint 함수를 통해 값을 반환
            double zoomXMinValue = this.tChart1.Axes.Bottom.CalcPosPoint(this.tChart1.Zoom.x0);
            double zoomXMaxValue = this.tChart1.Axes.Bottom.CalcPosPoint(this.tChart1.Zoom.x1);

            double doubleYMinValue = this.tChart1.Axes.Left.CalcPosPoint(this.tChart1.Zoom.y1);
            double doubleYMaxValue = this.tChart1.Axes.Left.CalcPosPoint(this.tChart1.Zoom.y0);

            this.xminLabel.Text = zoomXMinValue.ToString();
            this.xmaxLabel.Text = zoomXMaxValue.ToString();

            this.yminLabel.Text = doubleYMinValue.ToString();
            this.ymaxLabel.Text = doubleYMaxValue.ToString();
        }
    }
}