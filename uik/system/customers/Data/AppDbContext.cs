using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }

    
}