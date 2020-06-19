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
                newnews = new News(textBox2.Text, "0", ID);
                newnews.Add(newnews);
                textBox2.Text = null;
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
            try
            {
                newnews = new News(textBox1.Text, "1", ID);
                newnews.Add(newnews);
                textBox1.Text = null;
                news = newnews.Query();
                iniWindow();
            }
            catch (Exception a)
            {
                MessageBox.Show("输入值为空");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Openchildform(new WordForm(ID,"1"));
        }


    }
}
