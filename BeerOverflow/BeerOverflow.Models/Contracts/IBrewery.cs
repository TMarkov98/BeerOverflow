using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IBrewery : IDeletable, IAudible
    {
        int Id { get; }
        string Name { get; set; }
        Countries BreweryCountry { get; set; }
    }
}
