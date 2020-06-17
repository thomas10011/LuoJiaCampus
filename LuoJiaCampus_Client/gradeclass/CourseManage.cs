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
            lists = transtable(DSCommand("SELECT * FROM `course` WHERE `学号` = '2018302110253' "));//test
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

     
    }
}
