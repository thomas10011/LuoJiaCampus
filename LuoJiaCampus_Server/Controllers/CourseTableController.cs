using System.Net;
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
using LuoJiaCampus_Server.jw_Crawler;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CourseTableController: ControllerBase {
        private readonly ServerDBContext myDB;
        private readonly INodeServices nodeServices;
        //构造函数把DBContext 作为参数，Asp.net core 框架可以自动注入DBContext对象
        public CourseTableController(ServerDBContext dbContext, INodeServices _nodeServices) {
            this.myDB = dbContext;
            this.nodeServices = _nodeServices;
        }
        
        [HttpGet]
        public ActionResult<News> GetNews(long id) {
            Console.WriteLine("get request");
            JwCrawler.initAttributes();

            // 得到当前的http请求
            var req = HttpContext.Request;
            string tokenToDecode = req.Headers["Authorization"].ToString().Split(' ').Last();     // 获取token
            // 解码的token转化为json对象
            JObject token = (JObject)JsonConvert.DeserializeObject(DecodeJwt.decode(tokenToDecode));
            string token_id = token["sub"].ToString();
            Console.WriteLine($"id frome token: {token_id}");

            var t = getPwdEncrypted();
            News item;
            try {
                item = myDB.news.FirstOrDefault(t => t.userid == id);
                var user = myDB.users.FirstOrDefault();
            }
            catch(Exception e) {
                return BadRequest(e.InnerException.Message);
            }
            return item;
        }

        

        [HttpPost]
        public ActionResult<User> PostToUser(User user) {
            Console.WriteLine("receive post request");
            try {
                myDB.users.Add(user);
                myDB.SaveChanges();

            }
            catch(Exception e) {
                return BadRequest(e.InnerException.Message);
            }
            return user;
        }

        public async Task<string> getPwdEncrypted() {
            Console.WriteLine("try encrypt");
            string pwd = await nodeServices.InvokeAsync<string>("./Crawler/encrypt.js", "190034", "ZY6ZtYaijmQIHnhG");
            Console.WriteLine($"test encrypt password: {pwd}");
            return pwd;
        }
    }

}