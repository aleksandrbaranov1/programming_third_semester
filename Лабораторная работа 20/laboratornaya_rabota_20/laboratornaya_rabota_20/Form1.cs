using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace laboratornaya_rabota_20
{
    public partial class laboratornaya_rabota_20 : Form
    {
        public laboratornaya_rabota_20()
        {
            InitializeComponent();
        }
        private void showAllRows_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea
            {
                AxisX =
                {
                    Minimum = 0,
                    Maximum = 100,
                    Interval = 10 
                },
                AxisY =
                {
                    Minimum = -10,
                    Maximum = 2,
                    Interval = 0.5 
                }
            };

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            mainChart.ChartAreas.Add(chartArea);

            string path = @"C:\Users\sabba\OneDrive\Рабочий стол\programming_third_semester\programming_third_semester\laboratornaya_rabota_20\laboratornaya_rabota_20\bin\Debug\points.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                Series series = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 1,
                    Color = Color.Black
                };

                string[] points = line.Split(';');

                foreach (string point in points)
                {
                    string[] coordinates = point.Split(',');

                    if (coordinates.Length == 2 &&
                        double.TryParse(coordinates[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) &&
                        double.TryParse(coordinates[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
                    {
                        series.Points.AddXY(x, y);
                    }
                }
                mainChart.Series.Add(series);
            }
        }

        private void showSelectedRow_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea
            {
                AxisX =
                {
                    Minimum = 0,
                    Maximum = 100,
                    Interval = 10
                },
                AxisY =
                {
                    Minimum = -10,
                    Maximum = 2,
                    Interval = 0.5 
                }
            };

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            mainChart.ChartAreas.Add(chartArea);

            string path = @"C:\Users\sabba\OneDrive\Рабочий стол\programming_third_semester\programming_third_semester\laboratornaya_rabota_20\laboratornaya_rabota_20\bin\Debug\points.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);

            if (!int.TryParse(rowSelection.Text, out int index) || index < 1 || index > lines.Length)
            {
                MessageBox.Show("Некорректный номер строки. Убедитесь, что он входит в диапазон.");
                return;
            }

            string line = lines[index - 1];

            Series series = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 1,
                Color = Color.Black
            };

            string[] points = line.Split(';');

            foreach (string point in points)
            {
                string[] coordinates = point.Split(',');

                if (coordinates.Length == 2 &&
                    double.TryParse(coordinates[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) &&
                    double.TryParse(coordinates[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
                {
                    series.Points.AddXY(x, y);
                }
            }
            mainChart.Series.Add(series);
        }
    }
}
