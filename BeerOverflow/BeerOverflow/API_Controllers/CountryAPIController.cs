using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        
    }
}


//private readonly IBeerService _beerService;
//public BeerAPIController(IBeerService beerService)
//{
//    this._beerService = beerService ?? throw new ArgumentNullException("BeerService can NOT be null.");
//}
//[HttpGet]
//[Route("")]
//public IActionResult Get()
//{
//    var model = this._beerService.GetAllBeers()
//        .Select(x => new BeerViewModel
//        {
//            Id = x.Id,
//            Name = x.Name,
//            BeerType = x.BeerType.ToString(),
//            Brewery = x.Brewery,
//            Country = x.Country,
//            AlcoholByVolume = x.AlcoholByVolume,
//        });
//    return Ok(model);
//}