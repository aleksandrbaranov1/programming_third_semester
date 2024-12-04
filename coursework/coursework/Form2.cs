using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
        }
        public void UpdateProgress(int value)
        {
            progressBar1.Value = value; // Установка значения прогресс-бара
        }
        public void CloseProgress()
        {
            this.Close(); // Закрытие формы
        }
    }
}
