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
            this.SuspendLayout();
            // 
            // resultList
            // 
            this.resultList.FormattingEnabled = true;
            this.resultList.ItemHeight = 16;
            this.resultList.Location = new System.Drawing.Point(624, 28);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(645, 356);
            this.resultList.TabIndex = 0;
            // 
            // selectFilter
            // 
            this.selectFilter.FormattingEnabled = true;
            this.selectFilter.Location = new System.Drawing.Point(15, 83);
            this.selectFilter.Name = "selectFilter";
            this.selectFilter.Size = new System.Drawing.Size(603, 24);
            this.selectFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбрать фильтр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Параметр фильтрации";
            // 
            // parameterFilter
            // 
            this.parameterFilter.Location = new System.Drawing.Point(15, 161);
            this.parameterFilter.Name = "parameterFilter";
            this.parameterFilter.Size = new System.Drawing.Size(229, 22);
            this.parameterFilter.TabIndex = 5;
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(12, 220);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(154, 42);
            this.filter.TabIndex = 6;
            this.filter.Text = "Отфильтровать";
            this.filter.UseVisualStyleBackColor = true;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // laboratornaya_rabota_19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 529);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.parameterFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFilter);
            this.Controls.Add(this.resultList);
            this.Name = "laboratornaya_rabota_19";
            this.Text = "Form1";
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
    }
}

