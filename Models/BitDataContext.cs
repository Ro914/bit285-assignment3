using System;
using Microsoft.EntityFrameworkCore;

namespace bit285_assignment2_login.Models
{
    public class BitDataContext :DbContext 
    {
        public BitDataContext(DbContextOptions<BitDataContext> options)
        :base(options)
        {
            Database.EnsureCreated();
        }
        //Access to Collections representing DB tables
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Program> Programs { get; set;  }

    }
}
