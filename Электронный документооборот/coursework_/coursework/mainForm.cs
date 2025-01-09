using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelHelpers;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace coursework
{
    public partial class mainForm : Form
    {
        string pathToCSV = Path.GetFullPath("exportData.csv");
        string pathToChartData = Path.GetFullPath("chartData.csv");
        string fileName;
        string documentsFolderPath = Path.GetFullPath("Documents");
        string[] chartModes =
        {
            "1. Показать столбчатую диаграмму количества докладов за всё время только тех авторов," +
                " которые указали в названии слово",
            "2. Показать столбчатую диаграмму количества докладов за указанный период только тех авторов," +
                " которые указали в названии слово",
            "3. Показать столбчатую диаграмму распределения докладов по секциям за всё время",
            "4. Показать столбчатую диаграмму распределения заявок по секциям за всё время",
            "5. Показать столбчатую диаграмму распределения докладов по секциям за указанный период",
            "6. Показать столбчатую диаграмму распределения заявок по секциям за указанный период",
            "7. Показать столбчатую диаграмму количества уникальных авторов докладов в указанном году",
            "8. Показать столбчатую диаграмму количества докладов только от не уникальных авторов за весь период",
            "9. Показать столбчатую диаграмму количества докладов, составленных в соавторстве," +
                " приходящихся на каждый календарный год всего периода",
            "10. Показать столбчатую диаграмму количества заявок за всё время, приходящихся на различные должности авторов-докладчиков",
            "11. Показать столбчатую диаграмму количества заявок, " +
                "поданных студентами за указанный календарный год, с распределением их по учебным группам",
            "12. Показать столбчатую диаграмму количества заявок, приходящихся на каждый календарный год всего периода," +
                " в которых наименования доклада и статьи в точности совпадают",
            "13. Показать столбчатую диаграмму количества докладов," +
                " завленных за весь рассматриваемый период от коллективов из 2-х, 3-х, 4-х, 5-ти соавторов",
            "14. Показать столбчатую диаграмму количества заявок, приходящихся на конференцию за весь рассматриваемый период"
        };
        
        public mainForm()
        {
            InitializeComponent();
            selectingChartMode.Items.AddRange(chartModes);
        }
        private static void SetParagraphText(Word.Paragraph paragraph, string text, int fontSize, string font, string alignment, int bold)
        {
            paragraph.Range.Text = text;
            paragraph.Range.Font.Size = fontSize;
            paragraph.Range.Font.Name = font;
            switch (alignment)
            {
                case "Right":
                    paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    break;
                case "Left":
                    paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    break;
                case "Center":
                    paragraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                default:
                    break;
            }
            paragraph.Range.Font.Bold = bold;
            paragraph.Range.InsertParagraphAfter();
        }
        private void fileSelectionBtn_Click(object sender, EventArgs e)
        {
          
            if (documentSelection.ShowDialog() == DialogResult.OK)
            {
                fileName = documentSelection.FileName;
            }
        }

        private void exportCSVToWord_Click(object sender, EventArgs e)
        {
            Word.Document oDoc;
            Word.Paragraph oPr;
            Word.Application oWord = new Word.Application();
            oDoc = oWord.Documents.Add();
            oPr = oDoc.Paragraphs.Add();
            Word.Range range = oDoc.Content;

            string[] lines = File.ReadAllLines(pathToCSV);
            int index = 0;
            for (int i = 0; i <= lines.Length; i++)
            {
                SetParagraphText(oPr, lines[i], 14, "Times new roman", "Center", 1);
                oPr.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;

                if (lines[i] == "")
                {
                    oPr.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
                    break;
                }
            }
            Word.Paragraph emptyParagraph = oDoc.Paragraphs.Add();
            emptyParagraph.Range.Text = ""; 
            Word.Table table = oDoc.Tables.Add(emptyParagraph.Range, 10, 2);

            int idexOfEmptyString = Array.IndexOf(lines, "");

            string[] tableData = lines.Skip(idexOfEmptyString + 1).ToArray();
            
            for(int i = 0; i < 10; i++)
            {
                string[] row = tableData[i].Split(';');
                
                for(int j = 1; j <= 2; j++)
                {
                    table.Cell(i + 1, j).Range.Text = row[j - 1];
                    if(j == 1)
                    {
                        table.Cell(i + 1, j).Range.Font.Size = 14;
                        table.Cell(i + 1, j).Range.Font.Bold = 0;
                        table.Cell(i + 1, j).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        table.Cell(i + 1, j).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                    else
                    {
                        table.Cell(i + 1, j).Range.Font.Size = 12;
                        table.Cell(i + 1, j).Range.Font.Bold = 1;
                        table.Cell(i + 1, j).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
                        table.Cell(i + 1, j).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                }
            }
            foreach(Word.Cell cell in table.Range.Cells)
            {
                cell.Borders.Enable = 1;
            }
            oDoc.SaveAs2(System.Windows.Forms.Application.StartupPath + "\\Импортированный Word-документ.docx");
            oWord.Quit();
            MessageBox.Show("Экспорт в Word-документ из CSV выполнен");
        }

        private void importIntoCSV_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                MessageBox.Show("Выберите файл!");
            }
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Word.Document oDoc = oWord.Documents.Open(fileName, ReadOnly:true);

            StreamWriter writer = new StreamWriter(pathToCSV, append: false, Encoding.UTF8);


            Word.Table table = oDoc.Tables[1];
            foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
            {
                if (paragraph.Range.Tables.Count > 0)
                {
                    for (int i = 1; i <= table.Rows.Count; i++)
                    {
                        List<string> rowData = new List<string>();
                        for (int j = 1; j <= table.Columns.Count; j++)
                        {
                            string cellText = table.Cell(i, j).Range.Text
                        .Replace("\r", "")
                        .Replace("\n", "")
                        .TrimEnd('\r', '\a')
                        .Trim();
                            rowData.Add(cellText.Trim());
                        }
                        writer.WriteLine(string.Join(";", rowData));
                    }
                    break;
                }
                else
                {
                    string paragraphText = paragraph.Range.Text.Trim();
                    writer.WriteLine(paragraphText);
                }
            }
            writer.Close();
            MessageBox.Show("Импорт в CSV выполнен");
            oDoc.Close();
        }

        private void exportCSVToExcel_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook wb = app.Workbooks.Add(Missing.Value);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets.Add();
            ws.Activate();

          
            ws.Range[ExcelMethods.ExcelCellTranslator(1, 1), ExcelMethods.ExcelCellTranslator(2, 2)].Merge();
            ws.Rows[2].RowHeight = 75;
            ws.Columns[1].ColumnWidth = 35;
            ws.Columns[2].ColumnWidth = 35;

            for(int i = 2; i <= 12; i++)
            {
                ws.Rows[i].RowHeight = 90;
            }
            ws.Range[ExcelMethods.ExcelCellTranslator(3, 1), ExcelMethods.ExcelCellTranslator(12, 2)].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            string[] lines = File.ReadAllLines(pathToCSV);
            string[] header = lines.Take(Array.IndexOf(lines, "")).ToArray();

            ws.Cells[1, 1] = string.Join("\n", header);

            int idexOfEmptyString = Array.IndexOf(lines, "");
            string[] tableData = lines.Skip(idexOfEmptyString + 1).ToArray();

            for (int i = 3 ; i <= 12; i++)
            {
                string[] row = tableData[i - 3].Split(';');
                for (int j = 1; j <= 2; j++)
                {
                    ws.Cells[i, j] = row[j - 1];
                    ws.Cells[i, j].WrapText = true;

                    if(j == 1)
                    {
                        ws.Cells[i, j].Font.Name = "Times new roman";
                        ws.Cells[i, j].Font.Size = 14;
                        ws.Cells[i, j].Font.Bold = 0;
                        ws.Cells[i, j].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        ws.Cells[i, j].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }
                    else
                    {
                        ws.Cells[i, j].Font.Name = "Times new roman";
                        ws.Cells[i, j].Font.Size = 12;
                        ws.Cells[i, j].Font.Bold = 1;
                        ws.Cells[i, j].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        ws.Cells[i, j].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                    }
                }
            }
            ws.Cells[1, 1].Font.Name = "Times new roman";
            ws.Cells[1, 1].Font.Size = 14;
            ws.Cells[1, 1].Font.Bold = 1;
            ws.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


            app.UserControl = true;
            wb.SaveCopyAs(System.Windows.Forms.Application.StartupPath + "\\Импортированный Excel-документ.xls");
            wb.Close(false);
            MessageBox.Show("Экспорт в Excel-документ из CSV выполнен");
        }
        private void numberOfReportsForAllTime()
        {

            string parameter = parameterFilter.Text.Trim();
            if(string.IsNullOrEmpty(parameter))
            {
                MessageBox.Show("Введите парамер диаграммы!");
                return;
            }
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> fioCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }
                    string cellText = table.Cell(1, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    string[] words = cellText.Split(' ');
                    if (words[2].Contains('('))
                    {
                        words[2] = words[2].Substring(0, words[2].IndexOf('('));
                    }
                   
                    string fio = $"{words[0]} {words[1]} {words[2]}";
                    if (table.Cell(7, 2).Range.Text.Contains(parameter))
                    {
                        if (fioCounts.ContainsKey(fio))
                        {
                            fioCounts[fio]++;
                        }
                        else
                        {
                            fioCounts[fio] = 1;
                        }
                    }
                    titleOfReports.Add(titleOfReport);
                }
                catch(System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using(StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in fioCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "ФИО",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество статьей",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column, 
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach(string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void numberOfReportsForTheSpecifiedPeriod()
        {
            
            string parameter = parameterFilter.Text.Trim();
            if (string.IsNullOrEmpty(parameter))
            {
                MessageBox.Show("Введите парамер диаграммы!");
                return;
            }

            string period = periodFilter.Text.Trim();
            if (string.IsNullOrEmpty(period))
            {
                MessageBox.Show("Введите период!");
                return;
            }

            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> fioCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);

                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }

                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }
                    string cellText = table.Cell(1, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    string[] words = cellText.Split(' ');
                    if (words[2].Contains('('))
                    {
                        words[2] = words[2].Substring(0, words[2].IndexOf('('));
                    }

                    string fio = $"{words[0]} {words[1]} {words[2]}";
                    if (table.Cell(7, 2).Range.Text.Contains(parameter) && header.Contains(period))
                    {
                        if (fioCounts.ContainsKey(fio))
                        {
                            fioCounts[fio]++;
                        }
                        else
                        {
                            fioCounts[fio] = 1;
                        }
                    }
                    titleOfReports.Add(titleOfReport);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in fioCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "ФИО",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество статьей",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void distributionOfReportsBySectionForAllTime()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> sectionCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    

                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }
                    string sectionText = table.Cell(8, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();

                    string[] words = sectionText.Split(' ');
                    string section = $"{words[0]} {words[1]}";
                    if (sectionCounts.ContainsKey(section))
                    {
                        sectionCounts[section]++;
                        
                    }
                    else
                    {
                        sectionCounts[section] = 1;
                    }
                    titleOfReports.Add(titleOfReport);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }
            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in sectionCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Секция",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество докладов",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void distributionOfApplicationsBySectionsForAllTime()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> sectionCounts = new Dictionary<string, int>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    string cellText = table.Cell(8, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    string[] words = cellText.Split(' ');
                    string section = $"{words[0]} {words[1]}";

                    if (sectionCounts.ContainsKey(section))
                    {
                        sectionCounts[section]++;
                    }
                    else
                    {
                        sectionCounts[section] = 0;
                    }

                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in sectionCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Секция",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество докладов",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void distributionOfReportsBySectionsForTheSpecifiedPeriod()
        {
            string period = periodFilter.Text.Trim();
            if (string.IsNullOrEmpty(period))
            {
                MessageBox.Show("Введите период!");
                return;
            }
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> sectionCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if(paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }
                    
                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }
                    string sectionText = table.Cell(8, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    string[] words = sectionText.Split(' ');
                    string section = $"{words[0]} {words[1]}";
                    if (header.Contains(period))
                    {
                        if (sectionCounts.ContainsKey(section))
                        {
                            sectionCounts[section]++;
                        }
                        else
                        {
                            sectionCounts[section] = 1;
                        }
                    }
                    titleOfReports.Add(titleOfReport);

                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in sectionCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Секция",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество докладов",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void distributionOfApplicationsBySectionsForTheSpecifiedPeriod()
        {
            string period = periodFilter.Text.Trim();
            if (string.IsNullOrEmpty(period))
            {
                MessageBox.Show("Введите период!");
                return;
            }
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> sectionCounts = new Dictionary<string, int>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }

                    Word.Table table = oDoc.Tables[1];
                    string cellText = table.Cell(8, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    string[] words = cellText.Split(' ');
                    string section = $"{words[0]} {words[1]}";
                    if (header.Contains(period))
                    {
                        if (sectionCounts.ContainsKey(section))
                        {
                            sectionCounts[section]++;
                        }
                        else
                        {
                            sectionCounts[section] = 1;
                        }
                    }

                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in sectionCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Секция",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество докладов",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void numberOfUniqueAuthorsOfReportsInAGivenYear()
        {
           
            string year = periodFilter.Text.Trim();
            if (string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Введите год в поле 'Период'!");
                return;
            }

            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> fioCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);

                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }

                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }
                    string cellText = table.Cell(1, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    string[] words = cellText.Split(' ');
                    if (words[2].Contains('('))
                    {
                        words[2] = words[2].Substring(0, words[2].IndexOf('('));
                    }

                    string fio = $"{words[0]} {words[1]} {words[2]}";
                    if (header.Contains(year))
                    {
                        if (fioCounts.ContainsKey(fio))
                        {
                            fioCounts[fio]++;
                        }
                        else
                        {
                            fioCounts[fio] = 1;
                        }
                    }
                    titleOfReports.Add(titleOfReport);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in fioCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "ФИО",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество статьей",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                if (coordinates[1] == "1")
                    series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void numberOfReportsOnlyFromNonUniqueAuthorsForAllTime()
        {
            
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> fioCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();


                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }

                    string cellText = table.Cell(1, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    string[] words = cellText.Split(' ');
                    if (words[2].Contains('('))
                    {
                        words[2] = words[2].Substring(0, words[2].IndexOf('('));
                    }

                    string fio = $"{words[0]} {words[1]} {words[2]}";
                    if (fioCounts.ContainsKey(fio))
                    {
                        fioCounts[fio]++;
                    }
                    else
                    {
                        fioCounts[fio] = 1;
                    }
                    titleOfReports.Add(titleOfReport);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in fioCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "ФИО",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество статьей",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                if (coordinates[1] != "1")
                    series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void numberOfCoAuthoredReportsPerYear()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> yearCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    string authorText = table.Cell(1, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    MessageBox.Show(authorText);
                    string[] author = authorText.Split(' ');
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();

                    if (titleOfReports.Contains(titleOfReport))
                    {
                        continue;
                    }
                    
                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }
                    string[] words = header.Trim().Split(' ');
                    
                    string year = words[words.Length - 2];
                    if (authorText.Contains('('))
                    {
                        if (yearCounts.ContainsKey(year))
                        {
                            yearCounts[year]++;
                        }
                        else
                        {
                            yearCounts[year] = 1;
                        }
                        titleOfReports.Add(titleOfReport);
                    }
                    
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in yearCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Год",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество статьей",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void numberOfApplicationsOverTheEntirePeriodForVariousPositionsOfAuthorSpeakers()
        {
            
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> positionCounts = new Dictionary<string, int>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                  

                    Word.Table table = oDoc.Tables[1];
                    string position = table.Cell(2, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    
                     
                     
                    if(position.Contains("-, -, студент") || position.Contains("обучающийся"))
                    {
                        position = "Студент";
                    }
                    if (position.Contains("Магистрант"))
                    {
                        position = "Магистрант";

                    }

                    position = position.Replace("-, -, ", "");
                    if (positionCounts.ContainsKey(position))
                    {
                        positionCounts[position]++;
                    }
                    else
                    {
                        positionCounts[position] = 1;
                    }
                    

                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in positionCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Должность",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество заявок",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void getStudentApplicationsByYearAndGroup()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> groupCounts = new Dictionary<string, int>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    
                    if((table.Cell(2, 2).Range.Text.Contains("-, -, студент") || table.Cell(2, 2).Range.Text.Contains("обучающийся, ")) || table.Cell(2, 2).Range.Text.Contains("Магистрант, "))
                    {
                        
                    }
                    else
                    {
                        continue;
                    }
                     
                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }
                    string[] words = header.Trim().Split(' ');
                    string year = words[words.Length - 2];
                    //MessageBox.Show(year);
                    if (year != periodFilter.Text)
                    {
                        continue;
                    }
                    
                    string group;
                    string inputGroup = table.Cell(2, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    if(inputGroup.Contains('('))
                    {
                        int startIndex = inputGroup.IndexOf('(') + 5; 
                        int endIndex = inputGroup.IndexOf(')') - 1;   
                        group = inputGroup.Substring(startIndex, endIndex - startIndex + 1); 
                    }
                    else 
                    {
                        group = inputGroup.Split(',')[inputGroup.Split(',').Length - 1].Trim();
                    }

                    if (groupCounts.ContainsKey(group))
                    {
                        groupCounts[group]++;
                    }
                    else
                    {
                        groupCounts[group] = 1;
                    }


                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }
            if(groupCounts.Count == 0)
            {
                MessageBox.Show($"Данных за {periodFilter.Text} год не найдено!");
                return;
            }
            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in groupCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Группы",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество заявок студентов",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void showMatchingReportsPerYearChart()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> yearCounts = new Dictionary<string, int>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];

                    string topicOfTheArticle = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();

                    string topicOfTheReport = table.Cell(10, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    
                    if(topicOfTheArticle != topicOfTheReport)
                    {
                        continue;
                    }
                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }
                    string[] words = header.Trim().Split(' ');
                    string year = words[words.Length - 2];


                    if (yearCounts.ContainsKey(year))
                    {
                        yearCounts[year]++;
                    }
                    else
                    {
                        yearCounts[year] = 1;
                    }


                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }
            
            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in yearCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Год",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество заявок",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void showCoauthorReportDistribution()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> сoAuthorsCounts = new Dictionary<string, int>();
            List<string> titleOfReports = new List<string>();
            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];
                    string titleOfReport = table.Cell(7, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();

                    string author = table.Cell(1, 2).Range.Text
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .TrimEnd('\r', '\a')
                                .Trim();
                    if (titleOfReports.Contains(titleOfReport) || author.Split(' ').Length == 3)
                    {
                        continue;
                    }
                    MessageBox.Show(author);

                    int startIndex = author.IndexOf('(') + 1;
                    int endIndex = author.IndexOf(')') - 1;
                    author = author.Substring(startIndex, endIndex - startIndex);
                    author = author.Replace("статья в соавторстве с ", "");
                    string numberOfCoAuthors;

                    if(author.Contains(" и "))
                    {
                        numberOfCoAuthors = "Коллектив из 3-x соавторов";
                    }
                    else if (author.Contains(", "))
                    {
                        numberOfCoAuthors =  $"Коллектив из {author.Split(',').Length + 1} соавторов";
                    }
                    else
                    {
                        numberOfCoAuthors = "Коллектив из 2-х соавторов";
                    }

                    if (сoAuthorsCounts.ContainsKey(numberOfCoAuthors))
                    {
                        сoAuthorsCounts[numberOfCoAuthors]++;
                    }
                    else
                    {
                        сoAuthorsCounts[numberOfCoAuthors] = 1;
                    }
                    
                    titleOfReports.Add(titleOfReport);

                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in сoAuthorsCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Коллектив",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество докладов",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Статьи"
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void showConferenceApplicationStatistics()
        {
            string[] wordFiles = Directory.GetFiles(documentsFolderPath, "*.docx");
            Word.Application oWord = new Word.Application();
            oWord.Visible = false;
            Dictionary<string, int> conferenceCounts = new Dictionary<string, int>();

            foreach (string pathToDoc in wordFiles)
            {
                try
                {
                    Word.Document oDoc = oWord.Documents.Open(pathToDoc, ReadOnly: true);
                    Word.Table table = oDoc.Tables[1];

                    string header = "";
                    foreach (Word.Paragraph paragraph in oDoc.Paragraphs)
                    {
                        if (paragraph.Range.Tables.Count > 0)
                        {
                            break;
                        }
                        header += paragraph.Range.Text + " ";
                    }
                    string conference;
                    if (header.Contains("2022"))
                    {
                        conference = "Международная научно-практическая конференция";
                    }
                    else if (header.Contains("2023"))
                    {
                        conference = "II Международная научно-практическая конференция";
                    }
                    else
                    {
                        conference = "III Международная научно-практическая конференция";
                    }

                    if (conferenceCounts.ContainsKey(conference))
                    {
                        conferenceCounts[conference]++;
                    }
                    else
                    {
                        conferenceCounts[conference] = 1;
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show($"Файл {pathToDoc} поврежден или недоступен. Пропускаем.");
                }

            }

            using (StreamWriter writer = new StreamWriter(pathToChartData))
            {
                foreach (var entry in conferenceCounts)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value}");
                }
            }
            oWord.Quit();

            mainChart.Series.Clear();
            mainChart.ChartAreas.Clear();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX =
                {
                    Title = "Конференция",
                    Interval = 1
                },
                AxisY =
                {
                    Title = "Количество заявок",
                    Minimum = 0,
                    Interval = 1
                }
            };
            mainChart.ChartAreas.Add(chartArea);
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                ChartType = SeriesChartType.Column,
               
            };


            string[] lines = File.ReadAllLines(pathToChartData);
            foreach (string line in lines)
            {
                string[] coordinates = line.Split(';');
                series.Points.AddXY(coordinates[0], coordinates[1]);
            }
            mainChart.Series.Add(series);
        }
        private void showDiagram_Click(object sender, EventArgs e)
        {
            if(selectingChartMode.SelectedItem == null)
            {
                MessageBox.Show("Выберите диаграмму!");
                return;
            }

            switch (selectingChartMode.SelectedItem.ToString())
            {
                case "1. Показать столбчатую диаграмму количества докладов за всё время только тех авторов," +
                " которые указали в названии слово":
                    numberOfReportsForAllTime();
                    break;
                case "2. Показать столбчатую диаграмму количества докладов за указанный период только тех авторов," +
                " которые указали в названии слово":
                    numberOfReportsForTheSpecifiedPeriod();
                    break;
                case "3. Показать столбчатую диаграмму распределения докладов по секциям за всё время":
                    distributionOfReportsBySectionForAllTime();
                    break;
                case "4. Показать столбчатую диаграмму распределения заявок по секциям за всё время":
                    distributionOfApplicationsBySectionsForAllTime();
                    break;
                case "5. Показать столбчатую диаграмму распределения докладов по секциям за указанный период":
                    distributionOfReportsBySectionsForTheSpecifiedPeriod();
                    break;
                case "6. Показать столбчатую диаграмму распределения заявок по секциям за указанный период":
                    distributionOfApplicationsBySectionsForTheSpecifiedPeriod();
                    break;
                case "7. Показать столбчатую диаграмму количества уникальных авторов докладов в указанном году":
                    numberOfUniqueAuthorsOfReportsInAGivenYear();
                    break;
                case "8. Показать столбчатую диаграмму количества докладов только от не уникальных авторов за весь период":
                    numberOfReportsOnlyFromNonUniqueAuthorsForAllTime();
                    break;
                case "9. Показать столбчатую диаграмму количества докладов, составленных в соавторстве," +
                " приходящихся на каждый календарный год всего периода":
                    numberOfCoAuthoredReportsPerYear();
                    break;
                case "10. Показать столбчатую диаграмму количества заявок за всё время, приходящихся на различные должности авторов-докладчиков":
                    numberOfApplicationsOverTheEntirePeriodForVariousPositionsOfAuthorSpeakers();
                    break;
                case "11. Показать столбчатую диаграмму количества заявок, " +
                "поданных студентами за указанный календарный год, с распределением их по учебным группам":
                    getStudentApplicationsByYearAndGroup();
                    break;
                case "12. Показать столбчатую диаграмму количества заявок, приходящихся на каждый календарный год всего периода," +
                " в которых наименования доклада и статьи в точности совпадают":
                    showMatchingReportsPerYearChart();
                    break;
                case "13. Показать столбчатую диаграмму количества докладов," +
                " завленных за весь рассматриваемый период от коллективов из 2-х, 3-х, 4-х, 5-ти соавторов":
                    showCoauthorReportDistribution();
                    break;
                case "14. Показать столбчатую диаграмму количества заявок, приходящихся на конференцию за весь рассматриваемый период":
                    showConferenceApplicationStatistics();
                    break;
                default:
                    break;
            }

        }

        private void selectingChartMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (selectingChartMode.SelectedItem.ToString())
            {
                case "1. Показать столбчатую диаграмму количества докладов за всё время только тех авторов," +
                " которые указали в названии слово":
                    parameterFilter.Enabled = true;
                    periodFilter.Enabled = false;
                    break;
                case "2. Показать столбчатую диаграмму количества докладов за указанный период только тех авторов," +
                " которые указали в названии слово":
                    periodFilter.Enabled = true;
                    parameterFilter.Enabled = true;
                    break;
                case "3. Показать столбчатую диаграмму распределения докладов по секциям за всё время":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "4. Показать столбчатую диаграмму распределения заявок по секциям за всё время":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "5. Показать столбчатую диаграмму распределения докладов по секциям за указанный период":
                    periodFilter.Enabled = true;
                    parameterFilter.Enabled = false;
                    break;
                case "6. Показать столбчатую диаграмму распределения заявок по секциям за указанный период":
                    periodFilter.Enabled = true;
                    parameterFilter.Enabled = false;
                    break;
                case "7. Показать столбчатую диаграмму количества уникальных авторов докладов в указанном году":
                    periodFilter.Enabled = true;
                    parameterFilter.Enabled = false;
                    break;
                case "8. Показывать столбчатую диаграмму количества докладов только от не уникальных авторов за весь период":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "9. Показать столбчатую диаграмму количества докладов, составленных в соавторстве," +
                " приходящихся на каждый календарный год всего периода":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "10. Показать столбчатую диаграмму количества заявок за всё время, приходящихся на различные должности авторов-докладчиков":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "11. Показать столбчатую диаграмму количества заявок, " +
                "поданных студентами за указанный календарный год, с распределением их по учебным группам":
                    periodFilter.Enabled = true;
                    parameterFilter.Enabled = false;
                    break;
                case "12. Показать столбчатую диаграмму количества заявок, приходящихся на каждый календарный год всего периода," +
                " в которых наименования доклада и статьи в точности совпадают":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "13. Показать столбчатую диаграмму количества докладов," +
                " завленных за весь рассматриваемый период от коллективов из 2-х, 3-х, 4-х, 5-ти соавторов":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                case "14. Показать столбчатую диаграмму количества заявок, приходящихся на конференцию за весь рассматриваемый период":
                    periodFilter.Enabled = false;
                    parameterFilter.Enabled = false;
                    break;
                default :
                    break;
            }
        }
    }
}
