using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IBrewery
    {
        string Name { get; set; }
        Country BreweryCountry { get; set; }
    }
}
