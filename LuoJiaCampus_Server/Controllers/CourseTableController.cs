// using Internal;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuoJiaCampus_Server.Models;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CourseTableController: ControllerBase {
        private readonly MyDBContext myDB;

        //构造函数把DBContext 作为参数，Asp.net core 框架可以自动注入DBContext对象
        public CourseTableController(MyDBContext context) {
            this.myDB = context;
            
        }
        
        [HttpGet]
        public ActionResult<News> GetNews(long id) {
            Console.WriteLine("get request");
            var item = myDB.news.FirstOrDefault(t => t.id == id);
            var user = myDB.users.FirstOrDefault();
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
    }

}