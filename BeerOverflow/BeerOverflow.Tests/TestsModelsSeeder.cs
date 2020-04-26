using BeerOverflow.Models;
using BeerOverflow.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests
{
    public class TestsModelsSeeder
    {
        public static BeerType Seed_BeerType()
        {
            return new BeerType()
            {
                Id = 1,
                Name = "Brown Ale",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static Brewery Seed_Brewery()
        {
            var country = new Country()
            {
                Id = 1,
                Name = "Bulgaria",
                Code = "BG"
            };
            var brewery = new Brewery()
            {
                Id = 1,
                Name = "BreweryName",
                Country = country,
                CreatedOn = DateTime.UtcNow,
            };
            return brewery;
        }
        public static BeerDTO Seed_BeerDTO()
        {
            return new BeerDTO()
            {
                Id = 1,
                Name = "BeerName",
                BeerType = "Brown Ale",
                Brewery = "BreweryName",
                BreweryCountry = "Bulgaria",
                AlcoholByVolume = 4.5,
            };
        }
        public static BreweryDTO Seed_BreweryDTO()
        {
            return new BreweryDTO()
            {
                Id = 1,
                Name = "BreweryName",
                Country = "Bulgaria"
            };
        }
        public static Country Seed_Country()
        {
            return new Country()
            {
                Id = 1,
                Name = "Bulgaria",
                Code = "BG"
            };
        }
        public static CountryDTO Seed_CountryDTO()
        {
            return new CountryDTO()
            {
                Id = 1,
                Name = "Bulgaria",
                CountryCode = "BG"
            };
        }
        public static Beer Seed_Beer()
        {
            var country = new Country()
            {
                Id = 1,
                Name = "Bulgaria",
                Code = "BG"
            };
            var brewery = new Brewery()
            {
                Id = 1,
                Name = "BreweryName",
                Country = country,
                CreatedOn = DateTime.UtcNow,
            };
            var beerType = new BeerType()
            {
                Id = 1,
                Name = "Brown Ale",
                CreatedOn = DateTime.UtcNow,
            };
            return new Beer()
            {
                Id = 1,
                Name = "BeerName",
                Type = beerType,
                Brewery = brewery,
                AlcoholByVolume = 4.5,
                CreatedOn = DateTime.UtcNow,
            };
        }
    }
}
