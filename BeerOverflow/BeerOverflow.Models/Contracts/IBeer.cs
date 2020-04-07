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
        string Brewery { get; set; }
        double AlcoholByVolume { get; set; }
        string Country { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime DeletedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
