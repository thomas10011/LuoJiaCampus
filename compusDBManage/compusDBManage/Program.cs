using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compusDBManage
{
    class Program
    {
        static void Main(string[] args)
        {
            Request req = new Request("2018302110248", "061314", "19990606");
            string a = req.get_info();
            Console.WriteLine(a);
            string b = req.get_course();
            Console.WriteLine(b);
            string c = req.get_score();
            Console.WriteLine(c);

            Course co = new Course(4,20183011,"操作系统","专业必修","普通","计算机学院","王磊","计科", "9：50-11：25", "周四:1-16周,每1周;6-8节,3区,1-630", 2018302110253);
            Course co1 = new Course(4, 20183012, "组合数学", "专业必修", "普通", "计算机学院", "玉玉", "计科", "9：50-11：25", "周二:1-16周,每1周;6-8节,3区,1-630", 2018302110253);
            Course co3 = new Course(4, 20183013, "离散数学", "专业必修", "普通", "计算机学院", "憨憨", "计科", "9：50-11：25", "周五:1-16周,每1周;3-5节,3区,1-630", 2018302110253);
            Course co4 = new Course(4, 20183014, "操作系统", "专业必修", "普通", "计算机学院", "王磊", "计科", "9：50-11：25", "周日:1-16周,每1周;1-2节,3区,1-630", 2018302110253);
            Course co2 = new Course(4, 20183025, "计网", "专业必修", "普通", "计算机学院", "谢哈", "计科", "8：00-11：25", "周三:1-16周,每1周;6-8节,3区,1-630", 2018302110253);
            Course co5 = new Course(4, 20183016, "操作系统设计", "专业必修", "普通", "计算机学院", "王磊", "计科", "9：50-11：25", "周四:1-16周,每1周;6-8节,3区,1-630", 2018302110245);
            Course co6 = new Course(4, 20183017, "组合数学", "专业必修", "普通", "计算机学院", "玉玉", "计科", "9：50-11：25", "周四:1-16周,每1周;6-8节,3区,1-630", 2018302110245);
            Course co7 = new Course(4, 20183018, "离散数学", "专业必修", "普通", "计算机学院", "憨憨", "计科", "9：50-11：25", "周五:1-16周,每1周;3-5节,3区,1-630", 2018302110245);
            Course co8 = new Course(4, 20183019, "操作系统设计", "专业必修", "普通", "计算机学院", "王磊", "计科", "9：50-11：25", "周日:1-16周,每1周;1-2节,3区,1-630", 2018302110245);
            Course co9 = new Course(4, 20183001, "计网", "专业必修", "普通", "计算机学院", "谢哈", "计科", "8：00-11：25", "周三:1-16周,每1周;6-8节,3区,1-630", 2018302110245);
            CourseScore cs0 = new CourseScore("计算机网络", 95,0 , 2001532450, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs1 = new CourseScore("操作系统", 95, 0, 2001532451, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs2 = new CourseScore("离散数学", 95, 0, 2001532452, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs3 = new CourseScore("组合数学", 95, 0, 2001532453, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs4 = new CourseScore("大学英语3", 95, 0, 2001532454, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs5 = new CourseScore("操作系统", 95, 0, 2001532455, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs6 = new CourseScore("基础体育", 95, 0, 2001532456, 2018302110253, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs7 = new CourseScore("计算机网络", 95, 0, 2001532450, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs8 = new CourseScore("操作系统", 95, 0, 2001532451, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs9 = new CourseScore("离散数学", 95, 0, 2001532452, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs10 = new CourseScore("组合数学", 95, 0, 2001532453, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs11 = new CourseScore("大学英语3", 95, 0, 2001532454, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs12 = new CourseScore("操作系统", 95, 0, 2001532455, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            CourseScore cs13 = new CourseScore("基础体育", 95, 0, 2001532456, 2018302110245, "专业必修", 3.0, "蒋老师", "计算机学院", 2018, true);
            User user0 = new User(2018302110253, 2018, "123456", "123456", "蒋海澜", "计算机学院", "女", "计算机科学与技术", "");
            User user1 = new User(2018302110245, 2018, "123456", "123456", "于宸欣", "计算机学院", "女", "计算机科学与技术", "");
            user0.Add(user0);
            user0.Add(user1);
            cs0.addCourseScore(cs0);
            cs0.addCourseScore(cs1);
            cs0.addCourseScore(cs2);
            cs0.addCourseScore(cs3);
            cs0.addCourseScore(cs4);
            cs0.addCourseScore(cs5);
            cs0.addCourseScore(cs6);
            cs0.addCourseScore(cs7);
            cs0.addCourseScore(cs8);
            cs0.addCourseScore(cs9);
            cs0.addCourseScore(cs10);
            cs0.addCourseScore(cs11);
            cs0.addCourseScore(cs12);
            cs0.addCourseScore(cs13);
            co.Add(co);
            co.Add(co1);
            co.Add(co2);
            co.Add(co3);
            co.Add(co4);
            co.Add(co5);
            co.Add(co6);
            co.Add(co7);
            co.Add(co8);
            co.Add(co9);
            
        }
    }
}
