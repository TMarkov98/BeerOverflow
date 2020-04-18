using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services;
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
                .Select(x => new BeerViewModel
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
                .Select(x => new BeerViewModel
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
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var beerDTO = this._beerService.GetBeer(id);
            var model = new BeerViewModel
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
        public IActionResult Post([FromBody]BeerViewModel beerViewModel)
        {
            if (beerViewModel == null)
                return BadRequest();
            var beerDTO = new BeerDTO
            {
                Name = beerViewModel.Name,
                BeerType = beerViewModel.BeerType,
                Brewery = beerViewModel.Brewery,
                AlcoholByVolume = beerViewModel.AlcoholByVolume
            };
            var beer = _beerService.CreateBeer(beerDTO);
            return Created("Post", beer);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BeerViewModel beerViewModel)
        {
            if (beerViewModel==null)
                return BadRequest();
            var beer = this._beerService.UpdateBeer(id, beerViewModel.Name, beerViewModel.BeerType, beerViewModel.Brewery, beerViewModel.BreweryCountry, beerViewModel.AlcoholByVolume);
            return Ok(beer);
        }
    }
}