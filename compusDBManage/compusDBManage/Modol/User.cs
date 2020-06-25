using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace compusDBManage
{
    public class User
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public long id { get; set; }
        public short grade { get; set; }           //年级
        [Required]
        public string password { get; set; }        //信息门户密码
        [Required]
        public string portalpwd { get; set; }       //教务系统密码
        public string nmae { get; set; }
        public string school { get; set; }
        public string gender { get; set; }
        public string major { get; set; }
        public string avatar { get; set; }
        public string Token { get; set; } //头像路径

        public User() { }
        public User(long id1,short grade1,string pw,string poralpw,string name,string school1,string gender1,string  major1,string avatar1,string token) {

            this.id = id1;
            this.grade = grade1;
            this.password = pw;
            this.portalpwd = poralpw;
            this.nmae = name;
            this.gender = gender1;
            this.school = school1;
            this.major = major1;
            this.avatar = avatar1;
            this.Token = token;
        }

        public void Add(User us)
        {
            using (var context = new compusDB())
            {
                var use = context.User.Where(p => p.id == us.id).FirstOrDefault();
                if (use == null)
                {
                    use = us;
                    context.User.Add(us);
                    try { context.SaveChanges(); }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadLine();
                    }
                }
                else {
                    Console.WriteLine("数据已存在");
                }
            }
        }

        //根据学号添加图片路径
        public void addPic(long id,string address)
        {
            using (var context = new compusDB())
            {
                var us = context.User.Where(p => p.id == id).FirstOrDefault();
                if (us != null)
                {
                    us.avatar = address;
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //查询所有
        public List<User> Query()
        {
            List<User> users = new List<User>();
            using (var context = new compusDB())
            {
                users = context.User.ToList();
            }
                return users;
        }

        //根据学号查询
        public User queryId(long id)
        {   
            using (var context = new compusDB())
            {
                User users = new User();
                users = context.User.Where(p => p.id == id).FirstOrDefault();
                if (users != null) { return users; }
                else { return null;Console.WriteLine("不存在该记录"); }
            }
                
        }

        //根据名字查询
        public User queryName(string names)
        {
            using (var context = new compusDB())
            {
                User users = new User();
                users = context.User.Where(p => p.nmae==nmae).FirstOrDefault();
                if (users != null) { return users; }
                else { return null; Console.WriteLine("不存在该记录"); }
            }
        }

        //根据学号删除
        public void Delect(long id)
        {
            using (var context = new compusDB())
            {
                var us = context.User.Where(p => p.id == id).FirstOrDefault();
                if (us != null) {
                    context.User.Remove(us);
                    context.SaveChanges();
                }
            }
        }

        //根据学号修改头像路径
        public void Modify(long Id,string address)
        {
            using (var context = new compusDB())
            {
                User users = new User();
                users = context.User.Where(p => p.id == Id).FirstOrDefault();
                if (users != null) { users.avatar = address; }
                else { Console.WriteLine("不存在该记录"); }
            }
        }

        //根据名字修改头像路径
        public void ModifyName(long name, string address)
        {
            using (var context = new compusDB())
            {
                User users = new User();
                users = context.User.Where(p => p.nmae == nmae).FirstOrDefault();
                if (users != null) { users.avatar = address; }
                else { Console.WriteLine("不存在该记录"); }
            }
        }
    }
}
