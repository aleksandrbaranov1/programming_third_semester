namespace laboratornaya_rabota_17
{
    partial class wordAutomation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.createATitlePage = new System.Windows.Forms.Button();
            this.reportingDocument = new System.Windows.Forms.ComboBox();
            this.workType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.topicOfWork = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nameOfTheDiscipline = new System.Windows.Forms.TextBox();
            this.teacher = new System.Windows.Forms.TextBox();
            this.addReportSections = new System.Windows.Forms.CheckBox();
            this.createADocument = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Вид отчетного документа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Вид работы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 412);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Преподаватель";
            // 
            // createATitlePage
            // 
            this.createATitlePage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.createATitlePage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.createATitlePage.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.createATitlePage.Location = new System.Drawing.Point(226, 557);
            this.createATitlePage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createATitlePage.Name = "createATitlePage";
            this.createATitlePage.Size = new System.Drawing.Size(172, 102);
            this.createATitlePage.TabIndex = 15;
            this.createATitlePage.Text = "Создать титульный лист";
            this.createATitlePage.UseVisualStyleBackColor = false;
            this.createATitlePage.Click += new System.EventHandler(this.createATitlePage_Click);
            // 
            // reportingDocument
            // 
            this.reportingDocument.FormattingEnabled = true;
            this.reportingDocument.Location = new System.Drawing.Point(226, 79);
            this.reportingDocument.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.reportingDocument.Name = "reportingDocument";
            this.reportingDocument.Size = new System.Drawing.Size(202, 29);
            this.reportingDocument.TabIndex = 16;
            // 
            // workType
            // 
            this.workType.FormattingEnabled = true;
            this.workType.Location = new System.Drawing.Point(226, 137);
            this.workType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.workType.Name = "workType";
            this.workType.Size = new System.Drawing.Size(202, 29);
            this.workType.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 204);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "Номер работы";
            // 
            // number
            // 
            this.number.FormattingEnabled = true;
            this.number.Location = new System.Drawing.Point(226, 204);
            this.number.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(202, 29);
            this.number.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 268);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 21);
            this.label9.TabIndex = 20;
            this.label9.Text = "Тема работы";
            // 
            // topicOfWork
            // 
            this.topicOfWork.Location = new System.Drawing.Point(226, 268);
            this.topicOfWork.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.topicOfWork.Name = "topicOfWork";
            this.topicOfWork.Size = new System.Drawing.Size(202, 30);
            this.topicOfWork.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 337);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 21);
            this.label10.TabIndex = 22;
            this.label10.Text = "Наименование дисциплины";
            // 
            // nameOfTheDiscipline
            // 
            this.nameOfTheDiscipline.Location = new System.Drawing.Point(226, 337);
            this.nameOfTheDiscipline.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nameOfTheDiscipline.Name = "nameOfTheDiscipline";
            this.nameOfTheDiscipline.Size = new System.Drawing.Size(202, 30);
            this.nameOfTheDiscipline.TabIndex = 23;
            // 
            // teacher
            // 
            this.teacher.Location = new System.Drawing.Point(226, 412);
            this.teacher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.teacher.Name = "teacher";
            this.teacher.Size = new System.Drawing.Size(202, 30);
            this.teacher.TabIndex = 24;
            // 
            // addReportSections
            // 
            this.addReportSections.AutoSize = true;
            this.addReportSections.Location = new System.Drawing.Point(205, 516);
            this.addReportSections.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addReportSections.Name = "addReportSections";
            this.addReportSections.Size = new System.Drawing.Size(223, 25);
            this.addReportSections.TabIndex = 25;
            this.addReportSections.Text = "Добавить разделы отчета";
            this.addReportSections.UseVisualStyleBackColor = true;
            // 
            // createADocument
            // 
            this.createADocument.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.createADocument.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.createADocument.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.createADocument.Location = new System.Drawing.Point(744, 557);
            this.createADocument.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createADocument.Name = "createADocument";
            this.createADocument.Size = new System.Drawing.Size(172, 102);
            this.createADocument.TabIndex = 26;
            this.createADocument.Text = "Создать документ";
            this.createADocument.UseVisualStyleBackColor = false;
            this.createADocument.Click += new System.EventHandler(this.createADocument_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::laboratornaya_rabota_17.Properties.Resources.Снимок_экрана_2024_10_16_010341;
            this.pictureBox1.Location = new System.Drawing.Point(661, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 499);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // wordAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1099, 699);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.createADocument);
            this.Controls.Add(this.addReportSections);
            this.Controls.Add(this.teacher);
            this.Controls.Add(this.nameOfTheDiscipline);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.topicOfWork);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.number);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.workType);
            this.Controls.Add(this.reportingDocument);
            this.Controls.Add(this.createATitlePage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("GOST Type AU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "wordAutomation";
            this.Text = "Задание №17 выполнил: Баранов А.А.; Номер варианта: 7; Дата выполнения: 27.10.202" +
    "4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button createATitlePage;
        private System.Windows.Forms.ComboBox reportingDocument;
        private System.Windows.Forms.ComboBox workType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox number;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox topicOfWork;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nameOfTheDiscipline;
        private System.Windows.Forms.TextBox teacher;
        private System.Windows.Forms.CheckBox addReportSections;
        private System.Windows.Forms.Button createADocument;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

