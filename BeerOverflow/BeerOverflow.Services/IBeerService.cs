using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services
{
    public interface IBeerService
    {
        BeerDTO GetBeer(int id);
        ICollection<BeerDTO> GetAllBeers();
        IBeer CreateBeer(IBeerDTO beerDTO);
        bool DeleteBeer(int id);
    }
}
