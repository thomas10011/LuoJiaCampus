
namespace LuoJiaCampus_Server.Models {
    public class Course {
        public short credits { get; set; }                      // 学分
        public long courseNum { get; set; }                      // 课头号
        public string courseName { get; set; }                  // 课程名
        public string courseType { get; set; }                  // 课程类型 
        public string leranTyoe { get; set; }                   // 学习类型 普通/重修
        public string school { get; set; }                      // 授课学院
        public string teacherName { get; set; }                 // 教师名
        public string major { get; set; }                       // 专业
        public string learnTime { get; set; }                   // 学时
        public string courseTime { get; set; }                  // 上课时间地点


    }



}