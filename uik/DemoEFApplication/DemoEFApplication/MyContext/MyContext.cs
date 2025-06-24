using DemoEFApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Runtime.InteropServices;

namespace DemoEFApplication.MyContext
{
    public class MyContext:DbContext
    {
        private object dbContextOptionsBuilder;

        public MyContext(DbContextOptions<MyContext> myContext) : base(myContext)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextoptionsBuilder)
        {
            base.OnConfiguring(dbContextoptionsBuilder);
            var buider = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = buider.Build();
            var conString = config.GetConnectionString("MyDbConnectionString");
            dbContextoptionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
