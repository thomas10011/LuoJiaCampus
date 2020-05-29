using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace LuoJiaCampus_Server.Models {
    public class News {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // 设置主键自增
        public long id { get; set; }                            // 编号
        public int rates { get; set; }                          // 点赞数
        public int commentNum { get; set; }                     // 评论数
        [Required]
        public string text { get; set; }                        // 内容
        public string type { get; set; }                        // 新鲜事类型 失物招领 公告
        [Required]
        public string createdTime { get; set; }                 // 发布时间
        [Required]
        public long userid { get; set; }                        // 发布新鲜事的用户
    }




}