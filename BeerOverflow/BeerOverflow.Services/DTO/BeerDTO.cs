using BeerOverflow.Models.Enums;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
