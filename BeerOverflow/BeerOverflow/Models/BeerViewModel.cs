using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class BeerViewModel
    {
        public string Name { get; set; }
        public BeerType BeerType { get; set; }
        public string Brewery { get; set; }
        public double AlcoholByVolume { get; set; }
        public string Country { get; set; }
    }
}
