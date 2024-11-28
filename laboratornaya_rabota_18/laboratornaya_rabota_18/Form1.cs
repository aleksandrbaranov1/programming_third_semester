using System;
using System.Windows.Forms;
using System.IO;
using ExcelHelpers;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace laboratornaya_rabota_18
{
    public partial class Form1 : Form
    {
        string[] headers = "класс предмет;вид работы;1;2;3;4;5;6;7;8;9;10;11".Split(new char[] { ';' });
        string dataCsvPath = @"C:\Users\sabba\source\repos\laboratornaya_rabota_18\laboratornaya_rabota_18\bin\Debug\dataCsv.csv.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void preview_Click(object sender, EventArgs e)
        {
            foreach (string header in headers)
            {
                dataGridView1.Columns.Add(header, header); 
            }
            if (!File.Exists(dataCsvPath))
            {
                MessageBox.Show("Файл не найден: " + dataCsvPath);
                return;
            }

            using (StreamReader reader = new StreamReader(dataCsvPath))
            {
                for (int i = 0; i < 6; i++)
                {
                    string line = reader.ReadLine();
                    //MessageBox.Show(line);
                    string[] row = line.Split(new char[] { ';' });
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void exportIntoExcel_Click(object sender, EventArgs e)
        {
            string dataCsvPath = @"C:\Users\sabba\source\repos\laboratornaya_rabota_18\laboratornaya_rabota_18\bin\Debug\dataCsv.csv.txt";
            Excel.Application app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook wb = app.Workbooks.Add(Missing.Value);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets.Add();
            ws.Activate();

            for(int i = 0; i < 13; i++)
            {
                ws.Cells[1, i + 1 ] = headers[i];
                ws.Cells[1, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Cells[1, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            using(StreamReader reader = new StreamReader(dataCsvPath))
            {
                for (int i = 0; i < 6; i++)
                {
                    string line = reader.ReadLine();
                    string[] row = line.Split(new char[] { ';' });
                    for (int j = 0; j < row.Length; j++)
                    {
                        ws.Cells[i + 2, j + 1 ] = row[j];
                        ws.Cells[i + 2, j + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        ws.Cells[i + 2, j + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    }
                }
            }
            ws.Cells[1, 1] = "класс" + "\n" + "предмет";
            ws.Cells[6, 2] = "контрол." + "\n" + "раб.";
            ws.Cells[1, 1].Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlContinuous;

            app.UserControl = true;
            wb.SaveCopyAs(Application.StartupPath + Name + ".xlsx");
            wb.Close(false);

        }
    }
}
