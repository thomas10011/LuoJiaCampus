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
    public partial class CommentForm : Form
    {
        List<string> data = new List<string>();
        public CommentForm(List<string> CommentData)
        {
            InitializeComponent();
            data = CommentData;
            Dat();
        }

        public void Dat()
        {
            int x = 10;
            int y = 50;

            foreach (var item in data)
            {
                panel1.Controls.Add(Label(item, x, y, 500, 40));
                y += 40;
            }
        }

        //添加评论
        private void button1_Click(object sender, EventArgs e)
        {
            data.Add("1于" + DateTime.Now.ToString() + "评论: " + textBox1.Text);
            Dat();
        }

        private Label Label(string content, int x, int y, int sizeX, int sizeY)
        {
            Label label = new Label();
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label.Text = content;
            label.Location = new Point(x, y);
            label.Size = new Size(sizeX, sizeY);
            label.Font = new Font("微软雅黑", 12);
            label.ForeColor = Color.Black;
            label.AutoSize = false;
            label.Parent = this;
            return label;
        }

        public Form form = new Form();
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
            this.Controls.Clear();
            this.Controls.Add(childform);
            Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        //返回
        private void button2_Click(object sender, EventArgs e)
        {
            Openchildform(new NoveltyForm());
        }
    }
}
