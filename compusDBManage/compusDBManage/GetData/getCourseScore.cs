using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Data;


namespace compusDBManage
{
    class getCourseScore
    {
        public short score { get; set; }
        public double gradePoint { get; set; }
        public long courseid { get; set; }
        public long userid { get; set; }
        public string courseType { get; set; }
        public double credits { get; set; }
        public string courseName { get; set; }
        public string teacherName { get; set; }
        public string school { get; set; }
        public short Year { get; set; }
        public bool  Term { get; set; }

        public getCourseScore() { }
        public getCourseScore(string ja1) {

            JArray ja = (JArray)JsonConvert.DeserializeObject(ja1);
            int i = 0;
            while (i < ja.Count)
            {
                JObject courseScore = (JObject)ja[i];
                this.score = (short)courseScore["score"];
                this.gradePoint = 0;
                this.courseid = (long)courseScore["courseid"];
                this.userid = (long)courseScore["userid"];
                this.courseType = courseScore["courseType"].ToString();
                this.credits = (double)courseScore["credits"];
                this.courseName = courseScore["courseName"].ToString();
                this.teacherName = courseScore["teacherName"].ToString();
                this.school = courseScore["school"].ToString();
                this.Year = (short)courseScore["year"];
                this.Term= (bool)courseScore["term"];

                CourseScore score = new CourseScore(this.courseName,this.score, this.gradePoint, this.courseid, this.userid, this.courseType, this.credits, this.teacherName, this.school, this.Year, this.Term);
                score.addCourseScore(score);
                i++;
            }

        }
        
    }
}
