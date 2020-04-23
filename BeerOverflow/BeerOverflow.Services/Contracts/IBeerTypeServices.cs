using BeerOverflow.Services.DTO;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerTypeServices
    {
        IBeerTypeDTO CreateBeerType(IBeerTypeDTO beerTypeDTO);
        bool DeleteBeerType(int id);
        ICollection<BeerTypeDTO> GetAllBeerTypes();
        BeerTypeDTO GetBeerType(int id);

        BeerTypeDTO UpdateBeerType(int id, string name);
    }
}