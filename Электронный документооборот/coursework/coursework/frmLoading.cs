using System.Windows.Forms;

namespace coursework
{
    public partial class frmLoading : Form
    {
        public frmLoading()
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
