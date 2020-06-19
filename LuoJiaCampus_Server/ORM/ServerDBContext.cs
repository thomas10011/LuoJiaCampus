using System;
using Microsoft.EntityFrameworkCore;

namespace LuoJiaCampus_Server.Models {
    public class ServerDBContext: DbContext {
        public ServerDBContext(DbContextOptions<ServerDBContext> options): base(options) {
            Console.WriteLine("init Database");
            this.Database.EnsureCreated();
        }

        public DbSet<News> news { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; } 
        public DbSet<CourseScore> courseScore { get; set; }
    }


}