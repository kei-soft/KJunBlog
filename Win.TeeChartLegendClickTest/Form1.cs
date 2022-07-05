using Steema.TeeChart.Styles;

namespace Win.TeeChartLegendClickTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //this.tChart1.Panel.Pen = new ChartPen(Color.Black);

            for (int i = 0; i < 10; i++)
            {
                Points points = new Points(this.tChart1.Chart);

                points.FillSampleValues(20);
            }

            this.tChart1.ClickLegend += TChart1_ClickLegend;
        }

        private void TChart1_ClickLegend(object? sender, MouseEventArgs e)
        {
            int index = this.tChart1.Legend.Clicked(e.X, e.Y);

            if (index > -1)
            {
                for (int i = 0; i < this.tChart1.Series.Count; i++)
                {
                    this.tChart1[i].Transparency = 0;

                    if (i != index)
                    {
                        this.tChart1[i].Transparency = 70;
                    }
                }
            }
        }
    }
}