using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeerAPIController : ControllerBase
    {
        private readonly IBeerService _beerService;
        public BeerAPIController(IBeerService beerService)
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
                    Country = x.Country,
                    AlcoholByVolume = x.AlcoholByVolume,
                });
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
                Country = beerDTO.Country,
                AlcoholByVolume = beerDTO.AlcoholByVolume,
            };
            return Ok(model);
        }
    }
}