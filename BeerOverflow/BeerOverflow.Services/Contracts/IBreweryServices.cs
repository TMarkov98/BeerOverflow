using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IBreweryServices
    {
        IBreweryDTO CreateBrewery(IBreweryDTO breweryDTO);
        IBreweryDTO GetBrewery(int id);
        ICollection<BreweryDTO> GetAllBreweries();
        BreweryDTO UpdateBrewery(int id, string name, string breweryCountry);
    }
}