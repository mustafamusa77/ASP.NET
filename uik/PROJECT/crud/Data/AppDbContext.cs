
using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> news { get; set; }
    }
}
