using BeerOverflow.Models;

using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Database
{
    public class Database
    {
        static Database()
        {
            Beers = new List<Beer>();
            Breweries = new List<Brewery>();
            Countries = new List<Country>();
            SeedData();
        }
        public static List<Beer> Beers { get; set; }
        public static List<Brewery> Breweries { get; set; }
        public static List<Country> Countries { get; set; }
        public static void SeedData()
        {
            Beers.AddRange(new List<Beer>
            {
                new Beer
                {
                    Id = 1,
                    Name = "Balter IIPA",
                    Type = new BeerType{ Name = "Ipa" },
                    Brewery = new Brewery
                    {
                        Name = "NaPeshoZadniqDvor",
                        BreweryCountry =new Country{
                        Name = "Bulgaria",
                        CountryCode = "BG"}
                    },
                    AlcoholByVolume = 4.5,
                }
            });
            Breweries.AddRange(new List<Brewery>
            {
                new Brewery
                {
                    Id = 1,
                    Name = "NaPeshoZadniqDvor",
                    BreweryCountry = new Country
                    {
                        Name = "Bulgaria",
                        CountryCode = "BG"
                    }
                }
            });
            Countries.AddRange(new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "Bulgaria",
                    CountryCode = "BG"
                }
            });
        }
    }
}