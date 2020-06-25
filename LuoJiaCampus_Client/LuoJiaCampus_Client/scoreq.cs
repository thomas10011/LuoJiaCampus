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
    public partial class scoreq : Form
    {
        List<CourseScore> Data1 = new List<CourseScore>();
        public scoreq()
        {
            InitializeComponent();
            CourseScore a = new CourseScore();
            this.Data1 = a.Query();
            paint_pie(Data1);
        }
        public void paint_pie(List<CourseScore> b )
        {
            panel2.Controls.Clear();
            foreach (CourseScore a in b)
            {
                scorequrry childform = new scorequrry(a);
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Top;
                panel2.Controls.Add(childform);
                childform.BringToFront();
                childform.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CourseScore a = new CourseScore();
            Data1 = new List<CourseScore>();
            this.Data1 = a.Query1(textBox1.Text);
            this.textBox1.Text = null;
            paint_pie(Data1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CourseScore a = new CourseScore();
            Data1 = new List<CourseScore>();
            this.Data1 = a.Query2(textBox2.Text);
            this.textBox2.Text = null;
            paint_pie(Data1);
        }
    }
}
