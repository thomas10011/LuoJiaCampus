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

namespace STUDENTINFO
{
    public partial class LoadForm : Form
    {
        public long ID { get; set; }
        public string password { get; set; }
        public string portalpwd { get; set; }
        public string token { get; set; }
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
        public static class Util
        {
            /// <summary>
            /// Sets the cert policy.
            /// </summary>
            public static void SetCertificatePolicy()
            {
                ServicePointManager.ServerCertificateValidationCallback
                           += RemoteCertificateValidate;
            }

            /// <summary>
            /// Remotes the certificate validate.
            /// </summary>
            private static bool RemoteCertificateValidate(
               object sender, X509Certificate cert,
                X509Chain chain, SslPolicyErrors error)
            {
                // trust any certificate!!!
                System.Console.WriteLine("Warning, trust any certificate");
                return true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Encoding myEncoding = Encoding.GetEncoding("gb2312");  //选择编码字符集
            string data = "{ \"id\":"+ID+",\"password\":\""+ password + "\",\"portalpwd\":\""+ portalpwd + "\"}";  //要上传到网页系统里的数据（字段名=数值 ，用&符号连接起来）
            byte[] bytesToPost = System.Text.Encoding.Default.GetBytes(data); //转换为bytes数据
            string responseResult = String.Empty;
            Util.SetCertificatePolicy();
            HttpWebRequest req = (HttpWebRequest)
            HttpWebRequest.Create("https://localhost:5001/Authenticate/login");   //创建一个有效的httprequest请求，地址和端口和指定路径必须要和网页系统工程师确认正确，不然一直通讯不成功
            req.Method = "POST";
            req.Accept = "HTTP";
            req.ContentType =
            "application/json";
            req.ContentLength = bytesToPost.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bytesToPost, 0, bytesToPost.Length);     //把要上传网页系统的数据通过post发送
            }
            HttpWebResponse cnblogsRespone = null;
            try { cnblogsRespone = (HttpWebResponse)req.GetResponse(); }
            catch (WebException ex)
            {
                this.warn.Visible = true;
            }
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                    this.token = responseResult;
                    MessageBox.Show(responseResult);//网页系统的json格式的返回值，在responseResult里，具体内容就是网页系统负责工程师跟你协议号的返回值协议内容
                }
                sr.Close();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
                cnblogsRespone.Close();
            }


        }   
    }
}
