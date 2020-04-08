﻿using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using BeerOverflow.Models.Enums;

namespace BeerOverflow.Services
{
    public class BeerService : IBeerService
    {
        public IBeerDTO CreateBeer(IBeerDTO beerDTO)
        {
            var beer = new Beer(beerDTO.Name, (BeerType)Enum.Parse(typeof(BeerType), beerDTO.BeerType, true), beerDTO.Brewery, beerDTO.Country, beerDTO.AlcoholByVolume);
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
                    BeerType = x.BeerType.ToString(),
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
                Id = beer.Id,
                Name = beer.Name,
                BeerType = beer.BeerType.ToString(),
                Brewery = beer.Brewery,
                Country = beer.Country,
                AlcoholByVolume = beer.AlcoholByVolume,
            };

            return beerDTO;
        }
        public BeerDTO UpdateBeer(int id, string name, string beerType, string brewery, string country, double AbV)
        {
            var beer = Database.Database.Beers
                .Where(b => b.IsDeleted == false)
                .FirstOrDefault(b => b.Id == id);
            beer.Name = name;
            beer.BeerType = (BeerType)Enum.Parse(typeof(BeerType), beerType, true);
            beer.Brewery = brewery;
            beer.Country = country;
            beer.AlcoholByVolume = AbV;

            var beerDTO = new BeerDTO
            {
                Name = beer.Name,
                BeerType = beer.BeerType.ToString(),
                Brewery = beer.Brewery,
                Country = beer.Country,
                AlcoholByVolume = beer.AlcoholByVolume,
            };
            return beerDTO;
        }
    }
}

