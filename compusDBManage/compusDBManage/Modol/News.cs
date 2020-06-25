using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace compusDBManage
{
    public class News
    {
        [Key]
        public long id { get; set; }            //编号,自增长
        public int rates { get; set; }          //点赞数
        public int commentNum { get; set; }     //评论数
        [Required]
        public string text { get; set; }        //内容
        public string type { get; set; }        //类型   
        [Required]
        public string createdTime { get; set; }
        [Required]
        public long userid { get; set; }        //发表新鲜事的用户

        public News() { }
        public News(string text, string type,long userId)
        {
            this.text = text;
            this.type = type;
            this.createdTime = System.DateTime.Now.ToString();
            this.userid = userId;
        }

        //增加一条新鲜事
        public void Add(News co)
        {
            using (var db = new compusDB())
            {
                var ne = db.News.Where(p => p.id == co.id).FirstOrDefault();
                if (ne == null)
                {
                    ne = co;
                    db.News.Add(ne);
                    db.SaveChanges();
                    Console.WriteLine(ne.text);
                }
                else
                {
                    Console.WriteLine("该数据已存在");
                }

            }
        }

        //增加点赞数
        public void addRates(long id)
        {
            using (var context = new compusDB())
            {
                var ne = context.News.Where(p => p.id == id).FirstOrDefault();
                if (ne != null)
                {
                    ne.rates++;
                    Console.WriteLine(ne.rates);
                    context.SaveChanges();
                }
                else { Console.WriteLine("不存在记录"); }
            }
        }

        //查询所有
        public List<News> Query()
        {
            using (var context = new compusDB())
            {
                List<News> New = new List<News>();
                New = context.News.OrderByDescending(News => News.id).ToList();
                if (New != null) { return New; }
                else { Console.WriteLine("无记录"); return null; }
            }
        }

        //根据userid查询
        public List<News> QueryUserId(long userid)
        {
            using (var context = new compusDB())
            {
                List<News> news = new List<News>();
                news = context.News.Where(p => p.userid == userid).ToList();
                if (news != null) { return news; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }
        
        //根据id查询
        public News QueryId(long id)
        {
            using (var context = new compusDB())
            {
                var news = context.News.Where(p => p.id == id).FirstOrDefault();
                if (news != null) { return news; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据发表内容查询
        public News QueryText(string text)
        {
            using (var context = new compusDB())
            {
                News news = new News();
                news = context.News.Where(p => p.text == text).FirstOrDefault();
                if (news != null) { return news; }
                else { Console.WriteLine("记录不存在"); return null; }
            }
        }

        //根据id删除数据
        public void deleteId(long id)
        {
            using (var context = new compusDB())
            {
                var ne = context.News.Where(p => p.id == id).FirstOrDefault();
                if (ne != null)
                {
                    context.News.Remove(ne);
                    context.SaveChanges();
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //根据userid删除数据
        public void deleteUserId(long id)
        {
            using (var context = new compusDB())
            {
                var ne = context.News.Where(p => p.userid == id).ToList();
                if (ne != null)
                {
                    foreach (News s in ne)
                    {
                        context.News.Remove(s);
                        context.SaveChanges();
                        Console.WriteLine("已删除");
                    }
                }
                else { Console.WriteLine("记录不存在"); }
            }
        }

        //根据id修改，内容
        public void Modify(long id,string text)
        {
            using (var context=new compusDB())
            {
                var ne = context.News.Where(p => p.id == id).FirstOrDefault();
                if (ne != null)
                {
                    ne.text = text;
                    Console.WriteLine(ne.text);
                    context.SaveChanges();
                }
                else { Console.WriteLine("不存在记录"); }
            }
        }

    }
}
