using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using Word2 = Microsoft.Office.Interop.Word;


namespace laboratornaya_rabota_17
{

    public partial class wordAutomation : Form
    {
        object ObjMissing = Missing.Value;
        private string[] typeOfReportingDocument = { "Отчёт", "Реферат", "Эссе", "Курсовой проект", 
            "Курсовая работа", "Доклад", "Домашнее задание"};
        private string[] typeOfWork = { "Лабораторная работа", "Практическая работа", "Индивидуальное задание", 
            "Учебная практика", "Производственная практика", "Преддипломная практика"};
        private string[] numberOfWork = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        private string selectedDocument;
        public wordAutomation()
        {
            InitializeComponent();
            reportingDocument.Items.AddRange(typeOfReportingDocument);
            workType.Items.AddRange(typeOfWork);
            number.Items.AddRange(numberOfWork);
            //selectedDocument = comboBox1.Text;
            
        }
        private void createATitlePage_Click(object sender, EventArgs e)
        {

            Word.Application wordApp = new Word.Application();
            //MessageBox.Show($"Version of Microsoft.Office.Interop.Word: {version}");
            //Word.Application oWord;
            Word.Document oDoc;
            Word.Paragraph oPr;

            Word.Application oWord = new Word.Application();
            oDoc = oWord.Documents.Add();
            oPr = oDoc.Paragraphs.Add();

            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Министерство транспорта Российской Федерации";
            oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Федеральное государственное автономное образовательное";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "учреждение высшего образования";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "«Российский университет транспорта»";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "(ФГАОУ ВО РУТ(МИИТ), РУТ (МИИТ)";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Институт транспортной техники и систем управления";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Кафедра «Управление и защита информации»";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";

            //selectedDocument = comboBox1.Text;

            //MessageBox.Show(selectedDocument);

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 28;
            oPr.Range.Text = (reportingDocument.SelectedIndex >= 0 ? reportingDocument.Text : workType.Text) + " №" + number.Text;

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = $"по дисциплине: «{nameOfTheDiscipline.Text}»";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = $"на тему: «{topicOfWork.Text}»";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Выполнил: ст. гр. ТУУ-211";
            oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Баранов А.А.";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Вариант №7";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = $"Проверил: {teacher.Text}";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";
            oPr.Range.Text = "";
            oPr.Range.InsertParagraphAfter();
            oPr.Range.Text = "";

            oPr.Range.InsertParagraphAfter();
            oPr.Range.Font.Name = "Times new roman";
            oPr.Range.Font.Size = 14;
            oPr.Range.Text = "Москва – 2024 г.";
            oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            
            if (addReportSections.Checked)
            {
                oPr.Range.InsertParagraphAfter();
                oPr.Range.Font.Bold = 1;
                oPr.Range.Font.Name = "Times new roman";
                oPr.Range.Font.Size = 14;
                oPr.Range.Text = "1. Цель работы";
                oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                oPr.Range.InsertParagraphAfter();
                object breakType = Word.WdBreakType.wdPageBreak;
                oPr.Range.InsertBreak(ref breakType);

                oPr.Range.Font.Bold = 1;
                oPr.Range.Font.Name = "Times new roman";
                oPr.Range.Font.Size = 14;
                oPr.Range.Text = "2. Задача";
                oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                oPr.Range.InsertParagraphAfter();
                oPr.Range.InsertBreak(ref breakType);

                oPr.Range.Font.Bold = 1;
                oPr.Range.Font.Name = "Times new roman";
                oPr.Range.Font.Size = 14;
                oPr.Range.Text = "3. Содержательная часть";
                oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                oPr.Range.InsertParagraphAfter();
                oPr.Range.InsertBreak(ref breakType);

                oPr.Range.Font.Bold = 1;
                oPr.Range.Font.Name = "Times new roman";
                oPr.Range.Font.Size = 14;
                oPr.Range.Text = "4. Вывод";
                oPr.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            }
            oDoc.SaveAs2(Application.StartupPath + "\\Титульный лист.docx");
            oWord.Quit();
        }
        private void createADocument_Click(object sender, EventArgs e)
        {
            Word2.Application oWord2 = new Word.Application();
            Word2.Document oDoc2 = oWord2.Documents.Add();
            Word2.Paragraph oPr2 = oDoc2.Paragraphs.Add();
            Word2.Table oTab;

            Word2.Table table = oDoc2.Tables.Add(oDoc2.Range(0, 0), 48, 1);

            foreach (Word.Row row in table.Rows)
            {
                row.Height = 11; 
                row.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
            }
            table.Cell(1, 1).Range.Text = "Наименование министерства (ведомства)";
            table.Cell(1, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            table.Cell(1, 1).Range.Font.Size = 12;

            table.Rows.Height = 15;

            table.Cell(2, 1).Range.Text = "ПОЛНОЕ НАИМЕНОВАНИЕ ОРГАНИЗАЦИИ – ИСПОЛНИТЕЛЬ НИР";
            table.Cell(2, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            table.Cell(2, 1).Range.Font.Size = 12;

            table.Cell(3, 1).Range.Text = "(СОКРАЩЕННОЕ НАИМЕНОВАНИЕ ОРГАНИЗАЦИИ – ИМПОЛНИТЕЛЬ НИР)";
            table.Cell(3, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            table.Cell(3, 1).Range.Font.Size = 12;

            table.Cell(4, 1).Merge(table.Cell(6, 1));

            table.Cell(5, 1).Range.Text = "Индекс УДК";
            table.Cell(5, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(5, 1).Range.Font.Size = 12;

            table.Cell(6, 1).Range.Text = "ИРег. № НИОКТР";
            table.Cell(6, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(6, 1).Range.Font.Size = 12;

            table.Cell(7, 1).Range.Text = "Рег. № ИКРБС";
            table.Cell(7, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(7, 1).Range.Font.Size = 12;

            table.Cell(8, 1).Merge(table.Cell(10, 1)); // 8я строка

            table.Cell(9, 1).Split(1, 2);
            table.Cell(9, 1).Range.Text = "СОГЛАСОВАНО";
            table.Cell(9, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(9, 1).Range.Font.Size = 12;

            table.Cell(9, 2).Range.Text = "УТВЕРЖДАЮ";
            table.Cell(9, 2).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(9, 2).Range.Font.Size = 12;

            table.Cell(10, 1).Split(1, 2);
            table.Cell(10, 1).Range.Text = "Должность, сокращ. наимен. орг.";
            table.Cell(10, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(10, 1).Range.Font.Size = 12;

            table.Cell(10, 2).Range.Text = "Должность, сокращ. наимен. орг.";
            table.Cell(10, 2).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphLeft;
            table.Cell(10, 2).Range.Font.Size = 12;


            table.Cell(12, 1).Split(1, 2);
            table.Cell(12, 1).Split(1, 2);
            table.Cell(12, 1).Split(1, 2);
            table.Cell(12, 1).Split(1, 2);
            table.Cell(12, 1).Split(1, 2);
            table.Cell(12, 1).Split(1, 2);
            table.Cell(12, 1).Split(1, 2);

            //12 строка 1 ячейка
            //Word2.Cell cell1 = table.Cell(12, 1);
            table.Cell(12, 1).Width = 85;
            table.Cell(12, 1).Range.Text = "подпись";
            table.Cell(12, 1).Range.Font.Size = 8;
            table.Cell(12, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            Word2.Border topBorder = table.Cell(12, 1).Borders[Word.WdBorderType.wdBorderTop];
            topBorder.LineStyle = Word.WdLineStyle.wdLineStyleSingle;  
            topBorder.LineWidth = Word.WdLineWidth.wdLineWidth025pt;  
            topBorder.Color = Word.WdColor.wdColorBlack;

            //Word2.Cell cell2 = table.Cell(12, 2);
            table.Cell(12, 2).Width = 14;

            //12 строка 3 ячейка 
            //Word2.Cell cell3 = table.Cell(12, 3);
            table.Cell(12, 3).Width = 92;
            table.Cell(12, 3).Range.Text = "расшифровка подписи";
            table.Cell(12, 3).Range.Font.Size = 8;
            table.Cell(12, 3).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            Word2.Border topBorder2 = table.Cell(12, 3).Borders[Word.WdBorderType.wdBorderTop];
            topBorder2.LineStyle = Word.WdLineStyle.wdLineStyleSingle; 
            topBorder2.LineWidth = Word.WdLineWidth.wdLineWidth025pt;   
            topBorder2.Color = Word.WdColor.wdColorBlack;

            //Word2.Cell cell4 = table.Cell(12, 4);
            table.Cell(12, 4).Width = 41;

            //12 строка 5 ячейка
            //Word2.Cell cell5 = table.Cell(12, 5);
            table.Cell(12, 5).Width = 77;
            table.Cell(12, 5).Range.Text = "подпись";
            table.Cell(12, 5).Range.Font.Size = 8;
            table.Cell(12, 5).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            Word2.Border topBorder3 = table.Cell(12, 5).Borders[Word.WdBorderType.wdBorderTop];
            topBorder3.LineStyle = Word.WdLineStyle.wdLineStyleSingle;  
            topBorder3.LineWidth = Word.WdLineWidth.wdLineWidth025pt;   
            topBorder3.Color = Word.WdColor.wdColorBlack;

            //Word2.Cell cell6 = table.Cell(12, 6);
            table.Cell(12, 6).Width = 14;

            //12 строка 7 ячейка
            //Word2.Cell cell7 = table.Cell(12, 7);
            table.Cell(12, 7).Width = 92;
            table.Cell(12, 7).Range.Text = "расшифровка подписи";
            table.Cell(12, 7).Range.Font.Size = 8;
            table.Cell(12, 7).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            Word2.Border topBorder4 = table.Cell(12, 7).Borders[Word.WdBorderType.wdBorderTop];
            topBorder4.LineStyle = Word.WdLineStyle.wdLineStyleSingle; 
            topBorder4.LineWidth = Word.WdLineWidth.wdLineWidth025pt;   
            topBorder4.Color = Word.WdColor.wdColorBlack;

            //Word2.Cell cell8 = table.Cell(12, 8);
            table.Cell(12, 8).Width = 53;

            table.Cell(14, 1).Split(1, 2);
            table.Cell(14, 1).Split(1, 2);
            table.Cell(14, 3).Split(1, 2);
            table.Cell(14, 4).Split(1, 2);

            //14 строка 1 ячейка
            //Word2.Cell cell12 = table.Cell(14, 1);
            table.Cell(14, 1).Width = 163;
            table.Cell(14, 1).Range.Text = "дата";
            table.Cell(14, 1).Range.Font.Size= 8;
            table.Cell(14, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            Word2.Border topBorder5 = table.Cell(14, 1).Borders[Word.WdBorderType.wdBorderTop];
            topBorder5.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            topBorder5.LineWidth = Word.WdLineWidth.wdLineWidth025pt;

            table.Cell(14, 2).Width = 71;
            table.Cell(14, 3).Width = 29;

            //14 строка 4 ячейка
            //Word2.Cell cell42 = table.Cell(14, 4);
            table.Cell(14, 4).Width = 156;
            table.Cell(14, 4).Range.Text = "дата";
            table.Cell(14, 4).Range.Font.Size = 8;
            table.Cell(14, 4).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            Word2.Border topBorder6 = table.Cell(14, 4).Borders[Word.WdBorderType.wdBorderTop];
            topBorder6.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            topBorder6.LineWidth = Word.WdLineWidth.wdLineWidth025pt;

            table.Cell(14, 5).Width = 49;

            table.Cell(15, 1).Merge(table.Cell(20, 1)); //16 строка

            table.Cell(17, 1).Range.Text = "ОТЧЕТ";
            table.Cell(17, 1).Range.Font.Size = 11;
            table.Cell(17, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(18, 1).Range.Text = "О НАУЧНО-ИССЛЕДОВАТЕЛЬСКОЙ РАБОТЕ";
            table.Cell(18, 1).Range.Font.Size = 11;
            table.Cell(18, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(20, 1).Range.Text = "Наименование НИР";
            table.Cell(20, 1).Range.Font.Size = 11;
            table.Cell(20, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(21, 1).Range.Text = "по теме:";
            table.Cell(21, 1).Range.Font.Size = 11;
            table.Cell(21, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(22, 1).Range.Text = "НАИМЕНОВАНИЕ ОТЧЕТА";
            table.Cell(22, 1).Range.Font.Size = 11;
            table.Cell(22, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(23, 1).Range.Text = "(вид отчета, № этапа)";
            table.Cell(23, 1).Range.Font.Size = 11;
            table.Cell(23, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;


            table.Cell(25, 1).Range.Text = "Наименование федеральной программы";
            table.Cell(25, 1).Range.Font.Size = 11;
            table.Cell(25, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(26, 1).Range.Text = "Номер книги";
            table.Cell(26, 1).Range.Font.Size = 11;
            table.Cell(26, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Cell(27, 1).Merge(table.Cell(32, 1)); // 28 строка

            table.Cell(28, 1).Split(1, 3);
            table.Cell(28, 1).Width = 128;
            table.Cell(28, 2).Width = 106;
            table.Cell(28, 2).Range.Text = "Руководитель НИР,";
            table.Cell(28, 2).Range.Font.Size = 11;
            table.Cell(28, 3).Width = 233;

            table.Cell(29, 1).Split(1, 3);
            table.Cell(29, 1).Width = 128;
            table.Cell(29, 2).Width = 106;
            table.Cell(29, 2).Range.Text = "должность";
            table.Cell(29, 2).Range.Font.Size = 11;
            table.Cell(29, 3).Width = 233;
            table.Cell(29, 3).Range.Text = "ФИО";
            table.Cell(29, 3).Range.Font.Size = 11;
            table.Cell(29, 3).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;
            
            table.Cell(30, 1).Split(1, 4);
            table.Cell(30, 1).Width = 234;
            table.Cell(30, 2).Width = 28;
            table.Cell(30, 3).Width = 78;
            table.Cell(30, 3).Range.Text = "подпись, дата";
            table.Cell(30, 3).Range.Font.Size = 8;
            table.Cell(30, 3).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphRight;
            Word2.Border topBorder7 = table.Cell(30, 3).Borders[Word.WdBorderType.wdBorderTop];
            topBorder7.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            topBorder7.LineWidth = Word.WdLineWidth.wdLineWidth025pt;
            table.Cell(30, 4).Width = 127;

            table.Cell(31, 1).Merge(table.Cell(33, 1));

            table.Cell(32, 1).Range.Text = "Место Год";
            table.Cell(32, 1).Range.Font.Size = 11;
            table.Cell(32, 1).Range.ParagraphFormat.Alignment = Word2.WdParagraphAlignment.wdAlignParagraphCenter;

            table.Borders.OutsideLineStyle = Word2.WdLineStyle.wdLineStyleNone;

            oDoc2.SaveAs2(Application.StartupPath + "\\Индивидуальный документ.docx");
            oWord2.Quit();
        }
    }
}
