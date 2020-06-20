using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace compusDBManage
{
    public class Course//课程表
    {
        public double credits { get; set; } // 学分
        [Key, Column(Order = 0)]
        public long courseNum { get; set; }
        public string courseName { get; set; }
        public string courseType { get; set; }
        public string leranTyoe { get; set; }
        public string school { get; set; }
        public string teacherName { get; set; }
        public string major { get; set; }
        public string learnTime { get; set; }
        public string courseTime { get; set; }
        [Key, Column(Order = 1)]
        public long userid { get; set; }
        public int num { get; set; }
        public int week { get; set; }
        public int end { get; set; }
        public string place { get; set; }
        public string weeknum { get; set; }


        public Course() { }
        public Course(double credit,long courseNum,string coursNam,string coursType, string leranTyoe, string school, string teacherName, string major, string learnTime, string courseTime,long id)
        {
            this.credits = credit;
            this.courseNum = courseNum;
            this.courseName = coursNam;
            this.courseType = coursType;
            this.courseTime = courseTime;
            this.school = school;
            this.teacherName = teacherName;
            this.major = major;
            this.learnTime = learnTime;
            this.leranTyoe = leranTyoe;
            this.userid = id;
            fillweek(courseTime);
        }

        //增加一条记录
        public void Add(Course co)
        {
            using (var db = new compusDB())
            {
                var courselist = db.Course.Where(p => p.courseNum == co.courseNum).ToList();
                var course = courselist.Where(p => p.userid == co.userid).FirstOrDefault();
                if (course == null)
                {
                    course = co;
                    db.Course.Add(course);
                    db.SaveChanges();
                    Console.WriteLine(co.courseName);
                }
                else
                {
                    Console.WriteLine("该数据已存在");
                }

            }
        }

        //查询所有记录
        public List<Course> queryAll(long id)
        {
            List<Course> cs = new List<Course>();
            using (var context = new compusDB())
            {
                cs = context.Course.Where(p => p.userid == id).ToList();
            }
            foreach (Course course in cs)
            {
                Console.WriteLine(course.courseName);
            }
            return cs;
        }

        //根据课程名删除一条记录
        public void Delete(string coName)
        {
            using (var context = new compusDB())
            {
                var score = context.Course.FirstOrDefault(p => p.courseName == coName);
                if (score != null)
                {
                    context.Course.Remove(score);
                    context.SaveChanges();
                    Console.WriteLine("删除成功");
                }
                else { Console.WriteLine("不存在该记录"); }
            }
        }

        //删除所有记录
        public void DeleteAll()
        {
            using (var context = new compusDB())
            {
                var cou = context.Course.ToList();
                if (cou != null)
                {
                    foreach (Course co in cou)
                    {
                        context.Course.Remove(co);
                        Console.WriteLine("已删除");
                    }
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }
        public void fillweek(string a)
        {
            string pattern1 = @"^周(?<day>[一二三四五六日]):(?<weeknum>(\d+)-(\d+)周),...?;(?<num>(\d+))-(?<end>(\d+))(,*)(?<place>(.*))";
            Regex rx = new Regex(pattern1);
            Match m = rx.Match(a);
            switch (m.Groups["day"].Value)
            {
                case "一":week = 1;break;
                case "二": week = 2; break;
                case "三": week = 3; break;
                case "四": week = 4; break;
                case "五": week = 5; break;
                case "六": week = 6; break;
                case "日": week = 7; break;
                default:break;
            }
            weeknum = m.Groups["weeknum"].Value;
            num = Int32.Parse(m.Groups["num"].Value);
            end = Int32.Parse(m.Groups["end"].Value);
            place = m.Groups["place"].Value;
        }
    }
}
