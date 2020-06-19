namespace compusDBManage
{
    using System;
    using System.Data.Entity;
    using System.Linq;


    public class compusDB : DbContext
    {
        public compusDB()
            : base("compusDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<compusDB>());
        }

         public DbSet<Comment> Comment { get; set; }
         public DbSet<User> User { get; set; }
         public DbSet<CourseScore> CourseScore { get; set; }
         public DbSet<Course> Course { get; set; }
         public DbSet<News> News { get; set; }
    }

}