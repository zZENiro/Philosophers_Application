using Microsoft.EntityFrameworkCore;
using Philosophers_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Philosophers_Application.Data
{
    public class PhilosophersDbContext : DbContext
    {
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Philosopher> Philosophers { get; set; }
        public DbSet<Country> Countries { get; set; }

        public PhilosophersDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhilosopherDirection>()
                .HasKey(k => new { k.DirectionId, k.PhilosopherId })
                .HasName("Name");

            modelBuilder.Entity<PhilosopherDirection>()
                .HasOne(p => p.Philosopher)
                .WithMany(pd => pd.PhilosopherDirection)
                .HasForeignKey(p => p.PhilosopherId);

            modelBuilder.Entity<PhilosopherDirection>()
                .HasOne(d => d.Direction)
                .WithMany(pd => pd.PhilosopherDirection)
                .HasForeignKey(d => d.DirectionId);
        }
    }
}
