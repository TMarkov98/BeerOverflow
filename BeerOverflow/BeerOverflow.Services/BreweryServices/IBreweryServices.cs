using System.Collections.Generic;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;

namespace BeerOverflow.Services.BreweryServices
{
    public interface IBreweryServices
    {
        IBreweryDTO CreateBrewery(IBreweryDTO breweryDTO);
        IBreweryDTO Get(int id);
        ICollection<BreweryDTO> GetAll();
    }
}