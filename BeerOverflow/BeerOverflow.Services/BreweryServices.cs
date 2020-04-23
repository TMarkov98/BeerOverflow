using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class BreweryServices : IBreweryServices
    {
        private readonly BeerOverflowContext _context;
        public BreweryServices(BeerOverflowContext context)
        {
            this._context = context;
        }

        public IBreweryDTO CreateBrewery(IBreweryDTO breweryDTO)
        {
            var brewery = new Brewery
            {
                Name = breweryDTO.Name,
                Country = (Country)Enum.Parse(typeof(Country), breweryDTO.Country, true)
            };
            _context.Breweries.Add(brewery);
            _context.SaveChanges();
            return breweryDTO;
        }
        public IBreweryDTO GetBrewery(int id)
        {
            var brewery = _context.Breweries.Include(b => b.Country).FirstOrDefault(i => i.Id == id);
            if (brewery == null)
                throw new ArgumentNullException("Brewery can NOT be null.");

            var breweryDTO = new BreweryDTO
            {
                Id = brewery.Id,
                Name = brewery.Name,
                Country = brewery.Country.Name
            };
            return breweryDTO;
        }
        public bool DeleteBrewery(int id)
        {
            var brewery = _context.Breweries.FirstOrDefault(b => b.Id == id);
            if (brewery == null || brewery.IsDeleted)
                return false;

            brewery.IsDeleted = true;
            brewery.DeletedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        public ICollection<BreweryDTO> GetAllBreweries()
        {
            var breweries = _context.Breweries
                .Select(x => new BreweryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country.Name
                }).ToList();
            return breweries;
        }
        public BreweryDTO UpdateBeerType(int id, string name, string breweryCountry)
        {
            var brewery = _context.Breweries
                .Where(r => r.IsDeleted == false)
                .FirstOrDefault(r => r.Id == id);
            brewery.Name = name;
            brewery.Country = _context.Countries.FirstOrDefault(c => c.Name == breweryCountry) ?? throw new ArgumentNullException("Brewery country not found.");
            var breweryDTO = new BreweryDTO
            {
                Name = brewery.Name,
                Country = brewery.Country.Name,
            };
            _context.SaveChanges();
            return breweryDTO;
        }
    }
}