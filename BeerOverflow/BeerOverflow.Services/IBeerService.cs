using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services
{
    interface IBeerService
    {
        IBeerDTO GetBeer(int id);
        ICollection<IBeerDTO> GetAllBeers();
        IBeer CreateBeer(IBeerDTO beerDTO);
        bool DeleteBeer(int id);
    }
}
