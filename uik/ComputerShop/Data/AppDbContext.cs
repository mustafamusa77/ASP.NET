using Microsoft.EntityFrameworkCore;
using ComputerShop.Models;

namespace ComputerShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}