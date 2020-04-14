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
            //SEED ALL BEERS
            //SEED ALL USERS
            //SEED ALL REVIEWS
        }
    }
}

