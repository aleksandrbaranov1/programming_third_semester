using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD:Электронный документооборот/coursework/coursework/Program.cs
            Application.Run(new mainForm());
=======
            Application.Run(new frmMain());
>>>>>>> fc81575d189eb02a5c0f8be11cad6c5fe7bfda51:coursework/coursework/Program.cs
        }
    }
}
