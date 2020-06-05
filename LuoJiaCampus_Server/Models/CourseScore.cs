namespace LuoJiaCampus_Server.Models {
    public class CourseScore {
        public long courseid { get; set; }              // 课程id
        public string courseName { get; set; }          // 课程名
        public string courseType { get; set; }          // 课程类型
        public string tsType { get; set; }              // 通识课类型
        public string courseAttribute { get; set; }     // 课程属性
        public float credits { get; set; }              // 学分
        public string teacherName { get; set; }         // 教师名
        public string school { get; set; }              // 授课学院
        public string learnType { get; set; }           // 学习类型
        public short year { get; set; }                 // 学年
        public bool term { get; set; }                  // 学期
        public float score { get; set; }                // 成绩  -1表示还没出成绩
        
        public long userid { get; set; }                // 用户id
        
    }
}