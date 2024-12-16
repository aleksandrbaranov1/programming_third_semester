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
            this.listOfChildren = new System.Windows.Forms.ListBox();
            this.selectGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownAge = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTeachers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).BeginInit();
            this.SuspendLayout();
            // 
            // listOfChildren
            // 
            this.listOfChildren.FormattingEnabled = true;
            this.listOfChildren.ItemHeight = 16;
            this.listOfChildren.Location = new System.Drawing.Point(448, 29);
            this.listOfChildren.Name = "listOfChildren";
            this.listOfChildren.Size = new System.Drawing.Size(480, 356);
            this.listOfChildren.TabIndex = 0;
            // 
            // selectGroup
            // 
            this.selectGroup.FormattingEnabled = true;
            this.selectGroup.Location = new System.Drawing.Point(36, 83);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(143, 24);
            this.selectGroup.TabIndex = 1;
            this.selectGroup.SelectedIndexChanged += new System.EventHandler(this.selectGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбрать группу";
            // 
            // numericUpDownAge
            // 
            this.numericUpDownAge.Location = new System.Drawing.Point(36, 160);
            this.numericUpDownAge.Name = "numericUpDownAge";
            this.numericUpDownAge.Size = new System.Drawing.Size(143, 22);
            this.numericUpDownAge.TabIndex = 3;
            this.numericUpDownAge.ValueChanged += new System.EventHandler(this.numericUpDownAge_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать возраст";
            // 
            // comboBoxTeachers
            // 
            this.comboBoxTeachers.FormattingEnabled = true;
            this.comboBoxTeachers.Location = new System.Drawing.Point(36, 241);
            this.comboBoxTeachers.Name = "comboBoxTeachers";
            this.comboBoxTeachers.Size = new System.Drawing.Size(143, 24);
            this.comboBoxTeachers.TabIndex = 5;
            this.comboBoxTeachers.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeachers_SelectedIndexChanged);
            // 
            // laboratornaya_rabota_19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 529);
            this.Controls.Add(this.comboBoxTeachers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownAge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectGroup);
            this.Controls.Add(this.listOfChildren);
            this.Name = "laboratornaya_rabota_19";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listOfChildren;
        private System.Windows.Forms.ComboBox selectGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTeachers;
    }
}

