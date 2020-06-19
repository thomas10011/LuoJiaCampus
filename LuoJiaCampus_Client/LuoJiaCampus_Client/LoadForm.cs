using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using compusDBManage;

namespace STUDENTINFO
{
    public partial class LoadForm : Form
    {
        public long ID { get; set; }
        public string password { get; set; }
        public string portalpwd { get; set; }
        public string token { get; set; }
        public Request request { get; set; }
        public LoadForm()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", this, "ID");
            textBox2.DataBindings.Add("Text", this, "portalpwd");
            
            textBox3.DataBindings.Add("Text", this, "password");
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            request = new Request(ID.ToString(), password, portalpwd);
            if (!request.connect) this.warn.Visible = true;
            else
            {
                MessageBox.Show(request.usercourse);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
        }


    }
}
