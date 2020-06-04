using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace STUDENTINFO
{
    public partial class MainFrm : Form
    {
        public long ID { get; set; }
        public String sname { get; set; }
        public String sno { get; set; }
        public String scollege { get; set; }
        public Bitmap bitmap { get; set; }
        private IconButton currentBtn;
        private Panel leftBorderBton;
        private Form currentchildform;

        public MainFrm()
        {
            sname = "某某某";sno = "2018302110xxx";scollege = "计算机学院";
            byte[] imageArray = System.IO.File.ReadAllBytes("touxiang.png");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            bitmap =  new Bitmap(Bitmap.FromStream(new MemoryStream(Convert.FromBase64String(base64ImageRepresentation))));
            InitializeComponent();
            leftBorderBton = new Panel();
            MenuPanel.Controls.Add(leftBorderBton);
            //form
            this.Text = String.Empty;
            this.DoubleBuffered = true;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //数据绑定
            namebox.DataBindings.Add("Text", this, "sname");
            numberbox.DataBindings.Add("Text", this, "sno");
            collegebox.DataBindings.Add("Text", this, "scollege");
            picture.DataBindings.Add("Image", this, "bitmap");
        }
        public MainFrm(long ID) : this()
        {
            Get_info(ID);
        }
        private struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(253,138,114);
            public static Color color3 = Color.FromArgb(24, 165,251);
        }
        //连接数据库获取当前学生姓名、学号、学院、头像
        private void Get_info(long ID)
        {

        }
        //菜单按钮
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisiableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //
                leftBorderBton.Size = new Size(7, currentBtn.Size.Height);
                leftBorderBton.BackColor = color;
                leftBorderBton.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBton.Visible = true;
                leftBorderBton.BringToFront();
            }

        }
        private void DisiableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = this.BackColor;
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                //
            }
        }

        private void Openchildform(Form childform)
        {
            if (currentchildform != null)
            {
                currentchildform.Close(); 
            }
            currentchildform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            childformdesk.Controls.Add(childform);
            childformdesk.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }

        private void picture_Click(object sender, EventArgs e)
        {
            DisiableButton();
            Openchildform(new Form());
        }
        private void courceButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            //课程表
            Openchildform(new Form());
        }

        private void wordButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
            //新鲜事
            Openchildform(new Form());
        }

        private void toolButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            //工具箱
            Openchildform(new ToolboxForm());
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg,int wParam,int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }
}
