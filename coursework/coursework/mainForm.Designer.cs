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
            this.exportWordToCsv = new System.Windows.Forms.Button();
            this.importIntoWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // documentSelection
            // 
            this.documentSelection.InitialDirectory = "C:\\Users\\sabba\\OneDrive\\Рабочий стол\\programming_third_semester\\programming_third" +
    "_semester\\coursework\\coursework\\Documents";
            // 
            // fileSelectionBtn
            // 
            this.fileSelectionBtn.Location = new System.Drawing.Point(21, 347);
            this.fileSelectionBtn.Name = "fileSelectionBtn";
            this.fileSelectionBtn.Size = new System.Drawing.Size(151, 55);
            this.fileSelectionBtn.TabIndex = 0;
            this.fileSelectionBtn.Text = "Выбрать документ";
            this.fileSelectionBtn.UseVisualStyleBackColor = true;
            this.fileSelectionBtn.Click += new System.EventHandler(this.fileSelectionBtn_Click);
            // 
            // exportWordToCsv
            // 
            this.exportWordToCsv.Location = new System.Drawing.Point(266, 347);
            this.exportWordToCsv.Name = "exportWordToCsv";
            this.exportWordToCsv.Size = new System.Drawing.Size(151, 55);
            this.exportWordToCsv.TabIndex = 1;
            this.exportWordToCsv.Text = "Выбрать документ";
            this.exportWordToCsv.UseVisualStyleBackColor = true;
            this.exportWordToCsv.Click += new System.EventHandler(this.exportWordToCsv_Click);
            // 
            // importIntoWord
            // 
            this.importIntoWord.Location = new System.Drawing.Point(474, 347);
            this.importIntoWord.Name = "importIntoWord";
            this.importIntoWord.Size = new System.Drawing.Size(151, 55);
            this.importIntoWord.TabIndex = 2;
            this.importIntoWord.Text = "Импорт в ворд";
            this.importIntoWord.UseVisualStyleBackColor = true;
            this.importIntoWord.Click += new System.EventHandler(this.importIntoWord_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 515);
            this.Controls.Add(this.importIntoWord);
            this.Controls.Add(this.exportWordToCsv);
            this.Controls.Add(this.fileSelectionBtn);
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog documentSelection;
        private System.Windows.Forms.Button fileSelectionBtn;
        private System.Windows.Forms.Button exportWordToCsv;
        private System.Windows.Forms.Button importIntoWord;
    }
}

