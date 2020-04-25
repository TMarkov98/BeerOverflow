using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {

        }
        public CountryViewModel(ICountryDTO countryDTO)
        {
            this.Id = countryDTO.Id;
            this.Name = countryDTO.Name;
            this.CountryCode = countryDTO.CountryCode;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
