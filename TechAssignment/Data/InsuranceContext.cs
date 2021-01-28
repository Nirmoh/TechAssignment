using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechAssignment.Models;

namespace TechAssignment.Data
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext (DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }

        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<MGA> MGA { get; set; }
        public DbSet<Advisor> Advisor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>().ToTable("Carrier");
            modelBuilder.Entity<MGA>().ToTable("MGA");
            modelBuilder.Entity<Advisor>().ToTable("Advisor");
        }
    }
}
