using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class BeerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BeerType BeerType { get; set; }
        public string Brewery { get; set; }
        public string Country { get; set; }
        public double AlcoholByVolume { get; set; }
    }
}
