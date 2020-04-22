using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeerAPIController : ControllerBase
    {
        private readonly IBeerServices _beerService;
        public BeerAPIController(IBeerServices beerService)
        {
            this._beerService = beerService ?? throw new ArgumentNullException("BeerService can NOT be null.");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = this._beerService.GetAllBeers()
                .Select(x => new BeerApiViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BeerType = x.BeerType.ToString(),
                    Brewery = x.Brewery,
                    BreweryCountry = x.BreweryCountry,
                    AlcoholByVolume = x.AlcoholByVolume,
                });
            return Ok(model);
        }
        [HttpGet]
        [Route("sort")]
        public IActionResult Get([FromQuery] string s)
        {
            var model = this._beerService.GetAllBeers()
                .Select(x => new BeerApiViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BeerType = x.BeerType.ToString(),
                    Brewery = x.Brewery,
                    BreweryCountry = x.BreweryCountry,
                    AlcoholByVolume = x.AlcoholByVolume,
                });
            switch (s.ToLower())
            {
                case "name":
                    model = model.OrderBy(b => b.Name);
                    break;
                case "abv":
                case "alcoholbyvolume":
                    model = model.OrderBy(b => b.AlcoholByVolume);
                    break;
                case "rating":
                case "likes":
                    model = model.OrderBy(b => b.Likes);
                    break;
                default:
                    break;
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("filter")]
        public IActionResult Get([FromQuery] string param, [FromQuery] string value)
        {
            var model = this._beerService.GetAllBeers()
                .Select(x => new BeerApiViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BeerType = x.BeerType.ToString(),
                    Brewery = x.Brewery,
                    BreweryCountry = x.BreweryCountry,
                    AlcoholByVolume = x.AlcoholByVolume,
                });
            switch (param.ToLower())
            {
                case "country":
                    model = model.Where(c => c.BreweryCountry.ToLower() == value.ToLower());
                    break;
                case "brewery":
                    model = model.Where(b => b.Brewery.ToLower() == value.ToLower());
                    break;
                case "type":
                case "beertype":
                    model = model.Where(t => t.BeerType.ToLower() == value.ToLower());
                    break;
                case "abv":
                case "alcoholbyvolume":
                    model = model.Where(a => a.AlcoholByVolume.ToString() == value);
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
            var beerDTO = this._beerService.GetBeer(id);
            var model = new BeerApiViewModel
            {
                Id = beerDTO.Id,
                Name = beerDTO.Name,
                BeerType = beerDTO.BeerType.ToString(),
                Brewery = beerDTO.Brewery,
                BreweryCountry = beerDTO.BreweryCountry,
                AlcoholByVolume = beerDTO.AlcoholByVolume,
            };
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]BeerApiViewModel beerViewModel)
        {
            if (beerViewModel == null)
                return BadRequest();
            if (BeerExists(beerViewModel.Name))
                return ValidationProblem($"Beer with name {beerViewModel.Name} already exists.");
            var beerDTO = new BeerDTO
            {
                Name = beerViewModel.Name,
                BeerType = beerViewModel.BeerType,
                Brewery = beerViewModel.Brewery,
                AlcoholByVolume = beerViewModel.AlcoholByVolume
            };
            var beer = _beerService.CreateBeer(beerDTO);
            return Created("Post", beerViewModel);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BeerApiViewModel beerViewModel)
        {
            if (beerViewModel == null)
                return BadRequest();
            var beer = this._beerService.UpdateBeer(id, beerViewModel.Name, beerViewModel.BeerType, beerViewModel.Brewery, beerViewModel.BreweryCountry, beerViewModel.AlcoholByVolume);
            return Ok(beerViewModel);
        }
        private bool BeerExists(string name)
        {
            return _beerService.GetAllBeers().Any(r => r.Name == name);
        }
    }
}