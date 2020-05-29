using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace LuoJiaCampus_Server.Models {
    public class Comment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // 设置主键自增
        public int id { get; set; }                             // 评论编号
        [Required]
        public string text { get; set; }                        // 内容
        public string createdTime { get; set; }                 // 创建时间
        [Required]
        public long userid { get; set; }                        // user外键
        [Required]
        public long newsid { get; set; }                        // news外键

    }


}