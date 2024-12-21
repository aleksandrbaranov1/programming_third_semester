namespace laboratornaya_rabota_19
{
    partial class laboratornaya_rabota_19
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
            this.resultList = new System.Windows.Forms.ListBox();
            this.selectFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.parameterFilter = new System.Windows.Forms.TextBox();
            this.filter = new System.Windows.Forms.Button();
            this.choiceOfDay = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultList
            // 
            this.resultList.FormattingEnabled = true;
            this.resultList.ItemHeight = 16;
            this.resultList.Location = new System.Drawing.Point(593, 28);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(645, 308);
            this.resultList.TabIndex = 0;
            // 
            // selectFilter
            // 
            this.selectFilter.FormattingEnabled = true;
            this.selectFilter.Location = new System.Drawing.Point(6, 57);
            this.selectFilter.Name = "selectFilter";
            this.selectFilter.Size = new System.Drawing.Size(547, 24);
            this.selectFilter.TabIndex = 1;
            this.selectFilter.SelectedIndexChanged += new System.EventHandler(this.selectFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбрать фильтр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Параметр фильтрации";
            // 
            // parameterFilter
            // 
            this.parameterFilter.Location = new System.Drawing.Point(6, 135);
            this.parameterFilter.Name = "parameterFilter";
            this.parameterFilter.Size = new System.Drawing.Size(229, 22);
            this.parameterFilter.TabIndex = 5;
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.AntiqueWhite;
            this.filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filter.Location = new System.Drawing.Point(206, 264);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(183, 72);
            this.filter.TabIndex = 6;
            this.filter.Text = "Отфильтровать";
            this.filter.UseVisualStyleBackColor = false;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // choiceOfDay
            // 
            this.choiceOfDay.FormattingEnabled = true;
            this.choiceOfDay.Location = new System.Drawing.Point(18, 256);
            this.choiceOfDay.Name = "choiceOfDay";
            this.choiceOfDay.Size = new System.Drawing.Size(121, 24);
            this.choiceOfDay.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.parameterFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 179);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выбрать день";
            // 
            // laboratornaya_rabota_19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1251, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.choiceOfDay);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.resultList);
            this.Name = "laboratornaya_rabota_19";
            this.Text = "Задание №19 выполнил: Баранов А.А., номер варианта: 7, дата выполнения: 21.12.202" +
    "4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox parameterFilter;
        private System.Windows.Forms.Button filter;
        public System.Windows.Forms.ComboBox selectFilter;
        private System.Windows.Forms.ComboBox choiceOfDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}

