using BeerOverflow.Models;
using BeerOverflow.Models.Enums;
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
            SeedData();
        }
        public static List<Beer> Beers { get; set; }
        public static List<Brewery> Breweries { get; set; }
        public static void SeedData()
        {
            Beers.AddRange(new List<Beer>
            {
                new Beer
                {
                    Id = 1,
                    Name = "Balter IIPA",
                    BeerType = BeerType.Ipa,
                    Brewery = new Brewery
                    {
                        Name = "NaPeshoZadniqDvor",
                        BreweryCountry = Country.BG
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
                    BreweryCountry = Country.BG
                }
            });
        }
    }
}
