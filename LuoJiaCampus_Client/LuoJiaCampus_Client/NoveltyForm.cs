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

namespace STUDENTINFO
{
    public partial class NoveltyForm : Form
    {
        private List<News> news = new List<News>();
        private List<string> Word = new List<string>();

        public NoveltyForm()
        {
            InitializeComponent();
            iniData();
            iniWindow();
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
            //滚动条
            this.panel1.AutoScroll = true;
            this.panel2.AutoScroll = true;
        }

        public void iniData()
        {
            news.Add(new News
            {
                id = 1,
                commentNum = 10,
                createdTime = "2020/6/2",
                rates = 50,
                text = "虽然时常感到无助，但是总有人会逗我开心。让我敞开心扉",
                type = "0",
                userid = 1
            });
            news.Add(new News
            {
                id = 1,
                commentNum = 10,
                createdTime = "2020/6/2",
                rates = 100,
                text = "快要期末考了，但是DDL好多啊",
                type = "0",
                userid = 1
            });
            news.Add(new News
            {
                id = 1,
                commentNum = 10,
                createdTime = "2020/6/2",
                rates = 100,
                text = "来日方长，要在不慌不忙中学会坚强",
                type = "0",
                userid = 1
            });
            news.Add(new News
            {
                id = 2,
                commentNum = 0,
                createdTime = "2020/6/3",
                rates = 10,
                text = "下学期一定好好做人！！",
                type = "0",
                userid = 2
            });
            news.Add(new News
            {
                id = 3,
                commentNum = 0,
                createdTime = "2020/6/3",
                rates = 10,
                text = "这个年纪的人，谁心里不是装过别人的人。所以我羡慕，那些青梅竹马容一而终的恋人。至少\r\n他们的世界只有彼此。不会有前任初恋新欢",
                type = "0",
                userid = 3
            });
            news.Add(new News
            {
                id = 4,
                commentNum = 10,
                createdTime = "2020/6/3",
                rates = 10,
                text = "在信操捡到一把钥匙，请丢了钥匙的同学到教务处认领哦",
                type = "1",
                userid = 4
            });
            news.Add(new News
            {
                id = 5,
                commentNum = 11,
                createdTime = "2020/6/4",
                rates = 11,
                text = "捡到一张武汉通，丢了武汉通的同学可以联系我135xxxxxxxx",
                type = "1",
                userid = 5
            });
            news.Add(new News
            {
                id = 6,
                commentNum = 11,
                createdTime = "2020/6/4",
                rates = 11,
                text = "紧急通知:信部宿舍6月5日早八点到晚八点停水，请互相转告",
                type = "2",
                userid = 6
            });
            news.Add(new News
            {
                id = 7,
                commentNum = 11,
                createdTime = "2020/6/4",
                rates = 11,
                text = "紧急通知:因校长心情不好，放长假7天，请互相转告",
                type = "2",
                userid = 7
            });
        }
        public void iniWindow()
        {
            #region 获取树洞信息
            List<News> FreeData = news.Where(q => q.type == "0").ToList();

            int x = 10;
            int y = 45;

            panel1.Controls.Add(PictureBox("1.jpg", 10, 0, 40, 40));
            panel1.Controls.Add(Label(FreeData[0].userid.ToString(), x + 60, y - 25, 30, 15));

            foreach (var item in FreeData)
            {
                panel1.Controls.Add(Label(item.text.ToString(), x, y, 500, 32));
                panel1.Controls.Add(Button("赞" + item.rates.ToString(), "zan.ico", x, y + 35, 80, 30));
                panel1.Controls.Add(Button(item.commentNum == 0 ? "评论" : item.commentNum.ToString(), "xinxi.ico", x + 300, y + 35, 80, 30));
                y += 120;
            }
            panel1.Controls.Add(Label("", x + 60, y, 30, 15));
            #endregion

            #region 失物招领
            List<News> MistakesAndFound = news.Where(q => q.type == "1").ToList();
            int xx = 10;
            int yy = 45;

            panel2.Controls.Add(PictureBox("1.jpg", 10, 0, 40, 40));
            panel2.Controls.Add(Label(FreeData[0].userid.ToString(), xx + 60, yy - 25, 30, 15));

            foreach (var item in MistakesAndFound)
            {
                panel2.Controls.Add(Label(item.text.ToString(), xx, yy, 500, 32));
                panel2.Controls.Add(Button("赞" + item.rates.ToString(), "zan.ico", xx, yy + 35, 80, 30));
                panel2.Controls.Add(Button(item.commentNum == 0 ? "评论" : item.commentNum.ToString(), "xinxi.ico", xx + 300, yy + 35, 80, 30));
                yy += 120;
            }
            panel2.Controls.Add(Label("", xx + 60, yy, 30, 15));
            #endregion

            #region 公告
            List<News> Notice = news.Where(q => q.type == "2").ToList();

            #endregion
        }
        private PictureBox PictureBox(string pathName, int x, int y, int sizeX, int sizeY)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictureBox.Location = new Point(x, y);
            pictureBox.Size = new Size(sizeX, sizeY);
            pictureBox.Image = Image.FromFile(pathName);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            return pictureBox;
        }

        private Label Label(string content, int x, int y, int sizeX, int sizeY)
        {
            Label label = new Label();
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label.Text = content;
            label.Location = new Point(x, y);
            label.Size = new Size(sizeX, sizeY);
            label.Font = new Font("微软雅黑", 9);
            label.ForeColor = Color.Black;
            label.AutoSize = false;
            label.Parent = this;
            return label;
        }

        private Button Button(string content, string path, int x, int y, int sizeX, int sizeY)
        {
            Button button = new Button();
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            button.Text = content;
            button.ImageAlign = ContentAlignment.BottomLeft;
            button.Image = Image.FromFile(path);
            button.Location = new Point(x, y);
            button.Size = new Size(sizeX, sizeY);
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.Brown;
            button.Click += Button_Click;
            button.Font = new Font("微软雅黑", 9);
            button.FlatAppearance.BorderColor = Color.Brown;
            button.Parent = this;
            return button;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button _button = (Button)sender;
            //赞
            if (_button.Text.Contains("赞"))
            {
                Word.Add(news[0].userid.ToString() + "于\t\t" + DateTime.Now.ToString() + "\t\t赞了你");
                _button.Text = "赞" + (int.Parse(_button.Text.Substring(1)) + 1).ToString();
            }
            else //评论  
            {
                Word.Add(news[0].userid.ToString() + "于\t\t" + DateTime.Now.ToString() + "\t\t评论了你");
                Openchildform(new CommentForm(new List<string>() { "1于2020\\6\\3 加油", "2于2020\\6\\3 要加油啊", "3于2020\\6\\3 我学不完了" }));
            }
            //else if (_button.Text.Contains("评论"))
            //{
            //    Word.Add(news[0].userid.ToString() + "于\t\t" + DateTime.Now.ToString() + "\t\t评论了你");
            //    _button.Text = "0";
            //}
            //else
            //{
            //    Word.Add(news[0].userid.ToString() + "于\t\t" + DateTime.Now.ToString() + "\t\t评论了你");
            //    _button.Text = (int.Parse(_button.Text) + 1).ToString();
            //}
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

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Openchildform(new WordForm(Word, 0));
        }

        //记录
        private void button1_Click(object sender, EventArgs e)
        {
            Openchildform(new RecordForm(0));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Openchildform(new RecordForm(1));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Openchildform(new WordForm(Word, 1));
        }
    }
}
