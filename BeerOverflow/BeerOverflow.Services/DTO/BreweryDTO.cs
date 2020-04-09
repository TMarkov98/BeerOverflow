using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class BreweryDTO : IBreweryDTO
    {
        public BreweryDTO(int id, string name, string country)
        {
            this.Id = id;
            this.Name = name;
            this.BreweryCountry = country;
        }
        //TODO
        public int Id { get; set; }
        public string Name { get; set; }
        public string BreweryCountry { get; set; }
    }
}
