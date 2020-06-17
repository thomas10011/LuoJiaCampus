using System.Net;
using System;
using System.Net.Http;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using LuoJiaCampus_Server.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace LuoJiaCampus_Server.Crawler {
    public class CourseTableCrawler {
        public static List<Course> crawlCourseTable () {
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

            var courseTableHtml = response.Content.ReadAsStringAsync().Result;
            HtmlDocument doc = new HtmlDocument();
            
            doc.LoadHtml(courseTableHtml);
            Console.WriteLine(courseTableHtml);   // 打印出来看看

            /*-------------------------下面将课表转化为实体集合-----------------------------*/
            List<Course> courses = new List<Course>();
            HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//table");
            bool flag = true;       // 用来跳过第一行的表头
            foreach(HtmlNode row in bodyNode.SelectNodes(".//tr")) {
                if(flag) {
                    flag = false;
                    continue;
                }
                short count = 0;
                Course course = new Course();
                foreach(HtmlNode column in row.SelectNodes(".//td")) {

                    string result = Regex.Replace(column.InnerText, @"\s", "");
                    
                    
                    switch(count) {
                        case 0:
                            course.courseNum = Convert.ToInt64(result);
                            break;
                        case 1:
                            course.courseName = result;
                            break;
                        case 2:
                            course.courseType = result;
                            break;
                        case 3:
                            course.learnType = result;
                            break;
                        case 4:
                            course.school = result;
                            break;
                        case 5:
                            course.teacherName = result;
                            break;
                        case 6:
                            course.major = result;
                            break;
                        case 7:
                            course.credits = (float)Convert.ToDouble(result);
                            break;
                        case 8:
                            course.learnTime = result;
                            break;
                        case 9:
                            course.courseTime = result;
                            break;
                        default:
                            break;
                    }

                    count++;
                    Console.WriteLine(result);
                    
                }
                courses.Add(course);
            }
            
            Console.WriteLine(JsonConvert.SerializeObject(courses));
            return courses;
        }
        
    }

}