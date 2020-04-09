using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.CountryServices
{
    public interface ICountryServices
    {
        ICountryDTO GetCountry(int id);
        ICollection<ICountryDTO> GetAllCountries();
    }
}
