using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace gradeclass
{
    public class CourseManage
    {
        public DataTable lists = new DataTable();

        public string commend { get; set; }
        public MySqlConnection conn;
        public CourseManage()
        {
            DSConnection();
            lists = transtable(DSCommand("SELECT `courseNum`,`courseName`,`courseType`,`learnType`,`school`,`teacherName`,`major`,`credits`,`learnTime`,`courseTime` FROM `coursetable` WHERE `userid` = '2018302110245'"));//test
        }//
        //连接数据库
        public void DSConnection()
        {
            string connStr = "server=localhost;port=3306;user=root;password=121212; database=luojiacampus_client;";
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

     
    }
}
