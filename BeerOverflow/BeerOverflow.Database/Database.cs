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
                (
                    "Balter IIPA",
                    Models.Enums.BeerType.Ipa,
                    new Brewery("NaPeshoZadniqDvor", "BG"),
                    Country.BG,
                    4.5
                ){Id = 1},
                new Beer
                (
                    "BentSpoke Cluster 8",
                    Models.Enums.BeerType.PaleAle,
                    new Brewery("NaHitlerZadniqDvor", "AU"),
                    Country.AU,
                    5
                ){ Id = 2},
                new Beer
                (
                    "Stone & Wood Pacific Ale",
                    Models.Enums.BeerType.PaleAle,
                    new Brewery("NaMerkelZadniqDvor", "GE"),
                    Country.GE,
                    7.5
                ){ Id = 3},
                new Beer
                (
                    "Modus Operandt",
                    Models.Enums.BeerType.IrishRedAle,
                    new Brewery("NaAlfZadniqDvor", "SE"),
                    Country.SE,
                    6.5
                ){ Id = 4}
            });
            Breweries.AddRange(new List<Brewery>
            {
                new Brewery("NaPeshoZadniqDvor", "BG"){Id = 1},
                new Brewery("NaHitlerZadniqDvor", "AU"){ Id = 2},
                new Brewery("NaMerkelZadniqDvor", "GE"){ Id = 3},
                new Brewery("NaAlfZadniqDvor", "SE"){ Id = 4}
            });
        }
    }
}
