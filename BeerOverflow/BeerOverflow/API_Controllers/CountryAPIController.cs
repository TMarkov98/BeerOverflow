using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        private readonly ICountryServices _countryServices;

        public CountryAPIController(ICountryServices countryServices)
        {
            this._countryServices = countryServices ?? throw new ArgumentNullException("CountryService can NOT be null.");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = this._countryServices.GetAllCountries()
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryCode = c.CountryCode
                });
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var country = this._countryServices.GetCountry(id);
            var model = new CountryViewModel
                {
                    Id = country.Id,
                    Name = country.Name
                };
            return Ok(model);
        }
    }
}
