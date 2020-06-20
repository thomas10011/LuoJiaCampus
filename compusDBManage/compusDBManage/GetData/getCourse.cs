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
    class getCourse
   {
        public double credits { get; set; } // 学分
        public long courseNum { get; set; }
        public string courseName { get; set; }
        public string courseType { get; set; }
        public string leranTyoe { get; set; }
        public string school { get; set; }
        public string teacherName { get; set; }
        public string major { get; set; }
        public string learnTime { get; set; }
        public string courseTime { get; set; }

        public getCourse() { }
        public getCourse(string co,long id)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(co);          

            for (int i = 0; i < ja.Count; i++)
            {
                JObject jo = (JObject)ja[i];
                this.credits = (short)jo["credits"];
                this.courseNum = (long)jo["courseNum"];
                this.courseName = jo["courseName"].ToString();
                this.courseType = jo["courseType"].ToString();
                this.leranTyoe= jo["learnType"].ToString();
                this.school= jo["school"].ToString();
                this.teacherName= jo["teacherName"].ToString();
                this.major= jo["major"].ToString();
                this.learnTime= jo["learnTime"].ToString();
                this.courseTime= jo["courseTime"].ToString();

                Course cou = new Course(this.credits,this.courseNum,this.courseName,this.courseType,this.leranTyoe,this.school,this.teacherName,this.major,this.learnTime,this.courseTime,id);
                cou.Add(cou);

            }
            Console.WriteLine(co);
        }

    }
}
