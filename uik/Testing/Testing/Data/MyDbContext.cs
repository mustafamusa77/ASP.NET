using Microsoft.EntityFrameworkCore;
using System;
using Testing.Models;

namespace Testing.Data
{
    public class MyDbContext: MyDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

    }
}
