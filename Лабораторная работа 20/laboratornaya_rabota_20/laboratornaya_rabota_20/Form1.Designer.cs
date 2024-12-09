namespace laboratornaya_rabota_20
{
    partial class laboratornaya_rabota_20
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
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showAllRows = new System.Windows.Forms.Button();
            this.showSelectedRow = new System.Windows.Forms.Button();
            this.rowSelection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.Location = new System.Drawing.Point(23, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(718, 345);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // showAllRows
            // 
            this.showAllRows.Location = new System.Drawing.Point(23, 450);
            this.showAllRows.Name = "showAllRows";
            this.showAllRows.Size = new System.Drawing.Size(175, 88);
            this.showAllRows.TabIndex = 1;
            this.showAllRows.Text = "Показать все ряды номограммы";
            this.showAllRows.UseVisualStyleBackColor = true;
            this.showAllRows.Click += new System.EventHandler(this.showAllRows_Click);
            // 
            // showSelectedRow
            // 
            this.showSelectedRow.Location = new System.Drawing.Point(566, 452);
            this.showSelectedRow.Name = "showSelectedRow";
            this.showSelectedRow.Size = new System.Drawing.Size(175, 88);
            this.showSelectedRow.TabIndex = 2;
            this.showSelectedRow.Text = "Показать выбранный ряд номограммы";
            this.showSelectedRow.UseVisualStyleBackColor = true;
            this.showSelectedRow.Click += new System.EventHandler(this.showSelectedRow_Click);
            // 
            // rowSelection
            // 
            this.rowSelection.Location = new System.Drawing.Point(566, 404);
            this.rowSelection.Name = "rowSelection";
            this.rowSelection.Size = new System.Drawing.Size(175, 22);
            this.rowSelection.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите ряд номограммы";
            // 
            // laboratornaya_rabota_20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rowSelection);
            this.Controls.Add(this.showSelectedRow);
            this.Controls.Add(this.showAllRows);
            this.Controls.Add(this.mainChart);
            this.Name = "laboratornaya_rabota_20";
            this.Text = "Задание №20 выполнил: Баранов А.А., номер варианта: 7, дата выполнения: 09.12.202" +
    "4";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button showAllRows;
        private System.Windows.Forms.Button showSelectedRow;
        private System.Windows.Forms.TextBox rowSelection;
        private System.Windows.Forms.Label label1;
    }
}

