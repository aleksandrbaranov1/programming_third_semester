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

            for (double i = -1.0; i <= 0.05; i+=0.05)
            {
                lineSelector.Items.Add(Math.Round(i, 2).ToString());
            }

        }

        private void showAllRows_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            mainChart.Annotations.Clear();

        
            ChartArea chartArea = new ChartArea
            {
                AxisY =
                {
                    Minimum = -1,
                    Maximum = 2,
                    Interval = 0.5
                }
            };

           
            chartArea.AxisX.Minimum = 0; 
            chartArea.AxisX.Maximum = 8;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            mainChart.ChartAreas.Add(chartArea);

          
            double[] realIntervals = { 0, 20, 30, 40, 50, 60, 70, 80, 90 };
            for (int i = 0; i < realIntervals.Length - 1; i++)
            {
                string label = $"{realIntervals[i]}";
                double start = i - 0.5; 
                double end = i + 0.5;  
                chartArea.AxisX.CustomLabels.Add(start, end, label);
            }

            string path = @"C:\\Users\\sabba\\OneDrive\\Рабочий стол\\programming_third_semester\\programming_third_semester\\Лабораторная работа 20\\laboratornaya_rabota_20\\laboratornaya_rabota_20\\bin\\Debug\\points.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            double[] visualIntervals = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            double seriesNumber = -1.0;

            foreach (string line in lines)
            {
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
                       
                        double transformedX = TransformToVisualX(x, realIntervals, visualIntervals);
                        series.Points.AddXY(transformedX, y);
                    }
                }
                mainChart.Series.Add(series);
                DataPoint thirdPoint = series.Points[2]; 
                TextAnnotation annotation = new TextAnnotation
                {
                    Text = $"{Math.Round(seriesNumber, 2)}",
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 6),
                    AnchorDataPoint = thirdPoint, 
                    Y = thirdPoint.YValues[0] + 0.1 
                };

                mainChart.Annotations.Add(annotation);

                seriesNumber+=0.05; 
            }
           
        }

        private void showSelectedRow_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            mainChart.Annotations.Clear();

            ChartArea chartArea = new ChartArea
            {
                AxisY =
            {
                Minimum = -1,
                Maximum = 2,
                Interval = 0.5
            }
            };

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 8;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            mainChart.ChartAreas.Add(chartArea);

         
            double[] realIntervals = { 0, 20, 30, 40, 50, 60, 70, 80, 90 }; 
            for (int i = 0; i < realIntervals.Length - 1; i++)
            {
                string label = $"{realIntervals[i]}";
                double start = i - 0.5; 
                double end = i + 0.5;  
                chartArea.AxisX.CustomLabels.Add(start, end, label);
            }

            string path = @"C:\\Users\\sabba\\OneDrive\\Рабочий стол\\programming_third_semester\\programming_third_semester\\Лабораторная работа 20\\laboratornaya_rabota_20\\laboratornaya_rabota_20\\bin\\Debug\\points.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);

            int index = lineSelector.SelectedIndex;
            string line = lines[index];
            Series series = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 1,
                Color = Color.Black
            };

            double[] visualIntervals = { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; 
            string[] points = line.Split(';');

            foreach (string point in points)
            {
                string[] coordinates = point.Split(',');

                if (coordinates.Length == 2 &&
                    double.TryParse(coordinates[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) &&
                    double.TryParse(coordinates[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
                {
                   
                    double transformedX = TransformToVisualX(x, realIntervals, visualIntervals);
                    series.Points.AddXY(transformedX, y);
                }
            }
            
            mainChart.Series.Add(series);
            DataPoint thirdPoint = series.Points[2];
            TextAnnotation annotation = new TextAnnotation
            {
                Text = lineSelector.Items[lineSelector.SelectedIndex].ToString(),
                ForeColor = Color.Red,
                Font = new Font("Arial", 6),
                AnchorDataPoint = thirdPoint,
                Y = thirdPoint.YValues[0] + 0.1
            };

            mainChart.Annotations.Add(annotation);
        }


        private double TransformToVisualX(double x, double[] realIntervals, double[] visualIntervals)
        {
            for (int i = 0; i < realIntervals.Length - 1; i++)
            {
                if (x >= realIntervals[i] && x < realIntervals[i + 1])
                {
                    double realRange = realIntervals[i + 1] - realIntervals[i];
                    double visualRange = visualIntervals[i + 1] - visualIntervals[i];
                    return visualIntervals[i] + (x - realIntervals[i]) / realRange * visualRange;
                }
            }
            return visualIntervals[visualIntervals.Length - 1];
        }
    }
}
