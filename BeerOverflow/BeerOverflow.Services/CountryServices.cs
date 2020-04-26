
using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerOverflow.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly BeerOverflowContext _context;
        public CountryServices(BeerOverflowContext context)
        {
            this._context = context;
        }

        public ICountryDTO GetCountry(int id)
        {
            var country = _context.Countries
                .FirstOrDefault(x => x.Id == id);
            if (country == null)
            {
                throw new ArgumentNullException("Country not found.");
            }
            var countryDTO = new CountryDTO { Id = country.Id, Name = country.Name, CountryCode = country.Code };
            return countryDTO;
        }
        public ICollection<ICountryDTO> GetAllCountries()
        {
            var result = _context.Countries
                .Select(x => new CountryDTO { Id = x.Id, Name = x.Name, CountryCode = x.Code }).ToArray();
            return result;
        }
    }
}
