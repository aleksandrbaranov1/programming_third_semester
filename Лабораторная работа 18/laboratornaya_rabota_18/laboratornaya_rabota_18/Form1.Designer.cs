namespace laboratornaya_rabota_18
{
    partial class laboratornaya_rabota_18
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
            this.previewTable = new System.Windows.Forms.DataGridView();
            this.preview = new System.Windows.Forms.Button();
            this.exportIntoExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // previewTable
            // 
            this.previewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.previewTable.Location = new System.Drawing.Point(12, 12);
            this.previewTable.Name = "previewTable";
            this.previewTable.RowHeadersWidth = 51;
            this.previewTable.RowTemplate.Height = 24;
            this.previewTable.Size = new System.Drawing.Size(1366, 272);
            this.previewTable.TabIndex = 0;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(403, 332);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(163, 23);
            this.preview.TabIndex = 1;
            this.preview.Text = "Предпросмотр";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // exportIntoExcel
            // 
            this.exportIntoExcel.Location = new System.Drawing.Point(818, 332);
            this.exportIntoExcel.Name = "exportIntoExcel";
            this.exportIntoExcel.Size = new System.Drawing.Size(163, 23);
            this.exportIntoExcel.TabIndex = 2;
            this.exportIntoExcel.Text = "Выгрузка в Excel";
            this.exportIntoExcel.UseVisualStyleBackColor = true;
            this.exportIntoExcel.Click += new System.EventHandler(this.exportIntoExcel_Click);
            // 
            // laboratornaya_rabota_18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 388);
            this.Controls.Add(this.exportIntoExcel);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.previewTable);
            this.Name = "laboratornaya_rabota_18";
            this.Text = "Задание №18 выполнил: Баранов А.А., номер варианта: 7, дата выполнения: 30.11.202" +
    "4";
            ((System.ComponentModel.ISupportInitialize)(this.previewTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView previewTable;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button exportIntoExcel;
    }
}

