using System.Net;
using System;
using System.Net.Http;
using HtmlAgilityPack;
using LuoJiaCampus_Server.Models;
using Newtonsoft.Json;

namespace LuoJiaCampus_Server.jw_Crawler {
    public class StudentInfoCrawler {
        public static void crawlStudentInfo() {
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

            string stuInfoPage = "http://bkjw.whu.edu.cn/stu/student_information.jsp";
            HttpResponseMessage response = JwCrawler.client.GetAsync(stuInfoPage).Result;

            Console.WriteLine($"return status: {response.StatusCode}");
            CookieCollection cookies = JwCrawler.handler.CookieContainer.GetCookies(new Uri(stuInfoPage));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                Console.WriteLine(c.Value);
                
            }

            var courseTableHtml = response.Content.ReadAsStreamAsync().Result;
            HtmlDocument doc = new HtmlDocument();
            
            doc.LoadHtml(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);   // 打印出来看看

            /*---------------------------下面对html进行解析-------------------------------------*/
            HtmlNode node;
            node = doc.DocumentNode.SelectSingleNode("//th[@name='studentID']").NextSibling;
            long stuId = Convert.ToInt64(node.InnerText);
            Console.WriteLine(stuId);
            node = doc.DocumentNode.SelectSingleNode("//th[@name='name']").NextSibling;
            string name = node.InnerText;
            Console.WriteLine(name);
            node = doc.DocumentNode.SelectSingleNode("//th[@name='gender']").NextSibling;
            string gender = node.InnerText;
            Console.WriteLine(gender);
            node = doc.DocumentNode.SelectSingleNode("//th[@name='department']").NextSibling;
            string department = node.InnerText;
            Console.WriteLine(department);
            node = doc.DocumentNode.SelectSingleNode("//th[@name='profession']").NextSibling;
            string profession = node.InnerText;
            Console.WriteLine(profession);
            node = doc.DocumentNode.SelectSingleNode("//th[@name='grade']").NextSibling;
            short grade = Convert.ToInt16(node.InnerText);
            Console.WriteLine(grade);

            User newUser = new User();
            newUser.id = stuId;
            newUser.grade = grade;
            newUser.password = "19991119";
            newUser.portalpwd = "190034";
            newUser.nmae = name;
            newUser.school = department;
            newUser.gender = gender;
            newUser.major = profession;
            
            Console.WriteLine(JsonConvert.SerializeObject(newUser));            // 打印出来看看
        }


    }
}