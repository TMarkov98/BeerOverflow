using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
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
        private readonly BeerOverflowContext _context;
        public BeerServices(BeerOverflowContext context)
        {
            this._context = context;
        }
        public IBeerDTO CreateBeer(IBeerDTO beerDTO)
        {
            var beerExists = _context.Beers
                .FirstOrDefault(b => b.Name == beerDTO.Name && b.Brewery.Name == beerDTO.Brewery);
            if (beerExists != null)
            {
                throw new ArgumentException("Beer with this name and brewery already exists.");
            };

            var beer = new Beer
            {
                Name = beerDTO.Name,
                Type = _context.BeerTypes
                    .FirstOrDefault(t => t.Name == beerDTO.BeerType)
                    ?? throw new ArgumentNullException("Beer Type not found."),
                Brewery = _context.Breweries
                    .FirstOrDefault(b => b.Name == beerDTO.Brewery)
                    ?? throw new ArgumentNullException("Brewery not found."),
                AlcoholByVolume = beerDTO.AlcoholByVolume
            };

            _context.Beers.Add(beer);
            _context.SaveChanges();
            return beerDTO;
        }

        public bool DeleteBeer(int id)
        {
            var beer = _context.Beers
                .FirstOrDefault(b => b.Id == id);
            if (beer == null || beer.IsDeleted)
                return false;

            beer.IsDeleted = true;
            beer.DeletedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public ICollection<BeerDTO> GetAllBeers()
        {
            var beers = _context.Beers
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
            var beer = _context.Beers
                .Include(b => b.Type)
                .Include(b => b.Brewery)
                .ThenInclude(br => br.Country)
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
        public BeerDTO UpdateBeer(int id, string name, string beerType, string brewery, double AbV)
        {
            var beerExists = _context.Beers
                .FirstOrDefault(b => b.Name == name && b.Brewery.Name == brewery);
            if (beerExists != null)
            {
                throw new ArgumentException("Beer with this name and brewery already exists.");
            }
            var beer = _context.Beers
                .Include(b => b.Type)
                .Include(b => b.Brewery)
                .ThenInclude(br => br.Country)
                .Where(b => b.IsDeleted == false)
                .FirstOrDefault(b => b.Id == id);

            beer.Name = name;
            beer.Type = _context.BeerTypes
                .FirstOrDefault(t => t.Name == beerType)
                ?? throw new ArgumentNullException("BeerType not found.");
            beer.Brewery = _context.Breweries
                .FirstOrDefault(b => b.Name == brewery)
                ?? throw new ArgumentNullException("Brewery not found.");
            beer.AlcoholByVolume = AbV;

            var beerDTO = new BeerDTO
            {
                Name = beer.Name,
                BeerType = beer.Type.Name,
                Brewery = beer.Brewery.Name,
                BreweryCountry = beer.Brewery.Country.Name,
                AlcoholByVolume = beer.AlcoholByVolume,
            };

            _context.SaveChanges();
            return beerDTO;
        }
    }
}

