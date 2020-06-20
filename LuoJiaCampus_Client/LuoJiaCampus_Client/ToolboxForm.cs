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
    public partial class ToolboxForm : Form
    {
        public Form form=new Form();
        long ID { get; set; }
        public ToolboxForm()
        {
            InitializeComponent();
        }
        public ToolboxForm(long id):this()
        {
            ID = id;
        }
        private void Openchildform(Form childform)
        {
            if (form != null)
            {
                form.Close();
            }
            form = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            Controls.Clear();
            Controls.Add(childform);
            Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void grade_Click(object sender, EventArgs e)
        {
            Openchildform(new GradeForm(ID));
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能待开发");
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能待开发");
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能待开发");
        }
    }
}
