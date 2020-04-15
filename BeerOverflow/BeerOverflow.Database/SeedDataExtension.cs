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
                        CountryCode = regionInfo.TwoLetterISORegionName
                    }
                );
                id++;
            }
            //SEED ALL BREWERIES
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 1,
                    Name = "Na Pesho Zadniq Dvor",
                    CountryId = 1,
                });
            //SEED ALL BEER TYPES
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 1,
                    Name = "PaleAle"
                });
            //SEED ALL BEERS
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 1,
                    Name = "Ot Na Pesho Zadniq Dvor Birata",
                    BreweryId = 1,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    Likes = 40,
                    TypeId = 1
                });
            //SEED ALL USER ROLES
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    RoleName = "User"
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
                    RoleId = 1
                });
            //SEED ALL REVIEWS
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    AuthorId = 1,
                    TargetBeerId = 1,
                    Likes = 2,
                    Name = "Na Pesho Review-to",
                    Text = "Mnoo dobra bira brat",
                    CreatedOn = DateTime.Now
                });
        }
    }
}

