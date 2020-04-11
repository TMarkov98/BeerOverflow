using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Database
{
    class BeerOverflowContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\TESTSQLSERVER;Database=BeerOverflow;Trusted_Connection=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().Property(b => b.Name).HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Beer>().HasOne(b => b.Type);
            modelBuilder.Entity<Beer>().Property(b => b.AlcoholByVolume).IsRequired();
            modelBuilder.Entity<Beer>().Property(b => b.CreatedOn).IsRequired();

            modelBuilder.Entity<BeerType>().Property(b => b.Name).IsRequired();

            modelBuilder.Entity<Brewery>().Property(b => b.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Brewery>().Property(b => b.CreatedOn).IsRequired();

            modelBuilder.Entity<Review>().Property(r => r.CreatedOn).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Rating).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Text).IsRequired();

            modelBuilder.Entity<User>().Property(r => r.UserName).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.Password).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.Email).HasMaxLength(50).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
