using Bus.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Route>()
                .HasMany(b => b.BusDetails)
                .WithOne(r => r.Route);
        }
        public DbSet<Route> Routes { get; set; }

        public DbSet<BusDetails> BusDetails { get; set; }
    }
}
