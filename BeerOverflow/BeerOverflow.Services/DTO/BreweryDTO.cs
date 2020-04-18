using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class BreweryDTO : IBreweryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
