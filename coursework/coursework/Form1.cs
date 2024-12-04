using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace coursework
{
    public partial class Form1 : Form
    {
        private string[] documents = { "20201001_Нагрузка_I", "20201001_Нагрузка_II", "20210514_Нагрузка_I",
        "20210514_Нагрузка_II", "20221007_Нагрузка_I", "20221007_Нагрузка_II", "20230428_Нагрузка_I", "20230428_Нагрузка_II"};
        public Form1()
        {
            InitializeComponent();
            selectionDocument.Items.AddRange(documents);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private static string ConvertCellToString(Word.Cell cell)
        {
            
            string cellText = cell.Range.Text.Trim();
            cellText = cellText.Trim('\r', '\a'); 
            cellText = cellText.Replace("\n", " ").Replace("\r", " ");
            return cellText;
        }
        private static (int, int) getMaxRowsAndColumns(Table table)
        {
            int maxRowCount = 0;
            int maxColumnCount = 0;

            
            foreach(Row row in table.Rows)
            {
                int currentRowCellCount = row.Cells.Count;
                if (currentRowCellCount > maxColumnCount)
                {
                    maxColumnCount = currentRowCellCount;
                }
            }
            maxRowCount = table.Rows.Count;

            return (maxRowCount, maxColumnCount);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 progressForm = new Form2();
            progressForm.Show();

            //MessageBox.Show("Дождитесь уонца считывания данных");

            string path =  $@"C:\Users\sabba\source\repos\coursework\coursework\bin\Debug\Documents\{selectionDocument.Text}.docx";
            string pathToData = $@"C:\Users\sabba\source\repos\coursework\coursework\bin\Debug\data.csv.txt";

            Word.Document oDoc;
            Word.Paragraph oPr;
            Word.Application oWord = new Word.Application();
            oDoc = oWord.Documents.Open(path);
            oPr = oDoc.Paragraphs.Add();
            StreamWriter writer = new StreamWriter(pathToData);
            for (int t = 1; t <= oDoc.Tables.Count; t++)
            {
                Table table = oDoc.Tables[t];
                
                var (row, col) = getMaxRowsAndColumns(table);
                for (int i = 1; i <= row; i++)
                {
                    string rowData = "";
                    for (int j = 1; j <= table.Rows[i].Cells.Count; j++)
                    {
                        try
                        {
                            string cellText = ConvertCellToString(table.Cell(i, j));
                            rowData += cellText + (j == table.Rows[i].Cells.Count ? "" : ";");
                        }
                        catch
                        {

                        }
                    }
                    //writer.WriteLine(rowData);
                    //progressBar1.PerformStep();
                    int progressPercentage = (i * 100) / row;
                    progressForm.UpdateProgress(progressPercentage);

                }
                //writer.WriteLine();
                //writer.WriteLine();
            }
            writer.Close();
            oDoc.Close(false);
            oWord.Quit();
            progressForm.CloseProgress(); 
            //MessageBox.Show("Считывание данных окончено");
        }

        private void importIntoWord_Click(object sender, EventArgs e)
        {
            string path = $@"C:\Users\sabba\source\repos\coursework\coursework\bin\Debug\Documents\{selectionDocument.Text}.docx";
            string pathToData = $@"C:\Users\sabba\source\repos\coursework\coursework\bin\Debug\data.csv.txt";

            using (StreamReader reader = new StreamReader(pathToData))
            {
                Word.Document oDoc;
                Word.Application oWord = new Word.Application();
                oDoc = oWord.Documents.Open(path);
                oWord.Visible = true; 

                for (int t = 1; t <= oDoc.Tables.Count; t++)
                {
                    Table table = oDoc.Tables[t];
                    int currentRow = 0; 

                    while (!reader.EndOfStream && currentRow < table.Rows.Count)
                    {
                        string line = reader.ReadLine();
                        string[] cells = line.Split(new char[] { ';' });

                        for (int j = 1; j <= table.Columns.Count; j++)
                        {
                            
                            if (j - 1 < cells.Length)
                            {
                                try
                                {
                                    table.Cell(currentRow + 1, j).Range.Text = cells[j - 1]; 
                                }
                                catch
                                {
                                   
                                }
                            }
                        }
                        currentRow++; 
                    }
                }

                oDoc.Save(); 
                oDoc.Close(false);
                oWord.Quit();
            }
        }

        private void importIntoExcel_Click(object sender, EventArgs e)
        {
            /*
            string path = $@"C:\Users\sabba\source\repos\coursework\coursework\bin\Debug\Documents\{selectionDocument.Text}.docx";
            string excelPath = $@"C:\Users\sabba\source\repos\coursework\coursework\bin\Debug\test.xlsx";

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false; 

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            for (int i = 0; i < path)
            */
        }
    }
}
