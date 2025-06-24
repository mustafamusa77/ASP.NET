using Microsoft.EntityFrameworkCore;
using System;
using Visit.Models;

namespace Visit.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
