using BeerOverflow.Models;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Database
{
    public class Database
    {
        static Database()
        {
            Beers = new List<Beer>();
        }
        public static List<Beer> Beers { get; set; }
        public static void SeedData()
        {
            Beers.AddRange(new List<Beer>
            {
                new Beer
                {
                    Id = 1
                }
            });
        }
    }
}
