using System;
using System.Net.Http;
using Microsoft.AspNetCore.NodeServices;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using Microsoft.AspNetCore.NodeServices;

namespace LuoJiaCampus_Server.jw_Crawler {
    
    public class CourseTableCrawler {
        public static string loginPage = @"https://cas.whu.edu.cn/authserver/login?service=http%3A%2F%2Fehall.whu.edu.cn%2Flogin%3Fservice%3Dhttp%3A%2F%2Fehall.whu.edu.cn%2Fnew%2Findex.html%3Fbrowser%3Dno";
        public static string lt = null;
        public static string dllt = null;
        public static string execution = null;
        public static string _eventId = null;
        public static string rmShown = null;
        public static string dynamicPwdEncryptSalt = null;

        // 静态变量client
        private static readonly HttpClient client = new HttpClient();
        private static readonly HtmlParser parser = new HtmlParser();
        
        

        // 获取登录页面的相关信息
        public static void initAttributes() {
            try {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(loginPage);
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

        public static void login(long userid, string portalPwd) {
            initAttributes();   // 登录前初始化相关属性

        }


    }

    
}