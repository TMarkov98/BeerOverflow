using BeerOverflow.Models.Enums;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.CountryServices
{
    public class CountryServices : ICountryServices
    {
        public ICountryDTO GetCountry(int id)
        {
            Country countryEnum = (Country)id;
            string description = countryEnum.GetDescription();
            var countryDTO = new CountryDTO(id, description);
            return countryDTO;
        }
        public ICollection<ICountryDTO> GetAllCountries()
        {
            List<ICountryDTO> result = new List<ICountryDTO>();
            foreach(var value in Enum.GetValues(typeof(Country)))
            {
                result.Add(new CountryDTO((int)value, value.ToString()));
            }
            return result;
        }
    }
}
