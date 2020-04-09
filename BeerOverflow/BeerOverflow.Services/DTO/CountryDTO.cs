using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    class CountryDTO : ICountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
