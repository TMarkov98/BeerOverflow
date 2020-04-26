using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models.ApiViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerServices _beerService;
        public BeersController(IBeerServices beerService)
        {
            this._beerService = beerService ?? throw new ArgumentNullException("BeerService can NOT be null.");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = this._beerService.GetAllBeers()
                .Select(beerDTO => new BeerViewModel(beerDTO));
            return Ok(model);
        }
        [HttpGet]
        [Route("sort")]
        public IActionResult Get([FromQuery] string s)
        {
            var model = this._beerService.GetAllBeers()
                .Select(beerDTO => new BeerViewModel(beerDTO));
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
                .Select(beerDTO => new BeerViewModel(beerDTO));
            switch (param.ToLower())
            {
                case "name":
                    model = model.Where(c => c.Name.ToLower().Contains(param.ToLower()));
                    break;
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
            var model = new BeerViewModel(beerDTO);
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]BeerViewModel beerViewModel)
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
        public IActionResult Put(int id, [FromBody] BeerViewModel beerViewModel)
        {
            if (beerViewModel == null)
                return BadRequest();
            var beer = this._beerService.UpdateBeer(id, beerViewModel.Name, beerViewModel.BeerType, beerViewModel.Brewery, beerViewModel.AlcoholByVolume);
            return Ok(beerViewModel);
        }
        private bool BeerExists(string name)
        {
            return _beerService.GetAllBeers().Any(r => r.Name == name);
        }
    }
}