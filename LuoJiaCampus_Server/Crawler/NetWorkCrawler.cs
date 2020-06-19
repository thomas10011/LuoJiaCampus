using System.Text;
using System.Linq;
using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LuoJiaCampus_Server.Crawler {
    public class NetworkCrawler {
        // 查询校园网状态
        public static bool CrawlNetorkStatus(long id) {
            string showUrl = "http://ehall.whu.edu.cn/appShow?appId=5054874232878111";
            string networkUrl = "http://user-serv.whu.edu.cn:8080/selfservice/module/webcontent/web/index_self.jsf?self=2";

        
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

            JwCrawler.client.DefaultRequestHeaders.Add(
                "Cookie",
                "zg_did=%7B%22did%22%3A%20%221728cb08aed412-047d179103cc93-143e6257-1fa400-1728cb08aee9ea%22%7D; zg_=%7B%22sid%22%3A%201591498279666%2C%22updated%22%3A%201591498279672%2C%22info%22%3A%201591498279670%2C%22superProperty%22%3A%20%22%7B%7D%22%2C%22platform%22%3A%20%22%7B%7D%22%2C%22utm%22%3A%20%22%7B%7D%22%2C%22referrerDomain%22%3A%20%22ehall.whu.edu.cn%22%2C%22cuid%22%3A%20%222018302110296%22%7D; "
                + "amp.locale=undefined; "
                + JwCrawler.JSESSIONID + "; "
                + JwCrawler.iPlanetDirectoryPro + "; "
                + JwCrawler.route
            );

            

            Console.WriteLine("redirect to: " + showUrl);

            
            HttpResponseMessage response = JwCrawler.client.GetAsync(showUrl).Result;

            Console.WriteLine("cas to network return status:" + response.StatusCode);
            
            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }
            
            string redirectStr = response.Headers.GetValues("Location").FirstOrDefault();
            response = JwCrawler.client.GetAsync(redirectStr).Result;
            // 打印响应头
            foreach(var head in response.Headers) {
                Console.WriteLine($"response head key: {head.Key}");
                Console.Write("value: ");
                foreach(string o in head.Value) {
                    Console.Write(o + " ");
                }
                Console.WriteLine();
            }



            response = JwCrawler.client.GetAsync(networkUrl).Result;
            

            var NetWorkPage = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(NetWorkPage);

            bool result = Regex.IsMatch(NetWorkPage, ".*[>]恢复[<].*");
            if(result) {
                Console.WriteLine("用户的校园网处于暂停状态");
            }
            else {
                Console.WriteLine("用户的校园网处于正常状态");
            }
            
            return result;
        }

        public static void resumeNetwork(long id) {
            string resumeUrl = "http://user-serv.whu.edu.cn:8080/selfservice/module/userself/web/userself_ajax.jsf?methodName=userSelfOperationBean.newConfirmResume";

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

            JwCrawler.client.DefaultRequestHeaders.Add(
                "Cookie",
                "zg_did=%7B%22did%22%3A%20%221728cb08aed412-047d179103cc93-143e6257-1fa400-1728cb08aee9ea%22%7D; zg_=%7B%22sid%22%3A%201591498279666%2C%22updated%22%3A%201591498279672%2C%22info%22%3A%201591498279670%2C%22superProperty%22%3A%20%22%7B%7D%22%2C%22platform%22%3A%20%22%7B%7D%22%2C%22utm%22%3A%20%22%7B%7D%22%2C%22referrerDomain%22%3A%20%22ehall.whu.edu.cn%22%2C%22cuid%22%3A%20%222018302110296%22%7D; "
                // + "amp.locale=undefined; "
                // + JwCrawler.JSESSIONID + "; "
                // + JwCrawler.iPlanetDirectoryPro + "; "
                + JwCrawler.route
            );

            Console.WriteLine("redirect to: " + resumeUrl);

            // 构造post参数
            HttpContent postBody = new FormUrlEncodedContent(
                new Dictionary<string, string>() {
                    {"targetUserId", id.ToString()}
                }
            );
            
            HttpResponseMessage response = JwCrawler.client.PostAsync(resumeUrl, postBody).Result;

            Console.WriteLine("cas to network return status:" + response.StatusCode);
            
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

        public static void suspendNetwork(long id) {
            string suspendUrl = "http://user-serv.whu.edu.cn:8080/selfservice/module/userself/web/userself_ajax.jsf?methodName=userSelfOperationBean.newConfirmSuspend";

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

            JwCrawler.client.DefaultRequestHeaders.Add(
                "Cookie",
                "zg_did=%7B%22did%22%3A%20%221728cb08aed412-047d179103cc93-143e6257-1fa400-1728cb08aee9ea%22%7D; zg_=%7B%22sid%22%3A%201591498279666%2C%22updated%22%3A%201591498279672%2C%22info%22%3A%201591498279670%2C%22superProperty%22%3A%20%22%7B%7D%22%2C%22platform%22%3A%20%22%7B%7D%22%2C%22utm%22%3A%20%22%7B%7D%22%2C%22referrerDomain%22%3A%20%22ehall.whu.edu.cn%22%2C%22cuid%22%3A%20%222018302110296%22%7D; "
                // + "amp.locale=undefined; "
                // + JwCrawler.JSESSIONID + "; "
                // + JwCrawler.iPlanetDirectoryPro + "; "
                + JwCrawler.route
            );

            Console.WriteLine("redirect to: " + suspendUrl);

            // 构造post参数
            HttpContent postBody = new FormUrlEncodedContent(
                new Dictionary<string, string>() {
                    {"targetUserId", id.ToString()}
                }
            );
            
            HttpResponseMessage response = JwCrawler.client.PostAsync(suspendUrl, postBody).Result;

            Console.WriteLine("cas to network return status:" + response.StatusCode);
            
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

    }
}