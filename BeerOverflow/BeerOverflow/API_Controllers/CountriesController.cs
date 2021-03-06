﻿using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models.ApiViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryServices _countryServices;

        public CountriesController(ICountryServices countryServices)
        {
            this._countryServices = countryServices ?? throw new ArgumentNullException("CountryService can NOT be null.");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = this._countryServices.GetAllCountries()
                .Select(countryDTO => new CountryViewModel(countryDTO));
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var countryDTO = this._countryServices.GetCountry(id);
            var model = new CountryViewModel(countryDTO);
            return Ok(model);
        }
    }
}
