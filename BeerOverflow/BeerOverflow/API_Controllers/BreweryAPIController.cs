using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.BreweryServices;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/breweries")]
    [ApiController]
    public class BreweryAPIController : ControllerBase
    {
        private readonly IBreweryServices _breweryServices;
        public BreweryAPIController(IBreweryServices breweryServices)
        {
            this._breweryServices = breweryServices ?? throw new ArgumentNullException("BreweryService can NOT be null.");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = this._breweryServices.GetAllBreweries()
                .Select(b => new BreweryViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Country = b.BreweryCountry
                });
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var breweryDTO = this._breweryServices.GetBrewery(id);
            var model = new BreweryViewModel
            {
                Id = breweryDTO.Id,
                Name = breweryDTO.Name,
                Country = breweryDTO.BreweryCountry
            };
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]BreweryViewModel breweryViewModel)
        {
            if (breweryViewModel == null)
                return BadRequest();
            var breweryDTO = new BreweryDTO(breweryViewModel.Name, breweryViewModel.Country);
            var brewery = _breweryServices.CreateBrewery(breweryDTO);
            return Created("Post", brewery);
        }
    }
}