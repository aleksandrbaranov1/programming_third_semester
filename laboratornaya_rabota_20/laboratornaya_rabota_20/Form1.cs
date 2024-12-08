using System;
using System.Drawing;
using System.Globalization; // Для использования CultureInfo
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace laboratornaya_rabota_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем область графика
            ChartArea chartArea = new ChartArea
            {
                AxisX =
                {
                    Title = "(T - T0)°",
                    Minimum = 0,
                    Maximum = 100,
                    Interval = 10 // Уменьшаем шаг между линиями сетки по оси X
                },
                AxisY =
                {
                    Title = "I/I0",
                    Minimum = -10,
                    Maximum = 2,
                    Interval = 0.5 // Уменьшаем шаг между линиями сетки по оси Y
                }
            };

            // Настройка сетки
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas.Add(chartArea);

            // Путь к CSV-файлу
            string path = @"C:\Users\sabba\OneDrive\Рабочий стол\programming_third_semester\programming_third_semester\laboratornaya_rabota_20\laboratornaya_rabota_20\bin\Debug\points.csv";

            // Проверяем, существует ли файл
            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл {path} не найден.");
                return;
            }

            // Читаем строки из CSV-файла
            string[] lines = File.ReadAllLines(path);

            // Перебираем строки, чтобы отрисовать линии
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Создаем новую серию для каждой линии
                Series series = new Series
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 1,
                    Color = Color.Black
                };

                // Разбиваем строку на точки
                string[] points = line.Split(';');

                foreach (string point in points)
                {
                    // Разделяем координаты x и y
                    string[] coordinates = point.Split(',');

                    if (coordinates.Length == 2 &&
                        double.TryParse(coordinates[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) &&
                        double.TryParse(coordinates[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
                    {
                        // Добавляем точку в серию
                        series.Points.AddXY(x, y);
                    }
                }

                // Добавляем серию на график
                chart1.Series.Add(series);
            }

            // Делаем кнопку недоступной после построения
            (sender as Button).Enabled = false;
        }
    }
}
