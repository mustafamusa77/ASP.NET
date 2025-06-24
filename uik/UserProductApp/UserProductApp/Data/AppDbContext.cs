using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserProductApp.Models;

namespace UserProductApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
