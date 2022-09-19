using Steema.TeeChart.Export;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;

namespace Win.TeeChartLegendClickTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set SampleData
            for (int i = 0; i < 10; i++)
            {
                Points points = new Points(this.tChart1.Chart);
                points.XValues.DateTime = true;
                //  ToolTip
                //points.GetSeriesMark += Points_GetSeriesMark;

                points.FillSampleValues(20);
            }

            this.tChart1.ClickLegend += TChart1_ClickLegend;
            this.tChart1.MouseClick += TChart1_MouseClick;
            this.tChart1.AfterDraw += TChart1_AfterDraw;

            //  ToolTip
            MarksTip marksTip = new MarksTip();
            marksTip.MouseDelay = 1;
            marksTip.Style = MarksStyles.XY;
            marksTip.MouseAction = MarksTipMouseAction.Move;
            //marksTip.GetText += MarksTip_GetText;
            this.tChart1.Tools.Add(marksTip);

            // Custom Line
            ColorLine colorLine = new ColorLine();
            colorLine.AllowDrag = false;
            colorLine.Pen.Color = Color.Black;
            colorLine.Axis = this.tChart1.Axes.Bottom;
            colorLine.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
            colorLine.Pen.EndCap = Steema.TeeChart.Drawing.LineCap.Round;
            colorLine.Pen.DashCap = Steema.TeeChart.Drawing.DashCap.Round;
            colorLine.Value = DateTime.Now.AddDays(10).ToOADate();

            this.tChart1.Tools.Add(colorLine);
        }

        private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
            // Custom Label
            g.ClearClipRegions();
            g.Font.Name = "Arial";
            g.Font.Color = Color.Black;

            int x = this.tChart1.Axes.Bottom.CalcPosValue(DateTime.Now.AddDays(10).ToOADate());
            int y = this.tChart1.Axes.Left.CalcPosValue(this.tChart1.Axes.Left.Minimum);

            string text = "TEST";
            int margin = (int)Math.Ceiling(g.MeasureString(g.Font, Text).Height);

            g.RotateLabel(x + margin, y, text, 90);
        }

        private void Points_GetSeriesMark(Series Series, GetSeriesMarkEventArgs e)
        {
            e.MarkText = $"X : {Series.XValues[e.ValueIndex].ToString()}, Y : {Series.YValues[e.ValueIndex].ToString()} ";
        }

        private void MarksTip_GetText(MarksTip sender, MarksTipGetTextEventArgs e)
        {
            e.Text = e.Text;
        }

        private void TChart1_ClickLegend(object? sender, MouseEventArgs e)
        {
            int index = this.tChart1.Legend.Clicked(e.X, e.Y);

            if (index > -1)
            {
                for (int i = 0; i < this.tChart1.Series.Count; i++)
                {
                    // 선택된 Legend 강조
                    this.tChart1[i].Transparency = 0;

                    if (i != index)
                    {
                        // 선택되지 않은 항목 반?투명하게 처리
                        this.tChart1[i].Transparency = 70;
                    }
                }
            }
        }

        private void TChart1_MouseClick(object? sender, MouseEventArgs e)
        {
            // Legend 영역이 아닌 경우 모두 원상태로 돌리기
            int index = this.tChart1.Legend.Clicked(e.X, e.Y);

            if (index > -1)
            {
                return;
            }
            else
            {
                for (int i = 0; i < this.tChart1.Series.Count; i++)
                {
                    this.tChart1[i].Transparency = 0;
                }
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            // Save Excel
            string fielPath = "d://test.xls";
            DataExport dataExport = new DataExport(this.tChart1);
            ExcelFormat excelFormat = dataExport.Excel;

            excelFormat.IncludeHeader = true;
            excelFormat.IncludeIndex = true;
            excelFormat.IncludeLabels = true;

            excelFormat.Save(fielPath);
        }
    }
}