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
        public BeerType BeerType { get; set; }
        public string Brewery { get; set; }
        public string Country { get; set; }
        public double AlcoholByVolume { get; set; }
    }
}
