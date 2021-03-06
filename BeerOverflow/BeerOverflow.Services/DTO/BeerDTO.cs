﻿
using BeerOverflow.Services.DTO.Contracts;

namespace BeerOverflow.Services.DTO
{
    public class BeerDTO : IBeerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BeerType { get; set; }
        public string Brewery { get; set; }
        public string BreweryCountry { get; set; }
        public double AlcoholByVolume { get; set; }
        public int Likes { get; set; }
    }
}
