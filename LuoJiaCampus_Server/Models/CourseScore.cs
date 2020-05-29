namespace LuoJiaCampus_Server.Models {
    public class CourseScore {
        public short score { get; set; }                // 成绩
        public short gradePoint { get; set; }           // 绩点
        public long courseid { get; set; }              // 课程id
        public long userid { get; set; }                // 用户id
        public string courseType { get; set; }          // 课程类型
        public short credits { get; set; }              // 学分
        public string teacherName { get; set; }         // 教师名
        public string school { get; set; }              // 授课学院

    }
}