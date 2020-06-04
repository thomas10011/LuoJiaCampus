using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUDENTINFO
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            LoadForm login = new LoadForm();

            //界面转换
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {            
                Application.Run(new MainFrm(login.ID));
                login.Dispose();
            }
            else if (login.DialogResult == DialogResult.Cancel)
            {
                login.Dispose();
                return;
            }

        }
    }
}
