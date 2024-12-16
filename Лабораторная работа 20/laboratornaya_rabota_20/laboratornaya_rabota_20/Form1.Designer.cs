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
            this.lineSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.Location = new System.Drawing.Point(12, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(1019, 430);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // showAllRows
            // 
            this.showAllRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.showAllRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showAllRows.Location = new System.Drawing.Point(162, 89);
            this.showAllRows.Name = "showAllRows";
            this.showAllRows.Size = new System.Drawing.Size(175, 57);
            this.showAllRows.TabIndex = 1;
            this.showAllRows.Text = "Показать все ряды номограммы";
            this.showAllRows.UseVisualStyleBackColor = false;
            this.showAllRows.Click += new System.EventHandler(this.showAllRows_Click);
            // 
            // showSelectedRow
            // 
            this.showSelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.showSelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showSelectedRow.Location = new System.Drawing.Point(161, 89);
            this.showSelectedRow.Name = "showSelectedRow";
            this.showSelectedRow.Size = new System.Drawing.Size(192, 57);
            this.showSelectedRow.TabIndex = 2;
            this.showSelectedRow.Text = "Показать выбранный ряд номограммы";
            this.showSelectedRow.UseVisualStyleBackColor = false;
            this.showSelectedRow.Click += new System.EventHandler(this.showSelectedRow_Click);
            // 
            // lineSelector
            // 
            this.lineSelector.FormattingEnabled = true;
            this.lineSelector.Location = new System.Drawing.Point(161, 41);
            this.lineSelector.Name = "lineSelector";
            this.lineSelector.Size = new System.Drawing.Size(192, 24);
            this.lineSelector.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(137, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбрать ряд номограммы";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showAllRows);
            this.groupBox1.Location = new System.Drawing.Point(12, 448);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 183);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.showSelectedRow);
            this.groupBox2.Controls.Add(this.lineSelector);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(523, 448);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 183);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // laboratornaya_rabota_20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1043, 643);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainChart);
            this.Name = "laboratornaya_rabota_20";
            this.Text = "Задание №20 выполнил: Баранов А.А., номер варианта: 7, дата выполнения: 09.12.202" +
    "4";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button showAllRows;
        private System.Windows.Forms.Button showSelectedRow;
        private System.Windows.Forms.ComboBox lineSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

