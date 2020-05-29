using System.Linq.Expressions;
using System;
using LuoJiaCampus_Server.Models;
using Microsoft.AspNetCore.Mvc;
namespace LuoJiaCampus_Server.Controllers {

    [ApiController]
    [Route("News/")]
    public class NewsController : ControllerBase {
        private readonly ServerDBContext myDB;
        public NewsController(ServerDBContext context) {
            myDB = context;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult addNews([FromBody] News news) {
            try {
                myDB.Add(news);
                myDB.SaveChanges();
            } catch (Exception e) {
                return BadRequest(e.InnerException.Message);
            }
            // 添加成功返回ok
            return Ok();
        }

    }
}