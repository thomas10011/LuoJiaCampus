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
using System.Runtime.InteropServices;

namespace STUDENTINFO
{
    public partial class NEWsForm : Form
    {
        public long ID { set; get; }
        public News news = new News();
        public NEWsForm()
        {
            this.TopLevel = false;
            InitializeComponent();
        }
        public NEWsForm(News a,long id) : this()
        {
            this.ID = id;
            this.news = a;
            this.label1.Text = a.commentNum.ToString();
            this.label2.Text = a.rates.ToString();
            this.richTextBox1.Rtf = a.text.ToString();
            User user = new User();
            if (a.type=="1") this.textBox2.Text = user.queryId(a.userid).nmae.ToString()+ a.userid;
            else this.textBox2.Text = a.id.ToString();
            this.label2.DataBindings.Add("Text", news, "rates");
            this.label1.DataBindings.Add("Text", news, "commentNum");
        }
        private void Openchildform(Form childform)
        {
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.Controls.Add(childform);
            this.Tag = childform;
            childform.SendToBack();
            childform.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            //foreach (Control a in Parent.Controls)
            //{
            //    if (a.Name!=this.Name) this.Parent.Controls.Remove(a);
            //}
            this.Controls.Clear();
            this.Openchildform(new CommentForm(news,ID));
            this.Dock = DockStyle.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.news.rates += 1;
            news.addRates(this.news.id);
            this.label2.Text = (Int32.Parse(this.label2.Text) + 1).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片文件|*.jpg|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetDataObject(Image.FromFile(openFileDialog1.FileName), false);
                richTextBox1.Paste();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
