namespace laboratornaya_rabota_18
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.preview = new System.Windows.Forms.Button();
            this.exportIntoExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1234, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(365, 388);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(160, 23);
            this.preview.TabIndex = 1;
            this.preview.Text = "button1";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // exportIntoExcel
            // 
            this.exportIntoExcel.Location = new System.Drawing.Point(762, 388);
            this.exportIntoExcel.Name = "exportIntoExcel";
            this.exportIntoExcel.Size = new System.Drawing.Size(160, 23);
            this.exportIntoExcel.TabIndex = 2;
            this.exportIntoExcel.Text = "button2";
            this.exportIntoExcel.UseVisualStyleBackColor = true;
            this.exportIntoExcel.Click += new System.EventHandler(this.exportIntoExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 450);
            this.Controls.Add(this.exportIntoExcel);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button exportIntoExcel;
    }
}

