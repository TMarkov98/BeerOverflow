﻿using System.Collections.Generic;

namespace BeerOverflow.Models.Contracts
{
    public interface IBeer
    {
        string Name { get; set; }
        int TypeId { get; set; }
        BeerType Type { get; set; }
        int BreweryId { get; set; }
        Brewery Brewery { get; set; }
        double AlcoholByVolume { get; set; }
        List<Review> Reviews { get; set; }
    }
}
