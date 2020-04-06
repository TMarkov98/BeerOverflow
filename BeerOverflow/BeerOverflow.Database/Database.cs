using BeerOverflow.Models;
using System.Collections.Generic;

namespace BeerOverflow.Database
{
    public class Database
    {
        static Database()
        {
            Beers = new List<Beer>();
            SeedData();
        }
        public static List<Beer> Beers { get; set; }
        public static void SeedData()
        {
            Beers.AddRange(new List<Beer>
            {
                new Beer
                {
                    Id = 1,
                    Name = "Balter IIPA",
                    BeerType = Models.Enums.BeerType.Ipa,
                    Brewery = "Australia",
                    AlcoholByVolume = 4.5
                },
                new Beer
                {
                    Id = 3,
                    Name = "BentSpoke Cluster 8",
                    BeerType = Models.Enums.BeerType.PaleAle,
                    Brewery = "Australia",
                    AlcoholByVolume = 5
                },
                new Beer
                {
                    Id = 2,
                    Name = "Stone & Wood Pacific Ale",
                    BeerType = Models.Enums.BeerType.PaleAle,
                    Brewery = "Australia",
                    AlcoholByVolume = 7.5
                },
                new Beer
                {
                    Id = 4,
                    Name = "Modus Operandi Former Tenant",
                    BeerType = Models.Enums.BeerType.IrishRedAle,
                    Brewery = "Australia",
                    AlcoholByVolume = 6.5
                }
            });
        }
    }
}
