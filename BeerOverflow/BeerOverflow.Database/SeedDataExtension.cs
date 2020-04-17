using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BeerOverflow.Database
{
    public static class SeedDataExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //SEED ALL COUNRTIES

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo regionInfo = new RegionInfo(ci.Name);
                if (countries.Count(x => x.EnglishName == regionInfo.EnglishName) <= 0)
                    countries.Add(regionInfo);
            }
            int id = 1;
            foreach (RegionInfo regionInfo in countries.OrderBy(x => x.EnglishName))
            {
                modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = id,
                        Name = regionInfo.EnglishName,
                        Code = regionInfo.TwoLetterISORegionName
                    }
                );
                id++;
            }

            //SEED ALL BREWERIES

            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 1,
                    Name = "Mythos Breweries",
                    CountryId = 87,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 2,
                    Name = "Na Pesho Zadniq Dvor",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 3,
                    Name = "Na Pesho Predniq Dvor",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 4,
                    Name = "Na Pesho Leviq Dvor",
                    CountryId = 1,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 5,
                    Name = "Na Pesho Desniq Dvor",
                    CountryId = 2,
                });

            //SEED ALL BEER TYPES

            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 1,
                    Name = "Pale Lager"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 2,
                    Name = "Blonde Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 3,
                    Name = "Hefewizen"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 4,
                    Name = "Pale Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 5,
                    Name = "IPA"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 6,
                    Name = "Amber Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 7,
                    Name = "Irish Red Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 8,
                    Name = "Brown Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 9,
                    Name = "Porter"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 10,
                    Name = "Stout"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 11,
                    Name = "Pilsner"
                });

            //SEED ALL BEERS

            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 1,
                    Name = "Kaiser",
                    BreweryId = 1,
                    AlcoholByVolume = 5,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 2,
                    Name = "Ot Na Pesho Zadniq Dvor Birata",
                    BreweryId = 2,
                    AlcoholByVolume = 7.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 3,
                    Name = "Ot Na Pesho Predniq Dvor Birata",
                    BreweryId = 3,
                    AlcoholByVolume = 3.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 4,
                    Name = "Ot Na Pesho Leviq Dvor Birata",
                    BreweryId = 4,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 5,
                    Name = "Ot Na Pesho Desniq Dvor Birata",
                    BreweryId = 5,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });

            //SEED ALL USER ROLES

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    RoleName = "Admin"
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 2,
                    RoleName = "User"
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 3,
                    RoleName = "Guest"
                });

            //SEED ALL USERS

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreatedOn = DateTime.Now,
                    UserName = "Pesho",
                    Password = "NaPeshoParolata",
                    Email = "Pesho@biri.com",
                    RoleId = 2
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    CreatedOn = DateTime.Now,
                    UserName = "Gosho",
                    Password = "NaGoshoParolata",
                    Email = "Gosho@biri.com",
                    RoleId = 2
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 3,
                    CreatedOn = DateTime.Now,
                    UserName = "Tosho",
                    Password = "NaToshoParolata",
                    Email = "Tosho@biri.com",
                    RoleId = 2
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 4,
                    CreatedOn = DateTime.Now,
                    UserName = "Slavcho",
                    Password = "NaSlavchoParolata",
                    Email = "Slavcho@biri.com",
                    RoleId = 2
                });

            //SEED ALL REVIEWS

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    AuthorId = 1,
                    TargetBeerId = 1,
                    Name = "Na Pesho Review-to",
                    Text = "Mnoo dobra bira brat",
                    Rating = 10,
                    CreatedOn = DateTime.Now
                });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 2,
                    AuthorId = 2,
                    TargetBeerId = 3,
                    Name = "Na Gosho Review-to",
                    Text = "Evalata Pesho mnoo dobra bira",
                    Rating = 7,
                    CreatedOn = DateTime.Now
                });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 3,
                    AuthorId = 3,
                    TargetBeerId = 2,
                    Name = "Na Tosho Review-to",
                    Text = "Toz Pesho mnoo hubavi gi prai",
                    Rating = 8,
                    CreatedOn = DateTime.Now
                });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 4,
                    AuthorId = 4,
                    TargetBeerId = 1,
                    Name = "Kaiser nomer edno",
                    Text = "Bira ot butilka ne bqh pil do sq",
                    Rating = 10,
                    CreatedOn = DateTime.Now
                });
        }
    }
}

