using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}


        // creating my Db table for stocks
        public DbSet<Order> Orders { get; set; }
    }
}