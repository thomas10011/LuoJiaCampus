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
    public partial class RecordForm : Form
    {
        int De = 0;
        public RecordForm(int x)
        {
            InitializeComponent();
            De = x;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //De = 0树洞 De = 1新鲜事
            if(De == 0)
            {

            }
            else
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
