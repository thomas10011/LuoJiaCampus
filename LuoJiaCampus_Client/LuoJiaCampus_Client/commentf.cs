using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using compusDBManage;

namespace STUDENTINFO
{

    public partial class commenf : Form
    {

        public Comment comment = new Comment();
        public commenf() { }
        public commenf(Comment a)
        {
            InitializeComponent();
            this.textBox1.Text = a.text;
            User user = new User();
            var db = new compusDB();
            this.textBox2.Text = user.queryId(a.userid).nmae.ToString() + a.userid;
            this.label2.Text = a.createdTime;

        }
    }
}
