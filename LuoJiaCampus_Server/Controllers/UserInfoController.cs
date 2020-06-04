using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LuoJiaCampus_Server.Models;
using LuoJiaCampus_Server.ToolClasses;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserInfoController: ControllerBase {
        private readonly ServerDBContext db;
        public UserInfoController(ServerDBContext dBContext) {
            db = dBContext;
        }

        [HttpGet]
        public ActionResult<User> GetUserInfo() {
            Console.WriteLine("receive post request");
            User user;
            try {
                // 得到当前的http请求
                var req = HttpContext.Request;
                string tokenToDecode = req.Headers["Authorization"].ToString().Split(' ').Last();     // 获取token
                // 解码的token转化为json对象
                JObject token = (JObject)JsonConvert.DeserializeObject(DecodeJwt.decode(tokenToDecode));
                string token_id = token["sub"].ToString();      // 拿到id
                Console.WriteLine($"id frome token: {token_id}");

                // 根据id从数据库里面查询密码
                user = db.users.FirstOrDefault(
                    o => o.id == Convert.ToInt64(token_id)
                );

            }
            catch(Exception e) {
                return BadRequest(e.InnerException.Message);
            }
            return user;
        }
    }
}