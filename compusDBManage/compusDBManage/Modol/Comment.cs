using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace compusDBManage
{
    public class Comment
    {
        [Key]        
        public int id { get; set; }//主键自增长
        [Required]
        public string text { get; set; }
        public string createdTime { get; set; }
        [Required]
        public long userid { get; set; }
        [Required]
        public virtual News newsid { get; set; }//外键

        public Comment() { }

        public Comment(string Text,long NewsId,long userId) {
            this.text =Text;
            this.createdTime = System.DateTime.Now.ToString();
            this.userid = userId;
            News n = new News();
            try
            {
                n = n.QueryId(NewsId);
                this.newsid = n;
                Console.WriteLine(n.id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }          
        }

        //增加一条评论
        public void Add(Comment comment)
        {
            using (var db = new compusDB())
            {
                var com = db.Comment.Where(p => p.id == comment.id).FirstOrDefault();
                if (com== null)
                {
                    //防止在News再添加一个对象
                    var ne = db.News.Where(p => p.id == comment.newsid.id).FirstOrDefault();
                    comment.newsid = ne;
                    comment.newsid.commentNum++;//对应的新鲜事的评论数加一

                    com = comment;
                    db.Comment.Add(com);                    
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    Console.WriteLine(com.text);
                }
                else
                {
                    Console.WriteLine("该数据已存在");
                }

            }
        }

        //查找所有的评论
        public List<Comment> Query()
        {
            using (var context = new compusDB())
            {
                List<Comment> comm = new List<Comment>();
                comm = context.Comment.ToList();
                if (comm != null) { return comm; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据用户id查找记录
        public List<Comment> QueryUserId(long useid)
        {
            using (var context = new compusDB())
            {
                List<Comment> comm = new List<Comment>();
                comm = context.Comment.Where(p=>p.userid==userid).ToList();
                if (comm != null) { return comm; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据评论id查找记录
        public Comment queryId(long id)
        {
            using (var context = new compusDB())
            {
                Comment comm = new Comment();
                comm = context.Comment.Where(p => p.id == id).FirstOrDefault();
                if (comm != null) { return comm; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据新鲜事id查找记录
        public List<Comment> queryNewId(long id)
        {
            using (var context = new compusDB())
            {
                List<Comment> comm = new List<Comment>();
                comm = context.Comment.Where(p => p.newsid.id == id).ToList();
                if (comm != null) { return comm; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据评论内容查找记录
        public Comment queryText(string text)
        {
            using (var context = new compusDB())
            {
                Comment comm = new Comment();
                comm = context.Comment.Where(p => p.text == text).FirstOrDefault();
                if (comm != null) { return comm; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据学号查询姓名
        public string getName(long id)
        {
            using (var context = new compusDB())
            {
                var users = context.User.Where(p =>p.id == id).FirstOrDefault();
                if (users != null) { return users.nmae; }
                else { Console.WriteLine("不存在该记录"); return null;  }
            }
        }

        //根据评论id删除
        public void delectId(int id)
        {
            using (var context = new compusDB())
            {
                var comment = context.Comment.Where(p => p.id == id).FirstOrDefault();
                if (comment != null)
                {
                    context.Comment.Remove(comment);
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //根据用户id删除该用户写的全部评论
        public void delectUserId(int useid)
        {
            using (var context = new compusDB())
            {
                var comment = context.Comment.Where(p => p.userid == userid).FirstOrDefault();
                if (comment != null)
                {
                    context.Comment.Remove(comment);
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //根据评论内容删除记录
        public void delectText(string text)
        {
            using (var context = new compusDB())
            {
                var comment = context.Comment.Where(p => p.text == text).FirstOrDefault();
                if (comment != null)
                {
                    context.Comment.Remove(comment);
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //删除所有数据
        public void DeleteAll()
        {
            using (var context = new compusDB())
            {
                var comm = context.Comment.ToList();
                if (comm != null)
                {
                    foreach (Comment co in comm)
                    {
                        context.Comment.Remove(co);
                        Console.WriteLine("已删除");
                    }
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //根据评论id,修改评论内容
        public void ModifyId(int id,string text)
        {
            using (var context = new compusDB())
            {
                var comm= context.Comment.Where(p => p.id == id).FirstOrDefault();
                if (comm != null)
                {
                    comm.text = text;
                    comm.createdTime = System.DateTime.Now.ToString();
                    Console.WriteLine(comm.text);
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //根据评论，修改评论内容
        public void modifyText(string oldtext, string text)
        {
            using (var context = new compusDB())
            {
                var comm = context.Comment.Where(p => p.text == oldtext).FirstOrDefault();
                if (comm != null)
                {
                    comm.text = text;
                    comm.createdTime = System.DateTime.Now.ToString();
                    Console.WriteLine("已修改");
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }
    }
}
