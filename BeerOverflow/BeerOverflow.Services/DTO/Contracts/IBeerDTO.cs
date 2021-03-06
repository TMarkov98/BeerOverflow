﻿namespace BeerOverflow.Services.DTO.Contracts
{
    public interface IBeerDTO
    {
        int Id { get; set; }
        string Name { get; set; }
        string BeerType { get; set; }
        string Brewery { get; set; }
        string BreweryCountry { get; set; }
        double AlcoholByVolume { get; set; }
        int Likes { get; set; }
    }
}
