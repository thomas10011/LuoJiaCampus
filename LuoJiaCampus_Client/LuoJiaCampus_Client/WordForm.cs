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
    public partial class WordForm : Form
    {
        private long ID { set; get; }
        private List<News> news = new List<News>();
        public WordForm()
        {
            InitializeComponent();
        }
        public WordForm(long id,string type):this()
        {
            this.ID = id;
            News newnews = new News();
            news = newnews.QueryUserId(id);
            news = news.Where(q => q.type == type).ToList();
            this.panel1.Controls.Clear();
            foreach (var item in news)
            {
                NEWsForm childform = new NEWsForm(item, ID);
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Top;
                this.panel1.Controls.Add(childform);
                childform.BringToFront();
                childform.Show();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Openchildform(new NoveltyForm(ID));
        }
    }
}
