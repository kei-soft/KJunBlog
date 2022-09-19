using Steema.TeeChart.Export;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;

namespace Win.TeeChartLegendClickTest
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();

            // Set SampleData
            for (int i = 0; i < 10; i++)
            {
                Points points = new Points(this.tChart.Chart);
                points.XValues.DateTime = true;

                //  ToolTip
                points.GetSeriesMark += Points_GetSeriesMark;

                points.FillSampleValues(20);
            }

            this.tChart.ClickLegend += TChart1_ClickLegend;
            this.tChart.MouseClick += TChart1_MouseClick;
            this.tChart.AfterDraw += TChart1_AfterDraw;

            //  ToolTip
            MarksTip marksTip = new MarksTip();
            marksTip.MouseDelay = 1;
            marksTip.Style = MarksStyles.XY;
            marksTip.MouseAction = MarksTipMouseAction.Move;
            this.tChart.Tools.Add(marksTip);

            // X Custom Line
            ColorLine colorLinex = new ColorLine();
            colorLinex.AllowDrag = false;
            colorLinex.Pen.Color = Color.Black;
            colorLinex.Axis = this.tChart.Axes.Bottom;
            colorLinex.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
            colorLinex.Pen.EndCap = Steema.TeeChart.Drawing.LineCap.Round;
            colorLinex.Pen.DashCap = Steema.TeeChart.Drawing.DashCap.Round;
            colorLinex.Value = DateTime.Now.AddDays(10).ToOADate();

            this.tChart.Tools.Add(colorLinex);

            // Y Custom Line
            ColorLine colorLiney = new ColorLine();
            colorLiney.AllowDrag = false;
            colorLiney.Pen.Color = Color.Black;
            colorLiney.Axis = this.tChart.Axes.Left;
            colorLiney.Pen.Style = Steema.TeeChart.Drawing.DashStyle.DashDot;
            colorLiney.Pen.EndCap = Steema.TeeChart.Drawing.LineCap.Round;
            colorLiney.Pen.DashCap = Steema.TeeChart.Drawing.DashCap.Round;
            colorLiney.Value = (this.tChart.Axes.Left.MinYValue + this.tChart.Axes.Left.MaxYValue) / 2;

            this.tChart.Tools.Add(colorLiney);
        }

        private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
            // Custom Label
            g.ClearClipRegions();
            g.Font.Name = "Arial";
            g.Font.Color = Color.Black;

            int x = this.tChart.Axes.Bottom.CalcPosValue(DateTime.Now.AddDays(10).ToOADate());
            int y = this.tChart.Axes.Left.CalcPosValue(this.tChart.Axes.Left.Minimum);

            string text = "TEST";
            int margin = (int)Math.Ceiling(g.MeasureString(g.Font, Text).Height);

            g.RotateLabel(x + margin, y, text, 90);
        }

        private void Points_GetSeriesMark(Series Series, GetSeriesMarkEventArgs e)
        {
            e.MarkText = $"X : {DateTime.FromOADate(Series.XValues[e.ValueIndex]).ToString("yyyy-MM-dd")}\r\nY : {Series.YValues[e.ValueIndex].ToString()} ";
        }

        private void MarksTip_GetText(MarksTip sender, MarksTipGetTextEventArgs e)
        {
            e.Text = e.Text;
        }

        private void TChart1_ClickLegend(object? sender, MouseEventArgs e)
        {
            int index = this.tChart.Legend.Clicked(e.X, e.Y);

            if (index > -1)
            {
                for (int i = 0; i < this.tChart.Series.Count; i++)
                {
                    // 선택된 Legend 강조
                    this.tChart[i].Transparency = 0;

                    if (i != index)
                    {
                        // 선택되지 않은 항목 반?투명하게 처리
                        this.tChart[i].Transparency = 70;
                    }
                }
            }
        }

        private void TChart1_MouseClick(object? sender, MouseEventArgs e)
        {
            // Legend 영역이 아닌 경우 모두 원상태로 돌리기
            int index = this.tChart.Legend.Clicked(e.X, e.Y);

            if (index > -1)
            {
                return;
            }
            else
            {
                for (int i = 0; i < this.tChart.Series.Count; i++)
                {
                    this.tChart[i].Transparency = 0;
                }
            }
        }

        private void ExcelButton_Click(object sender, EventArgs e)
        {
            // Save Excel
            string fielPath = "d://test.xls";
            DataExport dataExport = new DataExport(this.tChart);
            ExcelFormat excelFormat = dataExport.Excel;

            excelFormat.IncludeHeader = true;
            excelFormat.IncludeIndex = true;
            excelFormat.IncludeLabels = true;

            excelFormat.Save(fielPath);
        }
    }
}