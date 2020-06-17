using System.Collections.Generic;
using LuoJiaCampus_Server.Models;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Net.Http;



namespace LuoJiaCampus_Server.Crawler {
    public class CourseScoreCrawler {
        public static List<CourseScore> crawlCourseScore(long userId) {
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

            string courseTableUrl = "http://bkjw.whu.edu.cn/servlet/Svlt_QueryStuScore";
            courseTableUrl += "?csrftoken=" + JwCrawler.csrftoken;
            courseTableUrl += "&year=" + "0";
            courseTableUrl += "&term=" + "";
            courseTableUrl += "&learntype=" + "";
            courseTableUrl += "&scoreflag=" + "0";
            HttpResponseMessage response = JwCrawler.client.GetAsync(courseTableUrl).Result;

            Console.WriteLine($"return status: {response.StatusCode}");
            CookieCollection cookies = JwCrawler.handler.CookieContainer.GetCookies(new Uri(courseTableUrl));   // 拿到cookie
            foreach(Cookie c in cookies) {
                Console.WriteLine(c.ToString());
                Console.WriteLine(c.Value);
                
            }

            var courseScoreHtml = response.Content.ReadAsStringAsync().Result;
            HtmlDocument doc = new HtmlDocument();
            
            doc.LoadHtml(courseScoreHtml);
            // Console.WriteLine(courseScoreHtml);   // 打印出来看看
            
            HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//table");

            List<CourseScore> scores = new List<CourseScore>();         // 要返回的score
            bool flag = true;
            foreach(HtmlNode row in bodyNode.SelectNodes(".//tr")) {
                if(flag) {
                    flag = false;
                    continue;
                }
                short count = 0;
                CourseScore score = new CourseScore();
                foreach(HtmlNode column in row.SelectNodes(".//td")) {
                    
                    string result = Regex.Replace(column.InnerText, @"\s", "");
                    // if(result == null || result== "")
                    //     continue;
                    
                    switch(count) {
                        case 0:
                            Console.WriteLine(column.Attributes["data-lsnid"].Value);
                            long id = Convert.ToInt64(Regex.Replace(column.Attributes["data-lsnid"].Value, @"\s", ""));
                            score.courseid = id;
                            score.courseName = result;
                            break;
                        case 1:
                            score.courseType = result;
                            break;
                        case 2:
                            score.tsType = result;
                            break;
                        case 3:
                            score.courseAttribute = result;
                            break;
                        case 4:
                            score.credits = (float)Convert.ToDouble(result);
                            break;
                        case 5:
                            score.teacherName = result;
                            break;
                        case 6:
                            score.school = result;
                            break;
                        case 7:
                            score.learnType = result;
                            break;
                        case 8:
                            score.year = Convert.ToInt16(result);
                            break;
                        case 9:
                            score.term = result == "1" ? false : true ;
                            break;
                        case 10:
                            
                            score.score = result == "" ? -1 : (float)Convert.ToDouble(result);
                            break;
                        default:
                            break;
                    }

                    count++;
                    Console.WriteLine(result);
                    
                    // Console.WriteLine("");
                }

                score.userid = userId;
                scores.Add(score);                  // 课程记录添加到集合中


            }

            return scores;
        } 


    }
}