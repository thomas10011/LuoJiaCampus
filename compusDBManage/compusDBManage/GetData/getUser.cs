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
    class getUser
    {
       
        public long id { get; set; }
        public short grade { get; set; }
        public string password { get; set; }
        public string portalpwd { get; set; }
        public string nmae { get; set; }
        public string school { get; set; }
        public string gender { get; set; }
        public string major { get; set; }
        public string avatar { get; set; }

        public getUser() { }
        public getUser(string jsonArrayText1,string token)
        {
            JObject us = (JObject)JsonConvert.DeserializeObject(jsonArrayText1);
                this.id = (long)us["id"];
                this.grade = (short)us["grade"];
                this.password = us["password"].ToString();
                this.portalpwd = us["portalpwd"].ToString();
                this.nmae = us["nmae"].ToString();
                this.school = us["school"].ToString();
                this.gender = us["gender"].ToString();
                this.major = us["major"].ToString();
                this.avatar = us["avatar"].ToString();

                User user = new User(this.id, this.grade, this.password, this.portalpwd, this.nmae, this.school, this.gender, this.major,this.avatar,token);
                user.Add(user);
            
        }
    }
}
