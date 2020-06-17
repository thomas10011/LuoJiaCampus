using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LuoJiaCampus_Server.Models;
using Microsoft.AspNetCore.NodeServices;
using System;
using LuoJiaCampus_Server.Crawler;
using System.Threading.Tasks;
using System.Linq;
using LuoJiaCampus_Server.ToolClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;


namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CourseScoreController: ControllerBase {
        private readonly ServerDBContext db;
        private readonly INodeServices nodeServices;
        //构造函数把DBContext 作为参数，Asp.net core 框架可以自动注入DBContext对象
        public CourseScoreController(ServerDBContext dbContext, INodeServices _nodeServices) {
            this.db = dbContext;
            this.nodeServices = _nodeServices;
        }

        [HttpGet]
        public ActionResult<List<CourseScore>> getCourseScore() {
            Console.WriteLine("getting CourseScore");
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
            JwCrawler.loginJw();
            List<CourseScore> score = CourseScoreCrawler.crawlCourseScore(Convert.ToInt64(token_id));
            JwCrawler.logout();
            return score;

        }

        public async Task<string> getPwdEncrypted(string pwdToEncrypt, string salt) {
            Console.WriteLine("try encrypt");
            string pwd = await nodeServices.InvokeAsync<string>(Constants.encryptJsRoute, pwdToEncrypt, salt);
            Console.WriteLine($"test encrypt password: {pwd}");
            return pwd;
        }
    }
}