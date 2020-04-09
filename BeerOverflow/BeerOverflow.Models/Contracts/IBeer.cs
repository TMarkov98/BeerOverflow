using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IBeer : IDeletable, IAudible
    {
        int Id { get; }
        string Name { get; set; }
        BeerType BeerType { get; set; }
        IBrewery Brewery { get; set; }
        double AlcoholByVolume { get; set; }
        Countries Country { get; set; }

    }
}
