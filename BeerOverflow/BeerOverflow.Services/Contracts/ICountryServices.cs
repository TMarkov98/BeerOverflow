using BeerOverflow.Services.DTO.Contracts;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryServices
    {
        ICountryDTO GetCountry(int id);
        ICollection<ICountryDTO> GetAllCountries();
    }
}
