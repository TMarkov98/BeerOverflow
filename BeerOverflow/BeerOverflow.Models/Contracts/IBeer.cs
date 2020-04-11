using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IBeer
    {
        string Name { get; set; }
        BeerType Type { get; set; }
        int BreweryId { get; set; }
        Brewery Brewery { get; set; }
        double AlcoholByVolume { get; set; }
        List<Review> Reviews { get; set; }
    }
}
