using System;
using Microsoft.EntityFrameworkCore;

namespace LuoJiaCampus_Server.Models {
    public class MyDBContext: DbContext {
        public MyDBContext(DbContextOptions<MyDBContext> options): base(options) {
            Console.WriteLine("init Database");
            this.Database.EnsureCreated();
        }

        public DbSet<News> news { get; set; }
        public DbSet<User> users { get; set; }
    }


}