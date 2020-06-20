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
    
    public partial class CommentForm : Form
    {
        private long ID { get; set; }
        private News News = new News();
        private List<Comment> comments = new List<Comment>();
        
        public CommentForm(News news,long id)
        {
            this.ID = id;
            this.News = news;
            InitializeComponent();
            this.SizeChanged += new Resize(this).Form1_Resize;
            Comment comment = new Comment();
            this.panel1.Controls.Clear();
            comments = comment.queryNewId(news.id);
            foreach (var item in comments)
            {
                commenf childform = new commenf(item);
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Top;
                panel1.Controls.Add(childform);
                childform.BringToFront();
                childform.Show();
            }
        }

        //public void Dat()
        //{
        //    int x = 10;
        //    int y = 50;

        //    foreach (var item in data)
        //    {
        //        panel1.Controls.Add(Label(item, x, y, 500, 40));
        //        y += 40;
        //    }
        //}

        //添加评论
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    data.Add("1于" + DateTime.Now.ToString() + "评论: " + textBox1.Text);
        //    Dat();
        //}

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
            News = News.QueryId(News.id);
            Openchildform(new NEWsForm(News,ID));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
            {

                Comment comment1 = new Comment(textBox1.Text, News.id, ID);

                comment1.Add(comment1);
                this.panel1.Controls.Clear();
                comments = comment1.queryNewId(News.id);

                foreach (var item in comments)

                {

                    commenf childform = new commenf(item);

                    childform.TopLevel = false;

                    childform.FormBorderStyle = FormBorderStyle.None;

                    childform.Dock = DockStyle.Top;

                    panel1.Controls.Add(childform);

                    childform.BringToFront();

                    childform.Show();

                }
                this.textBox1.Text = null;
            }
        }
    }
    public class Resize
    {
        private Form _form;

        public Resize(Form form)
        {
            int count = form.Controls.Count * 2 + 2;
            float[] factor = new float[count];
            int i = 0;
            factor[i++] = form.Size.Width;
            factor[i++] = form.Size.Height;
            foreach (Control ctrl in form.Controls)
            {
                factor[i++] = ctrl.Location.X / (float)form.Size.Width;
                factor[i++] = ctrl.Location.Y / (float)form.Size.Height;
                ctrl.Tag = ctrl.Size;
            }
            form.Tag = factor;
            this._form = form;
        }

        public void Form1_Resize(object sender, EventArgs e)
        {
            try { float[] scale = (float[])this._form.Tag; 
            
            int i = 2;
            foreach (Control ctrl in this._form.Controls) //panel的长宽增长到一个固定的值就不会再增长了，原因：Panel的宽和高上限是65535像素（https://blog.csdn.net/dufangfeilong/article/details/41805073?utm_source=blogxgwz5）
            {
                ctrl.Left = (int)(this._form.Size.Width * scale[i++]);
                ctrl.Top = (int)(this._form.Size.Height * scale[i++]);
                ctrl.Width = (int)(this._form.Size.Width / (float)scale[0] * ((Size)ctrl.Tag).Width);
                ctrl.Height = (int)(this._form.Size.Height / (float)scale[1] * ((Size)ctrl.Tag).Height);
            }
            }
            catch (Exception a) { }
        }
    }
}
