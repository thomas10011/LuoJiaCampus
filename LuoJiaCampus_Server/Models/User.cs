using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace LuoJiaCampus_Server.Models {
    public class User {
        [Required]
        public long id { get; set; }                    // 学号
        public short grade { get; set; }                // 年级
        [Required]
        public string password { get; set; }            // 教务系统密码
        [Required]
        public string portalpwd { get; set;}            // 信息门户密码
        public string nmae { get; set; }                // 姓名
        public string school { get; set; }              // 学院
        public string gender { get; set; }              // 性别
        public string major { get; set; }               // 专业
        public string avatar { get; set; }              // 头像存放路径
    }
}