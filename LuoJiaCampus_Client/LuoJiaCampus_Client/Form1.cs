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
    public partial class Form1 : Form
    {
        public bool on_off { get; set; }
        public long ID { get; set; }
        public Form1() { }
        public Form1(long id):this()
        {
            this.ID = id;
            on_off = false;
            InitializeComponent();
        }
        private void Openchildform(Form childform)
        {
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            Controls.Clear();
            Controls.Add(childform);
            Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            User user = new User();
            user = user.queryId(ID);
            if (!on_off)
            {
                this.button1.BackgroundImage = global::STUDENTINFO.Properties.Resources.kai;
                this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                this.on_off = true;
                request.campuswifi_on(user.Token);
            }
            else
            {
                this.button1.BackgroundImage = global::STUDENTINFO.Properties.Resources.guan;
                this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                this.on_off = false;
                request.campuswifi_off(user.Token);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Openchildform(new ToolboxForm(ID));
        }
    }
}
