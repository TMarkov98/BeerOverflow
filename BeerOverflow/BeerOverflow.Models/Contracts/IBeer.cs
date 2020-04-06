using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    interface IBeer
    {
        string Name { get; set; }
        BeerType BeerType { get; set; }
        string Brewery { get; set; }
        double AlcoholByVolume { get; set; }
    }
}
