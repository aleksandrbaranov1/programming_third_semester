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

            for (int i = 1; i <= 21; i++)
            {
                lineSelector.Items.Add(i.ToString());
            }

        }

        private void showAllRows_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            mainChart.Annotations.Clear();

            // Настройка области графика
            ChartArea chartArea = new ChartArea
            {
                AxisY =
                {
                    Minimum = -1,
                    Maximum = 2,
                    Interval = 0.5
                }
            };

            // Визуальная настройка оси X
            chartArea.AxisX.Minimum = 0; // Начало визуальной оси X
            chartArea.AxisX.Maximum = 8; // Количество равных визуальных интервалов
            chartArea.AxisX.Interval = 1;

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            mainChart.ChartAreas.Add(chartArea);

            // Установка пользовательских меток для оси X
            double[] realIntervals = { 0, 20, 30, 40, 50, 60, 70, 80, 90 }; // Настоящие интервалы
            for (int i = 0; i < realIntervals.Length - 1; i++)
            {
                string label = $"{realIntervals[i]}";
                double start = i - 0.5; // Начало диапазона метки
                double end = i + 0.5;   // Конец диапазона метки
                chartArea.AxisX.CustomLabels.Add(start, end, label);
            }

            string path = @"C:\\Users\\sabba\\OneDrive\\Рабочий стол\\programming_third_semester\\programming_third_semester\\Лабораторная работа 20\\laboratornaya_rabota_20\\laboratornaya_rabota_20\\bin\\Debug\\points.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            double[] visualIntervals = { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; // Визуальные интервалы

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
                        // Преобразование X в визуальный интервал
                        double transformedX = TransformToVisualX(x, realIntervals, visualIntervals);
                        series.Points.AddXY(transformedX, y);
                    }
                }
                mainChart.Series.Add(series);
            }
            TextAnnotation textAnnotation = new TextAnnotation
            {
                X = 40,
                Y = 0.5,
                Text = "-1.0",
                ForeColor = Color.Red, // Цвет текста
                Font = new Font("Arial", 10, FontStyle.Bold),
                Alignment = ContentAlignment.MiddleCenter
            };

            // Привязка аннотации к области графика (ChartArea)
            //textAnnotation.AnchorX = 40.0; // Координата X в масштабе графика
            //textAnnotation.AnchorY = 0.1;  // Координата Y в масштабе графика
            //textAnnotation.AxisX = mainChart.ChartAreas[0].AxisX; // Привязка к оси X
            //textAnnotation.AxisY = mainChart.ChartAreas[0].AxisY; // Привязка к оси Y

            // Добавление аннотации на график
            mainChart.Annotations.Add(textAnnotation);
        }

        private void showSelectedRow_Click(object sender, EventArgs e)
        {
            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();

            // Настройка области графика
            ChartArea chartArea = new ChartArea
            {
                AxisY =
            {
                Minimum = -1,
                Maximum = 2,
                Interval = 0.5
            }
            };

            // Визуальная настройка оси X
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 8;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            mainChart.ChartAreas.Add(chartArea);

            // Установка пользовательских меток для оси X
            double[] realIntervals = { 0, 20, 30, 40, 50, 60, 70, 80, 90 }; // Настоящие интервалы
            for (int i = 0; i < realIntervals.Length - 1; i++)
            {
                string label = $"{realIntervals[i]}";
                double start = i - 0.5; // Начало диапазона метки
                double end = i + 0.5;   // Конец диапазона метки
                chartArea.AxisX.CustomLabels.Add(start, end, label);
            }

            string path = @"C:\\Users\\sabba\\OneDrive\\Рабочий стол\\programming_third_semester\\programming_third_semester\\Лабораторная работа 20\\laboratornaya_rabota_20\\laboratornaya_rabota_20\\bin\\Debug\\points.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);

            // Получить выбранный номер из ComboBox
            if (lineSelector.SelectedItem == null || !int.TryParse(lineSelector.SelectedItem.ToString(), out int index) || index < 1 || index > lines.Length)
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

            double[] visualIntervals = { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; // Визуальные интервалы

            string[] points = line.Split(';');

            foreach (string point in points)
            {
                string[] coordinates = point.Split(',');

                if (coordinates.Length == 2 &&
                    double.TryParse(coordinates[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) &&
                    double.TryParse(coordinates[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
                {
                    // Преобразование X в визуальный интервал
                    double transformedX = TransformToVisualX(x, realIntervals, visualIntervals);
                    series.Points.AddXY(transformedX, y);
                }
            }

            mainChart.Series.Add(series);
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
