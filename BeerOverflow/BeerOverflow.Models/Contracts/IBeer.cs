using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IBeer
    {
        string Name { get; set; }
        BeerType BeerType { get; set; }
        int BreweryId { get; set; }
        IBrewery Brewery { get; set; }
        double AlcoholByVolume { get; set; }
        ICollection<IReview> Reviews { get; set; }
    }
}
