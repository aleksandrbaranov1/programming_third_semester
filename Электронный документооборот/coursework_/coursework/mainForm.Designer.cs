namespace coursework
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.documentSelection = new System.Windows.Forms.OpenFileDialog();
            this.fileSelectionBtn = new System.Windows.Forms.Button();
            this.exportCSVToWord = new System.Windows.Forms.Button();
            this.ImportIntoCSV = new System.Windows.Forms.Button();
            this.exportCSVToExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.periodFilter = new System.Windows.Forms.TextBox();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showDiagram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parameterFilter = new System.Windows.Forms.TextBox();
            this.selectingChartMode = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // documentSelection
            // 
            this.documentSelection.InitialDirectory = "C:\\Users\\sabba\\OneDrive\\Рабочий стол\\programming_third_semester\\programming_third" +
    "_semester\\coursework\\coursework\\Documents";
            // 
            // fileSelectionBtn
            // 
            this.fileSelectionBtn.Location = new System.Drawing.Point(7, 36);
            this.fileSelectionBtn.Name = "fileSelectionBtn";
            this.fileSelectionBtn.Size = new System.Drawing.Size(186, 31);
            this.fileSelectionBtn.TabIndex = 0;
            this.fileSelectionBtn.Text = "Выбрать документ";
            this.fileSelectionBtn.UseVisualStyleBackColor = true;
            this.fileSelectionBtn.Click += new System.EventHandler(this.fileSelectionBtn_Click);
            // 
            // exportCSVToWord
            // 
            this.exportCSVToWord.Location = new System.Drawing.Point(6, 21);
            this.exportCSVToWord.Name = "exportCSVToWord";
            this.exportCSVToWord.Size = new System.Drawing.Size(186, 53);
            this.exportCSVToWord.TabIndex = 1;
            this.exportCSVToWord.Text = "Экспорт в Word-документ из CSV";
            this.exportCSVToWord.UseVisualStyleBackColor = true;
            this.exportCSVToWord.Click += new System.EventHandler(this.exportCSVToWord_Click);
            // 
            // ImportIntoCSV
            // 
            this.ImportIntoCSV.Location = new System.Drawing.Point(6, 73);
            this.ImportIntoCSV.Name = "ImportIntoCSV";
            this.ImportIntoCSV.Size = new System.Drawing.Size(186, 53);
            this.ImportIntoCSV.TabIndex = 2;
            this.ImportIntoCSV.Text = "Импорт сведений из печтаной формы в CSV";
            this.ImportIntoCSV.UseVisualStyleBackColor = true;
            this.ImportIntoCSV.Click += new System.EventHandler(this.importIntoCSV_Click);
            // 
            // exportCSVToExcel
            // 
            this.exportCSVToExcel.Location = new System.Drawing.Point(6, 80);
            this.exportCSVToExcel.Name = "exportCSVToExcel";
            this.exportCSVToExcel.Size = new System.Drawing.Size(186, 53);
            this.exportCSVToExcel.TabIndex = 3;
            this.exportCSVToExcel.Text = "Экспорт в Excel-документ из CSV";
            this.exportCSVToExcel.UseVisualStyleBackColor = true;
            this.exportCSVToExcel.Click += new System.EventHandler(this.exportCSVToExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exportCSVToExcel);
            this.groupBox1.Controls.Add(this.exportCSVToWord);
            this.groupBox1.Location = new System.Drawing.Point(12, 387);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 147);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Функции экспорта";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ImportIntoCSV);
            this.groupBox2.Controls.Add(this.fileSelectionBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 147);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Функции импорта";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.periodFilter);
            this.groupBox3.Controls.Add(this.mainChart);
            this.groupBox3.Controls.Add(this.showDiagram);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.parameterFilter);
            this.groupBox3.Controls.Add(this.selectingChartMode);
            this.groupBox3.Location = new System.Drawing.Point(233, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1267, 719);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Графический анализ данных, содержащихся в печатной форме";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 665);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Период";
            // 
            // periodFilter
            // 
            this.periodFilter.Enabled = false;
            this.periodFilter.Location = new System.Drawing.Point(23, 684);
            this.periodFilter.Name = "periodFilter";
            this.periodFilter.Size = new System.Drawing.Size(416, 22);
            this.periodFilter.TabIndex = 6;
            // 
            // mainChart
            // 
            this.mainChart.Location = new System.Drawing.Point(23, 31);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(1226, 513);
            this.mainChart.TabIndex = 5;
            this.mainChart.Text = "mainChart";
            // 
            // showDiagram
            // 
            this.showDiagram.Location = new System.Drawing.Point(576, 628);
            this.showDiagram.Name = "showDiagram";
            this.showDiagram.Size = new System.Drawing.Size(186, 53);
            this.showDiagram.TabIndex = 4;
            this.showDiagram.Text = "Показать диаграмму";
            this.showDiagram.UseVisualStyleBackColor = true;
            this.showDiagram.Click += new System.EventHandler(this.showDiagram_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать диаграмму";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Параметр диаграммы";
            // 
            // parameterFilter
            // 
            this.parameterFilter.Enabled = false;
            this.parameterFilter.Location = new System.Drawing.Point(23, 628);
            this.parameterFilter.Name = "parameterFilter";
            this.parameterFilter.Size = new System.Drawing.Size(416, 22);
            this.parameterFilter.TabIndex = 2;
            // 
            // selectingChartMode
            // 
            this.selectingChartMode.FormattingEnabled = true;
            this.selectingChartMode.Location = new System.Drawing.Point(23, 576);
            this.selectingChartMode.Name = "selectingChartMode";
            this.selectingChartMode.Size = new System.Drawing.Size(1226, 24);
            this.selectingChartMode.TabIndex = 1;
            this.selectingChartMode.SelectedIndexChanged += new System.EventHandler(this.selectingChartMode_SelectedIndexChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 760);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "mainForm";
            this.Text = "Электронный документооборот";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog documentSelection;
        private System.Windows.Forms.Button fileSelectionBtn;
        private System.Windows.Forms.Button exportCSVToWord;
        private System.Windows.Forms.Button ImportIntoCSV;
        private System.Windows.Forms.Button exportCSVToExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox selectingChartMode;
        private System.Windows.Forms.Button showDiagram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox parameterFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox periodFilter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

