using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class BreweryViewModel
    {
        public BreweryViewModel()
        {

        }
        public BreweryViewModel(IBreweryDTO breweryDTO)
        {
            this.Id = breweryDTO.Id;
            this.Name = breweryDTO.Name;
            this.Country = breweryDTO.Country;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
