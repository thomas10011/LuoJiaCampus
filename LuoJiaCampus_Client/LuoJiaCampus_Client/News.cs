using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STUDENTINFO
{
    public class News
    {
        /// <summary>
        ///  编号
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置主键
        public long id { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int rates { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int commentNum { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string text { get; set; }
        /// <summary>
        /// 新鲜事类型 失误招领 公告 0-树洞 1-失误招领 2-公告
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Required]
        public string createdTime { get; set; }
        /// <summary>
        /// 发布新鲜事的用户
        /// </summary>
        [Required]
        public long userid { get; set; }
    }
}
