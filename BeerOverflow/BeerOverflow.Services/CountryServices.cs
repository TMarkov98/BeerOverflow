
using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly BeerOverflowContext context = new BeerOverflowContext();

        public ICountryDTO GetCountry(int id)
        {
            var country = context.Countries.FirstOrDefault(x => x.Id == id);
            var countryDTO = new CountryDTO { Id=country.Id, Name = country.Name, CountryCode = country.Code};
            return countryDTO;
        }
        public ICollection<ICountryDTO> GetAllCountries()
        {
            var result = context.Countries
                .Select(x => new CountryDTO { Id = x.Id, Name = x.Name, CountryCode = x.Code }).ToArray();
            return result;
        }
    }
}
