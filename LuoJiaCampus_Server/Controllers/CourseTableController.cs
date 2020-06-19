using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuoJiaCampus_Server.Models;
using Microsoft.AspNetCore.Authorization;
using LuoJiaCampus_Server.ToolClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.NodeServices;
using System.Threading.Tasks;
using LuoJiaCampus_Server.Crawler;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CourseTableController: ControllerBase {
        private readonly ServerDBContext db;
        private readonly INodeServices nodeServices;
        //构造函数把DBContext 作为参数，Asp.net core 框架可以自动注入DBContext对象
        public CourseTableController(ServerDBContext dbContext, INodeServices _nodeServices) {
            this.db = dbContext;
            this.nodeServices = _nodeServices;
        }
        
        [HttpGet]
        public ActionResult<List<Course>> getCoursTable() {
            Console.WriteLine("getting CourseTable");
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
            JwCrawler.loginJw();    // 登录教务
            List<Course> courses = CourseTableCrawler.crawlCourseTable();
            JwCrawler.logout();
            return courses;
        }

        

        

        public async Task<string> getPwdEncrypted(string pwdToEncrypt, string salt) {
            Console.WriteLine("try encrypt");
            string pwd = await nodeServices.InvokeAsync<string>(Constants.encryptJsRoute, pwdToEncrypt, salt);
            Console.WriteLine($"test encrypt password: {pwd}");
            return pwd;
        }
    }

}