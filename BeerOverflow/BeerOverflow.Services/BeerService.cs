using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace BeerOverflow.Services
{
    public class BeerService : IBeerService
    {
        public IBeer CreateBeer(IBeerDTO beerDTO)
        {
            var beer = new Beer(beerDTO.Name, beerDTO.BeerType, beerDTO.Brewery, beerDTO.Country, beerDTO.AlcoholByVolume);
            Database.Database.Beers.Add(beer);
            return beer;
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
                    Name = x.Name,
                    BeerType = x.BeerType,
                    Brewery = x.Brewery,
                    Country = x.Country,
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
                Name = beer.Name,
                BeerType = beer.BeerType,
                Brewery = beer.Brewery,
                Country = beer.Country,
                AlcoholByVolume = beer.AlcoholByVolume,
            };

            return beerDTO;
        }
    }
}

