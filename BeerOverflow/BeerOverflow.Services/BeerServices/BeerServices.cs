using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services
{
    public class BeerServices : IBeerServices
    {
        private readonly BeerOverflowContext context = new BeerOverflowContext();

        public IBeerDTO CreateBeer(IBeerDTO beerDTO)
        {
            var beer = new Beer
            {
                Name = beerDTO.Name,
                Type = (BeerType)Enum.Parse(typeof(BeerType), beerDTO.BeerType, true),
                Brewery = new Brewery
                {
                    Name = beerDTO.Brewery,
                    Country = new Country
                    {
                        Name = beerDTO.BreweryCountry,
                    }
                },
                AlcoholByVolume = beerDTO.AlcoholByVolume
            };
            
            context.Beers.Add(beer);
            return beerDTO;
        }

        public bool DeleteBeer(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<BeerDTO> GetAllBeers()
        {
            var beers = context.Beers
                .Select(x => new BeerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    BeerType = x.Type.Name,
                    Brewery = x.Brewery.Name,
                    BreweryCountry = x.Brewery.Country.Name,
                    AlcoholByVolume = x.AlcoholByVolume,
                })
                .ToList();

            return beers;
        }

        public BeerDTO GetBeer(int id)
        {
            var beer = context.Beers.Include(b => b.Type).Include(b => b.Brewery).ThenInclude(br => br.Country)
                .FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            var beerDTO = new BeerDTO
            {
                Id = beer.Id,
                Name = beer.Name,
                BeerType = beer.Type.Name,
                Brewery = beer.Brewery.Name,
                BreweryCountry = beer.Brewery.Country.Name,
                AlcoholByVolume = beer.AlcoholByVolume,
            };

            return beerDTO;
        }
        public BeerDTO UpdateBeer(int id, string name, string beerType, string brewery, string breweryCountry, double AbV)
        {
            var beer = context.Beers
                .Where(b => b.IsDeleted == false)
                .FirstOrDefault(b => b.Id == id);
            beer.Name = name;
            beer.Type = (BeerType)Enum.Parse(typeof(BeerType), beerType, true);
            beer.Brewery = new Brewery
            {
                Name = brewery,
                Country = (Country)Enum.Parse(typeof(Country), breweryCountry, true)
            };
            beer.AlcoholByVolume = AbV;

            var beerDTO = new BeerDTO
            {
                Name = beer.Name,
                BeerType = beer.Type.Name,
                Brewery = beer.Brewery.Name,
                BreweryCountry = beer.Brewery.Country.Name,
                AlcoholByVolume = beer.AlcoholByVolume,
            };
            return beerDTO;
        }
    }
}

