
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.CountryServices
{
    public class CountryServices : ICountryServices
    {
        
        public ICountryDTO GetCountry(int id)
        {
            var country = Database.Database.Countries.FirstOrDefault(x => x.Id == id);
            var countryDTO = new CountryDTO { Id=country.Id, Name = country.Name, CountryCode = country.CountryCode};
            return countryDTO;
        }
        public ICollection<ICountryDTO> GetAllCountries()
        {
            var result = Database.Database.Countries
                .Select(x => new CountryDTO { Id = x.Id, Name = x.Name, CountryCode = x.CountryCode }).ToArray();
            return result;
        }
    }
}
