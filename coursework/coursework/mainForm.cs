using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Web;
using Microsoft.Office.Interop.PowerPoint;
using System.Text;

namespace coursework
{
    public partial class mainForm : Form
    {
        private string selectedWordDocument;
        private string pathToCSV = @"C:\Users\sabba\OneDrive\Рабочий стол\programming_third_semester\programming_third_semester\coursework\coursework\bin\Debug\exportData.csv";
        public mainForm()
        {
            InitializeComponent();
        }

        private void fileSelectionBtn_Click(object sender, EventArgs e)
        {
            if (documentSelection.ShowDialog() == DialogResult.OK) 
            {
                selectedWordDocument = documentSelection.FileName;
            }
        }
        private string getCellText(Word.Cell cell)
        {
            string cellText = cell.Range.Text;
           


            cellText = cellText.TrimEnd('\r', '\a');
            string[] lines = cellText.Split(new[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string res = string.Join("%", lines);

            return string.Join("%", lines);
        }
        private void exportWordToCsv_Click(object sender, EventArgs e)
        {
            Word.Document sourceDoc;
            Word.Application oWord = new Word.Application();
            sourceDoc = oWord.Documents.Open(selectedWordDocument);
            Word.Paragraph oPr = sourceDoc.Paragraphs.Add();

            Word.Document targetDoc = oWord.Documents.Add();
            /*
            using (StreamWriter writer = new StreamWriter(pathToCSV))
            {
                for (int t = 1; t <= sourceDoc.Tables.Count; t++)
                {
                    Word.Table table = sourceDoc.Tables[t];

                    for (int i = 1; i <= table.Rows.Count; i++)
                    {
                        string rowData = "";
                        for (int j = 1; j <= table.Rows[i].Cells.Count; j++)
                        {
                            try
                            {
                                string cellText = getCellText(table.Cell(i, j));
                                rowData += cellText + (j == table.Rows[i].Cells.Count ? "" : ";");
                            }
                            catch
                            {

                            }
                        }
                        //MessageBox.Show(rowData);
                        writer.WriteLine(rowData);
                    }
                }
                MessageBox.Show("+");
            }
            */
            using (StreamWriter writer = new StreamWriter(pathToCSV, false, System.Text.Encoding.UTF8))
            {
                using (StreamReader reader = new StreamReader(selectedWordDocument))
                {

                }
            }
                oWord.Quit();
        }

        private void importIntoWord_Click(object sender, EventArgs e)
        {
            Word.Document sourceDoc;
            Word.Application oWord = new Word.Application();
            sourceDoc = oWord.Documents.Open(selectedWordDocument);
            

            Word.Document targetDoc = oWord.Documents.Add();
            targetDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            sourceDoc.Range().Copy();
            targetDoc.Range(0, 0).Paste();

            using(StreamReader reader = new StreamReader(pathToCSV))
            {
               
                for (int t = 1; t < targetDoc.Tables.Count; t++)
                {
                    Word.Table table = targetDoc.Tables[t];
                    int currentRow = 0;
                    while (!reader.EndOfStream && currentRow < table.Rows.Count)
                    {
                        string line = reader.ReadLine();
                        string[] cells = line.Split(new char[] { ';' });
                        for (int j = 1; j <= table.Columns.Count; j++)
                        {
                            if (j - 1 < cells.Length)
                            {

                                string cellData = cells[j - 1];
                                string[] parts = cellData.Split('%'); 

                              
                                Word.Cell cell = table.Cell(currentRow + 1, j);
                                cell.Range.Text = ""; 


                                foreach (string part in parts)
                                {
                                    Word.Paragraph paragraph = cell.Range.Paragraphs.Add();
                                    paragraph.Range.Text = part.Trim();
                                }
                            }
                        }
                        currentRow++;
                    }
                }
            }

            targetDoc.SaveAs2(System.Windows.Forms.Application.StartupPath + "\\Титульный лист.docx");
            sourceDoc.Close();
            oWord.Quit();
            MessageBox.Show("++");
        }
    }
}
