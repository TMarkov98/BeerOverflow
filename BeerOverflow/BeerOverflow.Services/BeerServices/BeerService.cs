using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services
{
    public class BeerService : IBeerService
    {
        public IBeerDTO CreateBeer(IBeerDTO beerDTO)
        {
            var beer = new Beer
            {
                Name = beerDTO.Name,
                BeerType = (BeerType)Enum.Parse(typeof(BeerType), beerDTO.BeerType, true),
                Brewery = new Brewery
                {
                    Name = beerDTO.Brewery,
                    BreweryCountry = (Country)Enum.Parse(typeof(Country), beerDTO.BreweryCountry, true),
                },
                AlcoholByVolume = beerDTO.AlcoholByVolume
            };

            Database.Database.Beers.Add(beer);
            beer.Id = Database.Database.Beers.Count;
            return beerDTO;
        }

        public bool DeleteBeer(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<BeerDTO> GetAllBeers()
        {
            var beers = Database.Database.Beers
                .Select(x => new BeerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    BeerType = x.BeerType.Name,
                    Brewery = x.Brewery.Name,
                    BreweryCountry = x.Brewery.BreweryCountry.Name,
                    AlcoholByVolume = x.AlcoholByVolume,
                })
                .ToList();

            return beers;
        }

        public BeerDTO GetBeer(int id)
        {
            var beer = Database.Database.Beers
                .FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            var beerDTO = new BeerDTO
            {
                Id = beer.Id,
                Name = beer.Name,
                BeerType = beer.BeerType.Name,
                Brewery = beer.Brewery.Name,
                BreweryCountry = beer.Brewery.BreweryCountry.Name,
                AlcoholByVolume = beer.AlcoholByVolume,
            };

            return beerDTO;
        }
        public BeerDTO UpdateBeer(int id, string name, string beerType, string brewery, string breweryCountry, double AbV)
        {
            var beer = Database.Database.Beers
                .Where(b => b.IsDeleted == false)
                .FirstOrDefault(b => b.Id == id);
            beer.Name = name;
            beer.BeerType = (BeerType)Enum.Parse(typeof(BeerType), beerType, true);
            beer.Brewery = new Brewery
            {
                Name = brewery,
                BreweryCountry = (Country)Enum.Parse(typeof(Country), breweryCountry, true)
            };
            beer.AlcoholByVolume = AbV;

            var beerDTO = new BeerDTO
            {
                Name = beer.Name,
                BeerType = beer.BeerType.Name,
                Brewery = beer.Brewery.Name,
                BreweryCountry = beer.Brewery.BreweryCountry.Name,
                AlcoholByVolume = beer.AlcoholByVolume,
            };
            return beerDTO;
        }
    }
}

