using System.Net;
using System;
using System.Net.Http;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using System.Net;
using System.IO;


namespace LuoJiaCampus_Server.jw_Crawler {
    public class CourseTableCrawler {
        public static void crawlCourseTable () {
            JwCrawler.client.DefaultRequestHeaders.Clear(); 
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
                "bkjw.whu.edu.cn"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Referer",
                "http://bkjw.whu.edu.cn/stu/stu_course_parent.jsp"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "Upgrade-Insecure-Requests",
                "1"
            );
            JwCrawler.client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36"
            );

            string courseTableUrl = "http://bkjw.whu.edu.cn/servlet/Svlt_QueryStuLsn";
            courseTableUrl += "?csrftoken=" + JwCrawler.csrftoken;
            courseTableUrl += "&action=" + "normalLsn";
            courseTableUrl += "&year=" + "2019";
            courseTableUrl += "&term=" + "2";
            courseTableUrl += "&state=";
            HttpResponseMessage response = JwCrawler.client.GetAsync(courseTableUrl).Result;

            Console.WriteLine($"return status: {response.StatusCode}");
            CookieCollection cookies = JwCrawler.handler.CookieContainer.GetCookies(new Uri(courseTableUrl));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                Console.WriteLine(c.Value);
                
            }

            var courseTableHtml = response.Content.ReadAsStreamAsync().Result;
            HtmlDocument doc = new HtmlDocument();
            
            doc.Load(courseTableHtml);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);   // 打印出来看看

        }
    }

}