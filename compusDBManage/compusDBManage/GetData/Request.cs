using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace compusDBManage
{
    public class Request
    {
        public long ID { get; set; }
        public string Token { get; set; }
        public string userinfo { get; set; }
        public string usercourse { get; set; }
        public string userscore { get; set; }
        public bool connect { get; set; }

        public Request() { }
        public Request(string a, string b, string c) : this()
        {
            if (connect = Post(a, b, c))
            {
                getCourse course = new getCourse(get_course(),Int64.Parse(a));
                getCourseScore coursescore = new getCourseScore(get_score());
                getUser user = new getUser(get_info());              
            };           
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

        public bool Post(string a, string b, string c)
        {
            Encoding myEncoding = Encoding.GetEncoding("gb2312");  //选择编码字符集
            string data = "{ \"id\":" + a + ",\"password\":\"" + b + "\",\"portalpwd\":\"" + c + "\"}";  //要上传到网页系统里的数据（字段名=数值 ，用&符号连接起来）
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
                return false;
            }
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                    this.Token = responseResult;
                    sr.Close();
                    cnblogsRespone.Close();
                    return true;//网页系统的json格式的返回值，在responseResult里，具体内容就是网页系统负责工程师跟你协议号的返回值协议内容
                }
            }
            return false;
        }

        public string get_info()
        {
            JObject jObject = (JObject)JsonConvert.DeserializeObject(Token);
            string token = (string)jObject["token"];
            Encoding myEncoding = Encoding.GetEncoding("gb2312");  //选择编码字符集
            string responseResult = String.Empty;
            HttpWebRequest req = (HttpWebRequest)
            HttpWebRequest.Create("https://localhost:5001/api/UserInfo");   //创建一个有效的httprequest请求，地址和端口和指定路径必须要和网页系统工程师确认正确，不然一直通讯不成功
            req.Method = "GET";
            req.Accept = "HTTP";
            req.Headers.Add("Authorization", "bearer " + token + "");
            req.ContentType =
            "application/json";
            HttpWebResponse cnblogsRespone = null;
            try { cnblogsRespone = (HttpWebResponse)req.GetResponse(); }
            catch (WebException ex)
            {

            }
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                    sr.Close();
                    cnblogsRespone.Close();
                    userinfo = responseResult;
                    JObject jobject = (JObject)JsonConvert.DeserializeObject(userinfo);
                    string ID1 = (string)jobject["id"];
                    this.ID = Int64.Parse(ID1);//网页系统的json格式的返回值，在responseResult里，具体内容就是网页系统负责工程师跟你协议号的返回值协议内容
                    return userinfo;
                }

            }
            else { return null; }
        }

        public string get_course()
        {
            JObject jObject = (JObject)JsonConvert.DeserializeObject(Token);
            string token = (string)jObject["token"];
            Encoding myEncoding = Encoding.GetEncoding("gb2312");  //选择编码字符集
            string responseResult = String.Empty;
            HttpWebRequest req = (HttpWebRequest)
            HttpWebRequest.Create("https://localhost:5001/api/coursetable");   //创建一个有效的httprequest请求，地址和端口和指定路径必须要和网页系统工程师确认正确，不然一直通讯不成功
            req.Method = "GET";
            req.Accept = "HTTP";
            req.Headers.Add("Authorization", "bearer " + token + "");
            req.ContentType =
            "application/json";
            HttpWebResponse cnblogsRespone = null;
            try { cnblogsRespone = (HttpWebResponse)req.GetResponse(); }
            catch (WebException ex)
            {

            }
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                    sr.Close();
                    cnblogsRespone.Close();
                    userinfo = responseResult;
                    JObject jobject = (JObject)JsonConvert.DeserializeObject(userinfo);
                    string ID1 = (string)jobject["id"];
                    this.ID = Int64.Parse(ID1);//网页系统的json格式的返回值，在responseResult里，具体内容就是网页系统负责工程师跟你协议号的返回值协议内容
                    return userinfo;
                }

            }
            else { return null; }
            
        }

        public string get_score()
        {
            JObject jObject = (JObject)JsonConvert.DeserializeObject(Token);
            string token = (string)jObject["token"];
            Encoding myEncoding = Encoding.GetEncoding("gb2312");  //选择编码字符集
            string responseResult = String.Empty;
            HttpWebRequest req = (HttpWebRequest)
            HttpWebRequest.Create("https://localhost:5001/api/coursescore");   //创建一个有效的httprequest请求，地址和端口和指定路径必须要和网页系统工程师确认正确，不然一直通讯不成功
            req.Method = "GET";
            req.Accept = "HTTP";
            req.Headers.Add("Authorization", "bearer " + token + "");
            req.ContentType =
            "application/json";
            HttpWebResponse cnblogsRespone = null;
            try { cnblogsRespone = (HttpWebResponse)req.GetResponse(); }
            catch (WebException ex)
            {
                return null;
            }
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                    sr.Close();
                    cnblogsRespone.Close();
                    userscore = responseResult;//网页系统的json格式的返回值，在responseResult里，具体内容就是网页系统负责工程师跟你协议号的返回值协议内容
                    return userscore;
                }
            }
            else { return null; }

        }
        public Request copy_request(Request b)
        {
            return b;
        }
    }

}



