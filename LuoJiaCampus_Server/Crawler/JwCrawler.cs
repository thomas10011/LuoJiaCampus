using System.Security.Claims;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Net.WebSockets;
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
    
    public class JwCrawler {
        public static string loginPage = @"https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html";
        public static string cas2jwPage = @"https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fbkjw.whu.edu.cn%2Fcommon%2Fcaslogin.jsp";
        public static string logoutPage = @"http://cas.whu.edu.cn/authserver/logout?service=http://ehall.whu.edu.cn/new/index.html";
        // public static string
        public static string lt = null;
        public static string dllt = null;
        public static string execution = null;
        public static string _eventId = null;
        public static string rmShown = null;
        public static string dynamicPwdEncryptSalt = null;

        public static string route = null;
        public static string JSESSIONID = null;

        public static string CASTGC = null;                     // 用于请求教务系统的JSESSIONID
        public static string iPlanetDirectoryPro = null;
        public static string csrftoken = null;

        // 静态变量client
        public static readonly HttpClientHandler handler = new HttpClientHandler {
            AllowAutoRedirect = true,
            UseCookies = true,
        };
        public static readonly HttpClient client = new HttpClient(handler);
        public static readonly HtmlParser parser = new HtmlParser();
        
        

        // 获取登录页面的相关信息
        public static void initAttributes() {
            client.DefaultRequestHeaders.Clear();
            // CookieContainer c = new CookieContainer();
            

            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            // 首先拿到route和JSESSIONID
            HttpResponseMessage res = client.GetAsync(loginPage).Result;
            
            CookieCollection cookies = handler.CookieContainer.GetCookies(new Uri(loginPage));
            foreach(Cookie ck in cookies) {
                Console.WriteLine("cookie: " + ck.Value);
            }
            route = cookies.First().ToString();     // 设置cookie的值
            JSESSIONID = cookies.Last().ToString();
            
            var resStr = res.Content.ReadAsStreamAsync().Result;
            try {
                
                HtmlDocument doc = new HtmlDocument();
                // Console.WriteLine(res.Content.ReadAsStringAsync().Result);
                doc.Load(resStr);
                

                HtmlNode node;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='lt']");
                JwCrawler.lt = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='dllt']");
                JwCrawler.dllt = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='execution']");
                JwCrawler.execution = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='_eventId']");
                JwCrawler._eventId = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@name='rmShown']");
                JwCrawler.rmShown = node.Attributes["value"].Value;
                node = doc.DocumentNode.SelectSingleNode("//input[@id='pwdDefaultEncryptSalt']");
                JwCrawler.dynamicPwdEncryptSalt = node.Attributes["value"].Value;
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
        public static bool login(long userid, string portalPwd) {
            /*--------------------------------先登录信息门户------------------------------------*/
            client.DefaultRequestHeaders.Clear();

            // 设置请求头信息
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Encoding",
                "gzip, deflate, br"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Cache-Control",
                "max-age=0"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Connection",
                "keep-alive"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Host",
                "cas.whu.edu.cn"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Origin",
                "https://cas.whu.edu.cn"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html%3Fbrowser%3Dno"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Dest",
                "document"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Mode",
                "navigate"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Site",
                "same-origin"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-User",
                "?1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );
            
            
            // 构造post参数
            HttpContent postBody = new FormUrlEncodedContent(
                new Dictionary<string, string>() {
                    {"username", userid.ToString()},
                    {"password", portalPwd},
                    {"lt", JwCrawler.lt},
                    {"dllt", JwCrawler.dllt},
                    {"execution", JwCrawler.execution},
                    {"_eventId", JwCrawler._eventId},
                    {"rmShown", JwCrawler.rmShown}
                }
            );
            
            HttpResponseMessage response = client.PostAsync(loginPage, postBody).Result;
            Console.WriteLine($"return status: {response.StatusCode}");
            if(response.StatusCode != HttpStatusCode.Redirect)
                return false;
            CookieCollection cookies = handler.CookieContainer.GetCookies(new Uri(loginPage));
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
            }
            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            /*-----------------------------------下面准备转到教务系统----------------------------------*/

            client.DefaultRequestHeaders.Clear();           // 准备重新构造请求头
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Encoding",
                "gzip, deflate, br"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Connection",
                "keep-alive"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Host",
                "cas.whu.edu.cn"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "http://ehall.whu.edu.cn/new/index.html?browser=no"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Dest",
                "document"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Mode",
                "navigate"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-Site",
                "cross-site"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Sec-Fetch-User",
                "?1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );

            response = client.GetAsync(cas2jwPage).Result;       // 发出请求
            Console.WriteLine($"return status: {response.StatusCode}");
            if(response.StatusCode != HttpStatusCode.Redirect)
                return false;
            cookies = handler.CookieContainer.GetCookies(new Uri(cas2jwPage));   // 拿到cookie打印看看
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                
            }
            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            string redirectStr = response.Headers.GetValues("Location").FirstOrDefault();  // 重定向地址
            Console.WriteLine("redirect to   " + redirectStr);


            client.DefaultRequestHeaders.Clear();           // 准备重新构造请求头
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Encoding",
                "gzip, deflate"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Connection",
                "keep-alive"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Host",
                "cas.whu.edu.cn"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "http://ehall.whu.edu.cn/new/index.html?browser=no"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );
            // 要重新设置Cookie
            // handler.CookieContainer.SetCookies(redirectStr, )

            response = client.GetAsync(redirectStr).Result;       // 发请求 这时候应该会返回一次404
            Console.WriteLine($"return status: {response.StatusCode}");
            cookies = handler.CookieContainer.GetCookies(new Uri(redirectStr));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                
            }
            response = client.GetAsync(redirectStr).Result;       // 再发一次请求 应该得到302了
            Console.WriteLine($"return status: {response.StatusCode}");
            cookies = handler.CookieContainer.GetCookies(new Uri(redirectStr));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                
            }

            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }
            string redirect2jw = "http://bkjw.whu.edu.cn/common/caslogin.jsp";
            // string redirect2jw = response.Headers.GetValues("Location").FirstOrDefault();  // 应该会重定向到教务系统的地址 http://bkjw.whu.edu.cn/common/caslogin.jsp
            Console.WriteLine("redirect to   " + redirect2jw);


            client.DefaultRequestHeaders.Clear();           // 准备重新构造请求头
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Encoding",
                "gzip, deflate"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Connection",
                "keep-alive"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Host",
                "bkjw.whu.edu.cn"                                   // 域名变了
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "http://ehall.whu.edu.cn/new/index.html?browser=no"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );
            // 在cookie中设置语言
            handler.CookieContainer.SetCookies(new Uri("http://bkjw.whu.edu.cn/common/caslogin.jsp"), "userLanguage=zh-CN");
            
            response = client.GetAsync(redirect2jw).Result;       // 发请求
            Console.WriteLine($"return status: {response.StatusCode}");
            cookies = handler.CookieContainer.GetCookies(new Uri(redirect2jw));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                
            }

            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }

            // 这时候应该会重定向到教务系统首页了 地址应该是http://bkjw.whu.edu.cn/common/../stu/stu_index.jsp
            // string redirect2StuIndex = response.Headers.GetValues("Location").FirstOrDefault(); 
            string redirect2StuIndex = "http://bkjw.whu.edu.cn/stu/stu_index.jsp";
            Console.WriteLine("redirect to   " + redirect2StuIndex);
            response = client.GetAsync(redirect2StuIndex).Result;

            Console.WriteLine($"return status: {response.StatusCode}");
            cookies = handler.CookieContainer.GetCookies(new Uri(redirect2jw));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                Console.WriteLine(c.Value);
                
            }

            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }

            var stuIndexHtml = response.Content.ReadAsStreamAsync().Result;
            HtmlDocument doc = new HtmlDocument();
            
            doc.Load(stuIndexHtml);
            // Console.WriteLine(response.Content.ReadAsStringAsync().Result);   // 打印出来看看

            HtmlNode divSystem = doc.DocumentNode.SelectSingleNode("//div[@id='system']");      // 这个节点包含csrftoken
            string exp = divSystem.Attributes["onclick"].Value;                                 // 获取包含csrftoken的字符串
            // 正则表达式进行匹配
            string pattern = @"csrftoken=[+]'";
            Regex reg = new Regex(pattern);
            string result = reg.Match(exp).Value;
            result = result.Split("=").Last();
            result = result.Split("'").First();

            csrftoken = result;

            // CourseTableCrawler.crawlCourseTable();
            // StudentInfoCrawler.crawlStudentInfo();
            
            return true;
        }
        





        // 试一下另一种方法
        public static bool login_webreq(long userid, string portalPwd) {
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
                route
            );
            request.Headers.Add(
                "Coookie",
                JSESSIONID
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
                loginPage
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
            postData += "&lt=" + JwCrawler.lt;
            postData += "&dllt=" + JwCrawler.dllt;
            postData += "&execution=" + JwCrawler.execution;
            postData += "&_eventId=" + JwCrawler._eventId;
            postData += "&rmShown=" + JwCrawler.rmShown;

            var data = Encoding.UTF8.GetBytes(postData);
            using(Stream reqStream = request.GetRequestStream()) {
                reqStream.Write(data, 0, data.Length);
            }

            request.ContentLength = data.Length;        // 设置消息内容的长度
            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch(System.Net.WebException e) {  // 处理302重定向
                response = (HttpWebResponse)e.Response;
                
                Console.WriteLine(response.StatusCode);
                foreach(string k in response.Headers.AllKeys) {
                    Console.WriteLine($"key: {k},  value: {response.Headers.GetValues(k).FirstOrDefault()}");
                }
                var responseStr = new StreamReader(response.GetResponseStream()).ReadToEnd();
                // Console.WriteLine(responseStr);
                
                // foreach(var header in response.Headers) {
                //     Console.WriteLine("head: " + header.ToString());
                //     Console.WriteLine("value: " + response.Headers.GetValues(header.ToString().FirstOrDefault()));
                // }

                foreach(Cookie c in response.Cookies) {
                    Console.WriteLine("cookie: " + c);
                }
                return true;
            }
            finally {
                // do nothing
            }
            
            return false;

            
        }

        public static void logout() {
            Console.WriteLine("\n\t\t tring to logout \n");
            client.DefaultRequestHeaders.Clear();           // 准备重新构造请求头
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Encoding",
                "gzip, deflate"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Accept-Language",
                "zh-CN,zh;q=0.9,en;q=0.8"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Connection",
                "keep-alive"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Host",
                "cas.whu.edu.cn"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "http://ehall.whu.edu.cn/new/index.html?browser=no"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );
            // 要重新设置Cookie
            // handler.CookieContainer.SetCookies(redirectStr, )

            HttpResponseMessage response = client.GetAsync(logoutPage).Result;       // 发请求 这时候应该会返回一次404
            Console.WriteLine($"return status: {response.StatusCode}");
            CookieCollection cookies = handler.CookieContainer.GetCookies(new Uri(logoutPage));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                
            }

            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }
        }

        public static void expireCookie(string domain) {
            var cookies = handler.CookieContainer.GetCookies(new Uri(domain));
            if(cookies != null) {
                foreach (Cookie co in cookies){
                    co.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1));
                }
            }
            
        }

    }

    
}