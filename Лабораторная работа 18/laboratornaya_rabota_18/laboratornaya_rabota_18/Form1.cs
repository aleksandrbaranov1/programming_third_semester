using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelHelpers;

namespace laboratornaya_rabota_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void preview_Click(object sender, EventArgs e)
        {
            string[] headers = "класс предмет;вид работы;1;2;3;4;5;6;7;8;9;10;11".Split(new char[] { ';' });
            string dataCsvPath = @"C:\Users\sabba\OneDrive\Рабочий стол\programming_third_semester\programming_third_semester\laboratornaya_rabota_18\laboratornaya_rabota_18\bin\Debug\dataCsv.csv.txt";
            foreach (string header in headers)
            {
                dataGridView1.Columns.Add(header, header);
            }

            StreamReader reader = new StreamReader(dataCsvPath);
            for (int i = 0; i < 6; i++)
            {
                string line = reader.ReadLine();
                string[] row = line.Split(new char[] { ';' });
                dataGridView1.Rows.Add(row);
            }
            reader.Close();
        }

        private void exportIntoExcel_Click(object sender, EventArgs e)
        {
            string[] headers = "класс предмет;вид работы;1;2;3;4;5;6;7;8;9;10;11".Split(new char[] { ';' });
            string dataCsvPath = @"C:\Users\sabba\OneDrive\Рабочий стол\programming_third_semester\programming_third_semester\laboratornaya_rabota_18\laboratornaya_rabota_18\bin\Debug\dataCsv.csv.txt";
            Excel.Application app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook wb = app.Workbooks.Add(Missing.Value);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets.Add();
            ws.Activate();

            for (int i = 0; i < 13; i++)
            {
                ws.Cells[1, i + 1] = headers[i];
                ws.Cells[1, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Cells[1, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            StreamReader reader = new StreamReader(dataCsvPath);
            for (int i = 0; i < 6; i++)
            {
                string line = reader.ReadLine();
                string[] row = line.Split(new char[] { ';' });
                for (int j = 0; j < row.Length; j++)
                {
                    ws.Cells[i + 2, j + 1] = row[j];
                    ws.Cells[i + 2, j + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws.Cells[i + 2, j + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
            }
            reader.Close();
           
            ws.Cells[1, 1] = "класс" + "\n" + "предмет";
            ws.Cells[6, 2] = "контрол." + "\n" + "раб.";
            ws.Cells[1, 1].Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlContinuous;
            ws.Range[ExcelMethods.ExcelCellTranslator(2, 1), ExcelMethods.ExcelCellTranslator(6, 1)].Merge();
            ws.Range[ExcelMethods.ExcelCellTranslator(2, 1), ExcelMethods.ExcelCellTranslator(6, 1)].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            ws.Columns[1].ColumnWidth = 30;
            ws.Columns[2].ColumnWidth = 20;
            ws.Range[ExcelMethods.ExcelCellTranslator(1, 1), ExcelMethods.ExcelCellTranslator(7, 13)].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            app.UserControl = true;
            wb.SaveCopyAs(Application.StartupPath + Name + ".xlsx");
            wb.Close(false);

        }
    }
}

