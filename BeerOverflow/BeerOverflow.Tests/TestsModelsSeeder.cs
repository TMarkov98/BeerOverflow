using BeerOverflow.Models;
using BeerOverflow.Services.DTO;
using System;

namespace BeerOverflow.Tests
{
    public class TestsModelsSeeder
    {
        //BeerType Seeders
        public static BeerType SeedBeerType()
        {
            return new BeerType()
            {
                Id = 1,
                Name = "Brown Ale",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerType SeedBeerType2()
        {
            return new BeerType()
            {
                Id = 2,
                Name = "Pale Ale",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerType SeedBeerType3()
        {
            return new BeerType()
            {
                Id = 3,
                Name = "IPA",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerTypeDTO SeedBeerTypeDTO()
        {
            return new BeerTypeDTO()
            {
                Id = 1,
                Name = "Brown Ale"
            };
        }
        //Brewery Seeders
        public static Brewery SeedBrewery()
        {
            var brewery = new Brewery()
            {
                Id = 1,
                Name = "BreweryName",
                CountryId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            return brewery;
        }
        public static Brewery SeedBrewery2()
        {
            var brewery = new Brewery()
            {
                Id = 2,
                Name = "BreweryName2",
                CountryId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            return brewery;
        }
        public static Brewery SeedBrewery3()
        {
            var brewery = new Brewery()
            {
                Id = 3,
                Name = "BreweryName3",
                CountryId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            return brewery;
        }
        public static BreweryDTO SeedBreweryDTO()
        {
            return new BreweryDTO()
            {
                Id = 1,
                Name = "BreweryName",
                Country = "Bulgaria"
            };
        }
        //Country Seeders
        public static Country SeedCountry()
        {
            return new Country()
            {
                Id = 1,
                Name = "Bulgaria",
                Code = "BG"
            };
        }
        public static Country SeedCountry2()
        {
            return new Country()
            {
                Id = 2,
                Name = "Bulgaria2",
                Code = "BG"
            };
        }
        public static Country SeedCountry3()
        {
            return new Country()
            {
                Id = 3,
                Name = "Bulgaria3",
                Code = "BG"
            };
        }
        public static CountryDTO SeedCountryDTO()
        {
            return new CountryDTO()
            {
                Id = 1,
                Name = "Bulgaria",
                CountryCode = "BG"
            };
        }
        //Seeds beers
        public static Beer SeedBeer()
        {
            return new Beer()
            {
                Id = 1,
                Name = "BeerName",
                TypeId = 1,
                BreweryId = 1,
                AlcoholByVolume = 4.5,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static Beer SeedBeer2()
        {
            return new Beer()
            {
                Id = 2,
                Name = "OtherBeerName",
                TypeId = 1,
                BreweryId = 1,
                AlcoholByVolume = 5,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static Beer SeedBeer3()
        {
            return new Beer()
            {
                Id = 3,
                Name = "NewBeerName",
                TypeId = 1,
                BreweryId = 1,
                AlcoholByVolume = 12,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerDTO SeedBeerDTO()
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
        public static UserRole SeedUserRole()
        {
            return new UserRole()
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "ADMIN"
            };
        }
        //Seeds users
        public static User SeedUser()
        {
            return new User()
            {
                Id = 1,
                UserName = "UserName",
                Email = "username@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static User SeedUser2()
        {
            return new User()
            {
                Id = 2,
                UserName = "OtherUserName",
                Email = "otherusername@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static User SeedUser3()
        {
            return new User()
            {
                Id = 3,
                UserName = "NewUserName",
                Email = "newusername@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static UserDTO SeedUserDTO()
        {
            var userDTO = new UserDTO()
            {
                Id = 1,
                UserName = "UserName",
                Email = "username@biri.com",
                IsBanned = false,
            };
            return userDTO;
        }
        //Seeds reviews
        public static Review SeedReview()
        {
            var review = new Review()
            {
                Id = 1,
                Name = "ReviewName",
                Text = "Nice beer!",
                TargetBeerId = 1,
                AuthorId = 1,
                Rating = 7,
            };
            return review;
        }
        public static Review SeedReview2()
        {
            var review = new Review()
            {
                Id = 2,
                Name = "OtherReviewName",
                Text = "Very nice beer!",
                Rating = 8,
                TargetBeerId = 2,
                AuthorId = 1,
            };
            return review;
        }
        public static Review SeedReview3()
        {
            var review = new Review()
            {
                Id = 3,
                Name = "NewReviewName",
                Text = "Now that is a nice beer!",
                Rating = 9,
                TargetBeerId = 3,
                AuthorId = 1,
            };
            return review;
        }
        public static ReviewDTO SeedReviewDTO()
        {
            var reviewDTO = new ReviewDTO()
            {
                Id = 1,
                Name = "ReviewName",
                Author = "UserName",
                Text = "Very Nice Beer Man!",
                Rating = 6,
                TargetBeer = "BeerName"
            };
            return reviewDTO;
        }
    }
}
