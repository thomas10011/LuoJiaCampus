using System.Collections.Generic;

namespace LuoJiaCampus_Server.Models {
    public class ScoreForm {
        public short year { get; set; }                         // 学年
        public bool term { get; set; }                          // 学期：0上半学期 1下半学期
        public ICollection<CourseScore> socre { get; set; }     // 课程成绩

    }



}