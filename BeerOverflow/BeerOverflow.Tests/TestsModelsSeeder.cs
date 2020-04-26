using BeerOverflow.Models;
using BeerOverflow.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests
{
    public class TestsModelsSeeder
    {
        //BeerType Seeders
        public static BeerType Seed_BeerType()
        {
            return new BeerType()
            {
                Id = 1,
                Name = "Brown Ale",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerType Seed_BeerType_v2()
        {
            return new BeerType()
            {
                Id = 2,
                Name = "Pale Ale",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerType Seed_BeerType_v3()
        {
            return new BeerType()
            {
                Id = 3,
                Name = "IPA",
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static BeerTypeDTO Seed_BeerTypeDTO()
        {
            return new BeerTypeDTO()
            {
                Id = 1,
                Name = "Brown Ale"
            };
        }
        //Brewery Seeders
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
        public static Brewery Seed_Brewery_v2()
        {
            var country = new Country()
            {
                Id = 2,
                Name = "Bulgaria2",
                Code = "BG"
            };
            var brewery = new Brewery()
            {
                Id = 2,
                Name = "BreweryName2",
                Country = country,
                CreatedOn = DateTime.UtcNow,
            };
            return brewery;
        }
        public static Brewery Seed_Brewery_v3()
        {
            var country = new Country()
            {
                Id = 3,
                Name = "Bulgaria3",
                Code = "BG"
            };
            var brewery = new Brewery()
            {
                Id = 3,
                Name = "BreweryName3",
                Country = country,
                CreatedOn = DateTime.UtcNow,
            };
            return brewery;
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
        //Country Seeders
        public static Country Seed_Country()
        {
            return new Country()
            {
                Id = 1,
                Name = "Bulgaria",
                Code = "BG"
            };
        }
        public static Country Seed_Country_v2()
        {
            return new Country()
            {
                Id = 2,
                Name = "Bulgaria2",
                Code = "BG"
            };
        }
        public static Country Seed_Country_v3()
        {
            return new Country()
            {
                Id = 3,
                Name = "Bulgaria3",
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
        //Seeds beers
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
        public static Beer Seed_Beer_v2()
        {
            var country = new Country()
            {
                Id = 2,
                Name = "Bulgaria",
                Code = "BG"
            };
            var brewery = new Brewery()
            {
                Id = 2,
                Name = "BreweryName",
                Country = country,
                CreatedOn = DateTime.UtcNow,
            };
            var beerType = new BeerType()
            {
                Id = 2,
                Name = "IPA",
                CreatedOn = DateTime.UtcNow,
            };
            return new Beer()
            {
                Id = 2,
                Name = "OtherBeerName",
                Type = beerType,
                Brewery = brewery,
                AlcoholByVolume = 5,
                CreatedOn = DateTime.UtcNow,
            };
        }
        public static Beer Seed_Beer_v3()
        {
            var country = new Country()
            {
                Id = 3,
                Name = "Bulgaria",
                Code = "BG"
            };
            var brewery = new Brewery()
            {
                Id = 3,
                Name = "BreweryName",
                Country = country,
                CreatedOn = DateTime.UtcNow,
            };
            var beerType = new BeerType()
            {
                Id = 3,
                Name = "Ale",
                CreatedOn = DateTime.UtcNow,
            };
            return new Beer()
            {
                Id = 3,
                Name = "NewBeerName",
                Type = beerType,
                Brewery = brewery,
                AlcoholByVolume = 12,
                CreatedOn = DateTime.UtcNow,
            };
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
        //Seeds users
        public static User Seed_User()
        {
            var role = new UserRole()
            {
                Id = 1,
                RoleName = "admin",
            };
            return new User()
            {
                Id = 1,
                UserName = "UserName",
                Email = "username@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
                Role = role,
            };
        }
        public static User Seed_User_v2()
        {
            var role = new UserRole()
            {
                Id = 2,
                RoleName = "guest",
            };
            return new User()
            {
                Id = 2,
                UserName = "OtherUserName",
                Email = "otherusername@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
                Role = role,
            };
        }
        public static User Seed_User_v3()
        {
            var role = new UserRole()
            {
                Id = 3,
                RoleName = "user",
            };
            return new User()
            {
                Id = 3,
                UserName = "NewUserName",
                Email = "newusername@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
                Role = role,
            };
        }
        public static UserDTO Seed_UserDTO()
        {
            var userDTO = new UserDTO()
            {
                Id = 1,
                UserName = "UserName",
                Email = "username@biri.com",
                IsBanned = false,
                Role = "admin"
            };
            return userDTO;
        }
        //Seeds reviews
        public static Review Seed_Review()
        {
            var role = new UserRole()
            {
                Id = 1,
                RoleName = "admin",
            };
            var user = new User()
            {
                Id = 1,
                UserName = "UserName",
                Email = "username@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
                Role = role,
            };
            var review = new Review()
            {
                Id = 1,
                Name = "ReviewName",
                Author = user,
                Text = "Nice beer!",
                Rating = 7,
            };
            return review;
        }
        public static Review Seed_Review_v2()
        {
            var role = new UserRole()
            {
                Id = 2,
                RoleName = "admin",
            };
            var user = new User()
            {
                Id = 2,
                UserName = "OtherUserName",
                Email = "otherusername@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
                Role = role,
            };
            var review = new Review()
            {
                Id = 2,
                Name = "OtherReviewName",
                Author = user,
                Text = "Very nice beer!",
                Rating = 8
            };
            return review;
        }
        public static Review Seed_Review_v3()
        {
            var role = new UserRole()
            {
                Id = 3,
                RoleName = "admin",
            };
            var user = new User()
            {
                Id = 3,
                UserName = "NewUserName",
                Email = "newusername@biri.com",
                IsBanned = false,
                CreatedOn = DateTime.UtcNow,
                Role = role,
            };
            var review = new Review()
            {
                Id = 3,
                Name = "NewReviewName",
                Author = user,
                Text = "Now that is a nice beer!",
                Rating = 9
            };
            return review;
        }
        public static ReviewDTO Seed_ReviewDTO()
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
