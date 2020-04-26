using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models.ApiViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/beerTypes")]
    [ApiController]
    public class BeerTypesController : Controller
    {
        private readonly IBeerTypeServices _beerTypeServices;
        public BeerTypesController(IBeerTypeServices beerTypeServices)
        {
            this._beerTypeServices = beerTypeServices ?? throw new ArgumentNullException("BeerService can NOT be null.");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = _beerTypeServices.GetAllBeerTypes().Select(bt_DTO => new BeerTypeViewModel(bt_DTO));
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var beerDTO = _beerTypeServices.GetBeerType(id);
            var model = new BeerTypeViewModel(beerDTO);
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] BeerTypeViewModel beerTypeViewModel)
        {
            if (beerTypeViewModel == null)
                return BadRequest();
            if (BeerTypeExists(beerTypeViewModel.Name))
                return ValidationProblem($"Beer Type with name {beerTypeViewModel.Name} already exists.");
            var beerTypeDTO = new BeerTypeDTO
            {
                Id = beerTypeViewModel.Id,
                Name = beerTypeViewModel.Name,
            };
            var beerType = _beerTypeServices.CreateBeerType(beerTypeDTO);
            return Created("Post", beerTypeViewModel);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BeerTypeViewModel beerTypeApiViewModel)
        {
            if (beerTypeApiViewModel == null)
                return BadRequest();
            var beerType = this._beerTypeServices.UpdateBeerType(id, beerTypeApiViewModel.Name);
            return Ok(beerTypeApiViewModel);
        }
        private bool BeerTypeExists(string name)
        {
            return _beerTypeServices.GetAllBeerTypes().Any(r => r.Name == name);
        }
    }
}