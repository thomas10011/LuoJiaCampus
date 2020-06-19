using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.NodeServices;
using LuoJiaCampus_Server.Models;
using LuoJiaCampus_Server.Crawler;
using LuoJiaCampus_Server.ToolClasses;
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class NetworkController: ControllerBase {
        private readonly ServerDBContext db;
        private readonly INodeServices nodeServices;
        public NetworkController(ServerDBContext context, INodeServices _nodeServices) {
            db = context;
            nodeServices = _nodeServices;
        }
        [HttpGet]
        [Route("getStatus")]
        public ActionResult getNetWorkStatus() {
            Console.WriteLine("getNetWorkStatus \n");

            JwCrawler.initAttributes();

            // 得到当前的http请求
            var req = HttpContext.Request;
            string tokenToDecode = req.Headers["Authorization"].ToString().Split(' ').Last();     // 获取token
            // 解码的token转化为json对象
            JObject token = (JObject)JsonConvert.DeserializeObject(DecodeJwt.decode(tokenToDecode));
            string token_id = token["sub"].ToString();      // 拿到id
            Console.WriteLine($"id frome token: {token_id}");

            // 根据id从数据库里面查询密码
            User query = db.users.FirstOrDefault(
                o => o.id == Convert.ToInt64(token_id)
            );
            // 调用爬虫
            JwCrawler.initAttributes();
            JwCrawler.login(query.id, getPwdEncrypted(query.portalpwd, JwCrawler.dynamicPwdEncryptSalt).Result);

            NetworkCrawler.CrawlNetorkStatus(query.id);
            JwCrawler.logout();
            return Ok();
        }

        [HttpGet]
        [Route("resumeNetwork")]
        public ActionResult resumeNetwork() {
            JwCrawler.initAttributes();

            // 得到当前的http请求
            var req = HttpContext.Request;
            string tokenToDecode = req.Headers["Authorization"].ToString().Split(' ').Last();     // 获取token
            // 解码的token转化为json对象
            JObject token = (JObject)JsonConvert.DeserializeObject(DecodeJwt.decode(tokenToDecode));
            string token_id = token["sub"].ToString();      // 拿到id
            Console.WriteLine($"id frome token: {token_id}");

            // 根据id从数据库里面查询密码
            User query = db.users.FirstOrDefault(
                o => o.id == Convert.ToInt64(token_id)
            );
            // 调用爬虫
            JwCrawler.initAttributes();
            JwCrawler.login(query.id, getPwdEncrypted(query.portalpwd, JwCrawler.dynamicPwdEncryptSalt).Result);

            NetworkCrawler.CrawlNetorkStatus(query.id);
            NetworkCrawler.resumeNetwork(query.id);
            JwCrawler.logout();
            return Ok();
        }

        [HttpGet]
        [Route("suspendNetwork")]
        public ActionResult suspendNetwork() {
            JwCrawler.initAttributes();

            // 得到当前的http请求
            var req = HttpContext.Request;
            string tokenToDecode = req.Headers["Authorization"].ToString().Split(' ').Last();     // 获取token
            // 解码的token转化为json对象
            JObject token = (JObject)JsonConvert.DeserializeObject(DecodeJwt.decode(tokenToDecode));
            string token_id = token["sub"].ToString();      // 拿到id
            Console.WriteLine($"id frome token: {token_id}");

            // 根据id从数据库里面查询密码
            User query = db.users.FirstOrDefault(
                o => o.id == Convert.ToInt64(token_id)
            );
            // 调用爬虫
            JwCrawler.initAttributes();
            JwCrawler.login(query.id, getPwdEncrypted(query.portalpwd, JwCrawler.dynamicPwdEncryptSalt).Result);

            NetworkCrawler.CrawlNetorkStatus(query.id);
            NetworkCrawler.suspendNetwork(query.id);
            JwCrawler.logout();
            return Ok();



        }
        public async Task<string> getPwdEncrypted(string pwdToEncrypt, string salt) {
            Console.WriteLine("try encrypt");
            string pwd = await nodeServices.InvokeAsync<string>(Constants.encryptJsRoute, pwdToEncrypt, salt);
            Console.WriteLine($"test encrypt password: {pwd}");
            return pwd;
        }
    }
}