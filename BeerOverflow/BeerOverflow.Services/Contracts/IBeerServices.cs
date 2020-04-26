using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerServices
    {
        BeerDTO GetBeer(int id);
        ICollection<BeerDTO> GetAllBeers();
        IBeerDTO CreateBeer(IBeerDTO beerDTO);
        bool DeleteBeer(int id);
        BeerDTO UpdateBeer(int id, string name, string beerType, string brewery, double AbV);
    }
}
