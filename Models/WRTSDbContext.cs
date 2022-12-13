﻿using Microsoft.EntityFrameworkCore;


namespace wrts.Models
{
    public class WRTSDbContext  : DbContext
    {
        public DbSet<Ramp> Ramps { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=WRTS; Trusted_Connection=True;");
        }
    }
    
}
