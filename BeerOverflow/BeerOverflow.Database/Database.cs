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
            SeedData();
        }
        public static List<Beer> Beers { get; set; }
        public static void SeedData()
        {
            Beers.AddRange(new List<Beer>
            {
                new Beer
                (
                    "Balter IIPA",
                    Models.Enums.BeerType.Ipa,
                    "Bulgaria",
                    "Australia",
                    4.5
                ),
                new Beer
                (
                    "BentSpoke Cluster 8",
                    Models.Enums.BeerType.PaleAle,
                    "Neptun",
                    "Australia",
                    5
                ),
                new Beer
                (
                    "Stone & Wood Pacific Ale",
                    Models.Enums.BeerType.PaleAle,
                    "Mars",
                    "Australia",
                    7.5
                ),
                new Beer
                (
                    "Modus Operandt",
                    Models.Enums.BeerType.IrishRedAle,
                    "Bulgaria",
                    "Australia",
                    6.5
                )
            });
        }
    }
}
