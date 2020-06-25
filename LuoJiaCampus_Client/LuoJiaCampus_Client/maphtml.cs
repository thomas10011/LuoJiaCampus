using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUDENTINFO
{
    public partial class maphtml : Form
    {
        public maphtml()
        {
            InitializeComponent();
            webBrowser1.Navigate("ysfwzxxb.whu.edu.cn/student/index.html");
        }
    }
}
