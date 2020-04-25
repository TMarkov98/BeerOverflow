using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.Models.ApiViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/breweries")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryServices _breweryServices;
        public BreweryController(IBreweryServices breweryServices)
        {
            this._breweryServices = breweryServices ?? throw new ArgumentNullException("BreweryService can NOT be null.");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = this._breweryServices.GetAllBreweries()
                .Select(breweryDTO => new BreweryViewModel(breweryDTO));
            return Ok(model);
        }

        [HttpGet]
        [Route("sort")]
        public IActionResult Get([FromQuery] string s)
        {
            var model = this._breweryServices.GetAllBreweries()
                .Select(breweryDTO => new BreweryViewModel(breweryDTO));
            switch (s)
            {
                case "name":
                    model = model.OrderBy(b => b.Name);
                    break;
                case "country":
                    model = model.OrderBy(b => b.Country);
                    break;
                default:
                    break;
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var breweryDTO = this._breweryServices.GetBrewery(id);
            var model = new BreweryViewModel(breweryDTO);
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]BreweryViewModel breweryViewModel)
        {
            if (breweryViewModel == null)
                return BadRequest();
            if (BreweryExists(breweryViewModel.Name))
                return ValidationProblem($"Brewery with name {breweryViewModel.Name} already exists");
            var breweryDTO = new BreweryDTO
            {
                Name = breweryViewModel.Name,
                Country = breweryViewModel.Country
            };
            var brewery = _breweryServices.CreateBrewery(breweryDTO);
            return Created("Post", brewery);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BreweryViewModel breweryViewModel)
        {
            if (breweryViewModel == null)
                return BadRequest();
            _breweryServices.UpdateBrewery(id, breweryViewModel.Name, breweryViewModel.Country);
            return Ok(breweryViewModel);
        }
        private bool BreweryExists(string name)
        {
            return _breweryServices.GetAllBreweries().Any(r => r.Name == name);
        }
    }
}