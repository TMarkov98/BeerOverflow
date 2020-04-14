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
        public DbSet<WishlistBeer> WishlistBeers { get; set; }
        public DbSet<BeerDrank> BeersDrank { get; set; }
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

            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Country>().Property(c => c.CountryCode).HasColumnType("char(2)");

            modelBuilder.Entity<Review>().Property(r => r.CreatedOn).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Rating).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Text).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<BeerDrank>().HasKey(ub => new { ub.UserId, ub.BeerId });
            modelBuilder.Entity<BeerDrank>().HasOne(ub => ub.User).WithMany(u => u.BeersDrank).HasForeignKey(u => u.UserId);

            modelBuilder.Entity<WishlistBeer>().HasKey(ub => new { ub.UserId, ub.BeerId });
            modelBuilder.Entity<WishlistBeer>().HasOne(ub => ub.User).WithMany(u => u.Wishlist).HasForeignKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
