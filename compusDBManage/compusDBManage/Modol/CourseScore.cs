using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace compusDBManage
{
   public class CourseScore//成绩
    {
        [Key, Column(Order = 0)]
        public long userid { get; set; }
        [Key, Column(Order = 1)]
        public long courseid { get; set; }
        public int score { get; set; }
        public double gradePoint { get; set; }
        public string courseName { get; set; }
        public string courseType { get; set; }
        public double credits { get; set; }
        public string teacherName { get; set; }
        public string school { get; set; }
        public int  Year { get; set; }
        public bool Term { get; set; }

        public CourseScore() { }
        public CourseScore(string coursename,int score, double gradePoint, long courseid, long userid, string courseType, double credits, string teacherName, string school,int yea,bool term)
        {
            this.courseName = coursename;
            this.score = score;
            this.gradePoint = gradePoint;
            this.courseid = courseid;
            this.userid = userid;
            this.courseType = courseType;
            this.credits = credits;
            this.teacherName = teacherName;
            this.school = school;
            this.Year = yea;
            this.Term = term;
            if (score > 89) this.gradePoint = 4.0;
            else if (score > 84) this.gradePoint = 3.7;
            else if (score > 81) this.gradePoint = 3.3;
            else if (score > 77) this.gradePoint = 3.0;
            else if (score > 74) this.gradePoint = 2.7;
            else if (score > 71) this.gradePoint = 2.3;
            else if (score > 67) this.gradePoint = 2.0;
            else if (score > 63) this.gradePoint = 1.5;
            else if (score > 59) this.gradePoint = 1.0;
            else this.gradePoint = 0;
        }
       
        //增加
        public void addCourseScore(CourseScore co)
        {        
            using (var db = new compusDB())
            {
                var courselist = db.CourseScore.Where(p => p.courseid == co.courseid).ToList();
                var course = courselist.Where(p => p.userid == co.userid).FirstOrDefault();
                if (course == null)
                {                  
                    db.CourseScore.Add(co);
                    db.SaveChanges();
                    Console.WriteLine(teacherName);
                }
                else {
                    Console.WriteLine("该数据已存在");
                }

            }
        }
       
        //删除一条记录
        public void deleteCourseScore(short userId,long courseId)
        {
            using (var context = new compusDB())
            {
                var score = context.CourseScore.FirstOrDefault(p => p.userid == userId && p.courseid == courseId);
                if (score != null) {
                    context.CourseScore.Remove(score);
                    context.SaveChanges();

                }
            }
        }
       
        //查询
        public List<CourseScore> Query()
        {
            List<CourseScore> cs = new List<CourseScore>();
            using (var context = new compusDB())
            {
                cs = context.CourseScore.ToList();
            }
            foreach (CourseScore course in cs)
            {
                Console.WriteLine(course.school);
            }
            return cs;
        }
       
        //a,b,c
        public List<CourseScore> QueryAll(string a, string b, string c,long ID)
        {
            List<CourseScore> forms = new List<CourseScore>();                                  
            using (var context = new compusDB())
            {
                forms = context.CourseScore.Where(p => p.userid == ID).ToList();
                if (a != "全部") { short year = Convert.ToInt16(a); forms = forms.Where(p => p.Year == year).ToList(); }

                if (b != "全部") { string type = b; forms = forms.Where(p => p.courseType == type).ToList(); }
                if (c != "全部") { bool term = (c == "2"); forms = forms.Where(p => p.Term == term).ToList(); }
            }
            foreach (CourseScore course in forms)
            {
                Console.WriteLine(course.courseType);
            }
            return forms;

        }

        public void modifiedCouseScore(short score, double gradePoint, long courseid, long userid, string courseType, short credits, string teacherName, string school, int yea, bool term)
        {
            using (var context = new compusDB())
            {
                var cs = context.CourseScore.FirstOrDefault(p => p.userid == userid && p.courseid == courseid);
                if (cs != null)
                {
                    cs.score = score;
                    cs.gradePoint = gradePoint;
                    cs.courseType = courseType;
                    cs.credits = credits;
                    cs.teacherName = teacherName;
                    cs.school = school;
                    cs.Year = yea;
                    cs.Term = term;
                    context.SaveChanges();
                }
                else { Console.WriteLine("不存在该记录"); }
            }
        }

    }
}
