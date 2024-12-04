namespace coursework
{
    partial class Form1
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
            this.selectionDocument = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exportDocument = new System.Windows.Forms.Button();
            this.importIntoWord = new System.Windows.Forms.Button();
            this.importIntoExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectionDocument
            // 
            this.selectionDocument.FormattingEnabled = true;
            this.selectionDocument.Location = new System.Drawing.Point(169, 205);
            this.selectionDocument.Name = "selectionDocument";
            this.selectionDocument.Size = new System.Drawing.Size(180, 24);
            this.selectionDocument.TabIndex = 0;
            this.selectionDocument.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите документ";
            // 
            // exportDocument
            // 
            this.exportDocument.Location = new System.Drawing.Point(169, 293);
            this.exportDocument.Name = "exportDocument";
            this.exportDocument.Size = new System.Drawing.Size(180, 60);
            this.exportDocument.TabIndex = 2;
            this.exportDocument.Text = "Экспортировать документ";
            this.exportDocument.UseVisualStyleBackColor = true;
            this.exportDocument.Click += new System.EventHandler(this.button1_Click);
            // 
            // importIntoWord
            // 
            this.importIntoWord.Location = new System.Drawing.Point(424, 293);
            this.importIntoWord.Name = "importIntoWord";
            this.importIntoWord.Size = new System.Drawing.Size(180, 60);
            this.importIntoWord.TabIndex = 3;
            this.importIntoWord.Text = "Импортировать в Word";
            this.importIntoWord.UseVisualStyleBackColor = true;
            this.importIntoWord.Click += new System.EventHandler(this.importIntoWord_Click);
            // 
            // importIntoExcel
            // 
            this.importIntoExcel.Location = new System.Drawing.Point(681, 293);
            this.importIntoExcel.Name = "importIntoExcel";
            this.importIntoExcel.Size = new System.Drawing.Size(180, 60);
            this.importIntoExcel.TabIndex = 4;
            this.importIntoExcel.Text = "Импортировать в Excel";
            this.importIntoExcel.UseVisualStyleBackColor = true;
            this.importIntoExcel.Click += new System.EventHandler(this.importIntoExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 519);
            this.Controls.Add(this.importIntoExcel);
            this.Controls.Add(this.importIntoWord);
            this.Controls.Add(this.exportDocument);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectionDocument);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectionDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exportDocument;
        private System.Windows.Forms.Button importIntoWord;
        private System.Windows.Forms.Button importIntoExcel;
    }
}

