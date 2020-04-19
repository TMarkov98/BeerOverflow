using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/beerTypes")]
    [ApiController]
    public class BeerTypeAPIController : Controller
    {
        private readonly IBeerTypeServices _beerTypeServices;
        public BeerTypeAPIController(IBeerTypeServices beerTypeServices)
        {
            this._beerTypeServices = beerTypeServices ?? throw new ArgumentNullException("BeerService can NOT be null.");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = _beerTypeServices.GetAllBeerTypes().Select(bt => new BeerTypeViewModel
            {
                Id = bt.Id,
                Name = bt.Name
            });
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var beerDTO = _beerTypeServices.GetBeerType(id);
            var model = new BeerTypeViewModel
            {
                Id = beerDTO.Id,
                Name = beerDTO.Name
            };
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] BeerTypeViewModel beerTypeViewModel)
        {
            var beerTypeDTO = new BeerTypeDTO
            {
                Id = beerTypeViewModel.Id,
                Name = beerTypeViewModel.Name,
            };
            var beerType = _beerTypeServices.CreateBeerType(beerTypeDTO);
            return Created("Post", beerTypeViewModel);
        }
    }
}