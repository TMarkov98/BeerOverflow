using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO.Contracts
{
    public interface ICountryDTO
    {
        int Id { get; set; }
        string Name { get; set; }
        string CountryCode { get; set; }
    }
}
