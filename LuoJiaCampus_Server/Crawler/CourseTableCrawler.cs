using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Reflection.Metadata;
using System.Net;
using System;
using System.Net.Http;
using AngleSharp.Html.Parser;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.IO;

namespace LuoJiaCampus_Server.jw_Crawler {
    
    public class CourseTableCrawler {
        public static string loginPage = @"https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html%3Fbrowser%3Dno";
        // public static string
        public static string lt = null;
        public static string dllt = null;
        public static string execution = null;
        public static string _eventId = null;
        public static string rmShown = null;
        public static string dynamicPwdEncryptSalt = null;

        public static string route = null;
        public static string JSESSIONID = null;

        // 静态变量client
        private static readonly HttpClientHandler handler = new HttpClientHandler {
            AllowAutoRedirect = true,
            UseCookies = true
        };
        private static readonly HttpClient client = new HttpClient(handler);
        private static readonly HtmlParser parser = new HtmlParser();
        
        

        // 获取登录页面的相关信息
        public static void initAttributes() {
            client.DefaultRequestHeaders.Clear();

            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            // 首先拿到route和JSESSIONID
            HttpResponseMessage res = client.GetAsync("https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html").Result;
            
            CookieCollection cookies = handler.CookieContainer.GetCookies(new Uri(loginPage));
            foreach(Cookie ck in cookies) {
                Console.WriteLine("cookie: " + ck.Value);
            }
            route = cookies.First().ToString();
            JSESSIONID = cookies.Last().ToString();
            
            var resStr = res.Content.ReadAsStreamAsync().Result;
            try {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = new HtmlDocument();
                Console.WriteLine(resStr);
                doc.Load(resStr);

                HtmlNode node;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='lt']");
                CourseTableCrawler.lt = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='dllt']");
                CourseTableCrawler.dllt = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='execution']");
                CourseTableCrawler.execution = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='_eventId']");
                CourseTableCrawler._eventId = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='rmShown']");
                CourseTableCrawler.rmShown = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@id='pwdDefaultEncryptSalt']");
                CourseTableCrawler.dynamicPwdEncryptSalt = node.Attributes["value"].Value;
                Console.WriteLine(lt);
                Console.WriteLine(dllt);
                Console.WriteLine(execution);
                Console.WriteLine(_eventId);
                Console.WriteLine(rmShown);
                Console.WriteLine(dynamicPwdEncryptSalt);
            }
            catch (Exception e) {
                Console.WriteLine(e.InnerException.Message);
            }

        }

        // 传入学号和加密过的信息门户密码
        public static void login(long userid, string portalPwd) {

            client.DefaultRequestHeaders.Clear();

            // 设置请求头信息
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Encoding",
                "gzip, deflate, br"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Cache-Control",
                "max-age=0"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Connection",
                "keep-alive"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Host",
                "cas.whu.edu.cn"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Origin",
                "https://cas.whu.edu.cn"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html%3Fbrowser%3Dno"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Dest",
                "document"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Mode",
                "navigate"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Site",
                "same-origin"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-User",
                "?1"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            CourseTableCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );
            
            
            // 构造post参数
            HttpContent postBody = new FormUrlEncodedContent(
                new Dictionary<string, string>() {
                    {"username", userid.ToString()},
                    {"password", portalPwd},
                    {"lt", CourseTableCrawler.lt},
                    {"dllt", CourseTableCrawler.dllt},
                    {"execution", CourseTableCrawler.execution},
                    {"_eventId", CourseTableCrawler._eventId},
                    {"rmShown", CourseTableCrawler.rmShown}
                }
            );
            
            HttpResponseMessage response = client.PostAsync(loginPage, postBody).Result;
            Console.WriteLine($"return status: {response.StatusCode}");
            CookieCollection cookies = handler.CookieContainer.GetCookies(new Uri(loginPage));
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
            }

            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }
            
        
        }
        
        // 试一下另一种方法
        public static void login_webreq(long userid, string portalPwd) {
            Console.WriteLine("passwrod is :" + portalPwd);
            Console.WriteLine($"route: {route}, jsessionid: {JSESSIONID}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginPage);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Headers.Add(
                "Accept-Encoding",
                "gzip, deflate, br"
            );
            request.Headers.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            request.Headers.Add(
                "Cache-Control",
                "max-age=0"
            );
            request.Headers.Add(
                "Cookie",
                // "route=8c7076a82edeaa59289b09897f5abc7c; JSESSIONID=q6pqZeU1LL-ASIy85DiBhMm4BGRTJRFJ-FYfh8mkbiKJhmRISutK!-195412049"
                route + "; " + JSESSIONID
            );
            request.Headers.Add(
                "Host",
                "cas.whu.edu.cn"
            );
            request.Headers.Add(
                "Origin",
                "https://cas.whu.edu.cn"
            );
            request.Headers.Add(
                "Referer",
                "https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html%3Fbrowser%3Dno"
            );
            request.Headers.Add(
                "Sec-Fetch-Dest",
                "document"
            );
            request.Headers.Add(
                "Sec-Fetch-Mode",
                "navigate"
            );
            request.Headers.Add(
                "Sec-Fetch-Site",
                "same-origin"
            );
            request.Headers.Add(
                "Sec-Fetch-User",
                "?1"
            );
            request.Headers.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            // 打印请求头
            foreach(string k in request.Headers.AllKeys) {
                var value = request.Headers.GetValues(k);
                Console.WriteLine("request header: " + k);
                foreach(string t in value) {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }

            var postData = "username=" + userid.ToString();
            postData += "&password=" + portalPwd;
            postData += "&lt=" + CourseTableCrawler.lt;
            postData += "&dllt=" + CourseTableCrawler.dllt;
            postData += "&execution=" + CourseTableCrawler.execution;
            postData += "&_eventId=" + CourseTableCrawler._eventId;
            postData += "&rmShown=" + CourseTableCrawler.rmShown;

            var data = Encoding.UTF8.GetBytes(postData);
            using(Stream reqStream = request.GetRequestStream()) {
                reqStream.Write(data, 0, data.Length);
            }

            request.ContentLength = data.Length;        // 设置消息内容的长度

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusCode);
            foreach(string k in response.Headers.AllKeys) {
                Console.WriteLine($"key: {k},  value: {response.Headers.GetValues(k).FirstOrDefault()}");
            }
            var responseStr = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseStr);
        }


    }

    
}