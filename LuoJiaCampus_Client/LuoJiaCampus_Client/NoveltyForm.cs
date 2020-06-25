using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using compusDBManage;
using System.Drawing.Drawing2D;

namespace STUDENTINFO
{
    public partial class NoveltyForm : Form
    {
        public long ID { get; set; }
        private News newnews = new News();
        private List<News> news = new List<News>();
        private List<string> Word = new List<string>();
        public NoveltyForm()
        {
            InitializeComponent();
            news = newnews.Query();            
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
            //滚动条
            this.panel1.AutoScroll = true;
            this.panel2.AutoScroll = true;
        }
        public NoveltyForm(long id) : this()
        {
            this.ID = id;
            iniWindow();
        }

        public void iniWindow()
        {
            #region 获取树洞信息
            List<News> FreeData = news.Where(q => q.type == "0").ToList();
            panel1.Controls.Clear();

            //panel1.Controls.Add(Label(FreeData[0].userid.ToString(), x + 60, y - 25, 30, 15));

            foreach (var item in FreeData)
            {
                NEWsForm childform = new NEWsForm(item,ID);
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Top;
                panel1.Controls.Add(childform);
                childform.BringToFront();
                childform.Show();
            }
            #endregion

            #region 失物招领
            List<News> MistakesAndFound = news.Where(q => q.type == "1").ToList();
            panel2.Controls.Clear();
            foreach (var item in MistakesAndFound)
            {
                NEWsForm childform = new NEWsForm(item,ID);
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Top;
                panel2.Controls.Add(childform);
                childform.BringToFront();
                childform.Show();
            }
            #endregion

            #region 公告
            List<News> Notice = news.Where(q => q.type == "2").ToList();

            #endregion
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region TabControl 外观
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new SolidBrush(Color.White);
                bshFore = new SolidBrush(ColorTranslator.FromHtml("#23459C"));
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(ColorTranslator.FromHtml("#23459C"));
                bshFore = new SolidBrush(Color.White);
            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            sftTab.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
            #endregion 
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



        private void button2_Click(object sender, EventArgs e)
        {
            Openchildform(new WordForm(ID,"0"));
        }

        //记录
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                newnews = new News(richTextBox1.Rtf, "0", ID);
                newnews.Add(newnews);
                richTextBox1.Text = null;
                news = newnews.Query();
                iniWindow();
            }
            catch(Exception a)
            {
                MessageBox.Show("输入值为空");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

                newnews = new News(richTextBox2.Rtf, "1", ID);
                newnews.Add(newnews);
                richTextBox2.Text = null;
                news = newnews.Query();
                iniWindow();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Openchildform(new WordForm(ID,"1"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!height1) panel3.Size = new Size(panel3.Size.Width, panel3.Size.Height + 100);
            height1 = true;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片文件|*.jpg|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                Bitmap bitmap = new Bitmap(img);
                Clipboard.SetDataObject(resizeImage(bitmap, new Size(150,150)), false);
                richTextBox1.Paste();
            }
        }
        private static Image resizeImage(Image imgToResize, Size size)
        {
            //获取图片宽度
            int sourceWidth = imgToResize.Width;
            //获取图片高度
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
        private bool height1 = false;
        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!height1) panel3.Size = new Size(panel3.Size.Width, panel3.Size.Height + 100);
            height1 = true;
        }

        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            if (height1) panel3.Size = new Size(panel3.Size.Width, panel3.Size.Height - 100);
            height1 = false;
        }
    }
}
