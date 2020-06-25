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
    class getComment
    {
        public int id { get; set; }
        public string text { get; set; }
        public string createdTime { get; set; }
        public long userid { get; set; }
        public long newsid { get; set; }

        public getComment() { }
        public getComment(int id,string text,string createdTime,long userid,long useid)
        {

        }
    }
}
