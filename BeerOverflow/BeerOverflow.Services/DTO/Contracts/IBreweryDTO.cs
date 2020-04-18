using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO.Contracts
{
    public interface IBreweryDTO
    {
        int Id { get; }
        string Name { get; set; }
        string Country { get; set; }
    }
}
