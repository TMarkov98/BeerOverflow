﻿namespace BeerOverflow.Models.Contracts
{
    public interface IBrewery
    {
        string Name { get; set; }
        int CountryId { get; set; }
        Country Country { get; set; }
    }
}
