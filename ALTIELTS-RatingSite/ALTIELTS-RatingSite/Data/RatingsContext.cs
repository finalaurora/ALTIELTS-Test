using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALTIELTS_RatingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ALTIELTS_RatingSite.Data
{
    public class RatingsContext: DbContext
    {
        public RatingsContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Rating>().ToTable("Rating");
        }
    }
}
