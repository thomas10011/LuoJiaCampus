using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace gradeclass
{
    public class GradeService
    {
        public DataTable scores = new DataTable();
        public string commend { get; set; }
        public MySqlConnection conn;
        public GradeService()
        {
            DSConnection();
            scores=transtable(DSCommand("SELECT * FROM `coursescore` WHERE `学号` = '2018302110253' "));

        }
        //连接数据库
        public void DSConnection()
        {
            string connStr = "server=localhost;port=3306;user=root;password=jhl794613285; database=luojiacampus_client;";
            conn = new MySqlConnection(connStr);
        }
        public MySqlDataAdapter DSCommand(string a)
        {
            MySqlCommand cmd = new MySqlCommand(a, conn);
            return new MySqlDataAdapter(cmd);
        }
        public DataTable transtable(MySqlDataAdapter reader)
        {
            DataTable dataTable = new DataTable();
            reader.Fill(dataTable);
            return dataTable;
        }
        public void findcourcescore(string a, string b, string c)
        {
            
            string sqlStr = "SELECT * FROM `coursescore`";
            bool e=false, d=false;
            if (a != "全部")
            {
                sqlStr += "WHERE`学年` LIKE '%" + a + "%'";
                d = true;
            }
            if (b != "全部")
            {
                if (d) sqlStr += "AND`课程类型` LIKE '%" + b + "%'";
                else sqlStr += "WHERE`课程类型` LIKE '%" + b + "%'";
                e = true;
            }
            if (c != "全部")
            {
                if (e|d) sqlStr += "AND`学期` LIKE '%" + c + "%'";
                else sqlStr += "WHERE`学期` LIKE '%" + c + "%'";
            }
            DSConnection();
            scores.Clear();
            scores = transtable(DSCommand(sqlStr));
        }
    }
}

