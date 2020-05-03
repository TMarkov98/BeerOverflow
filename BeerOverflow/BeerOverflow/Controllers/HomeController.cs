using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.Models.ApiViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBeerServices _beerService;
        public HomeController(ILogger<HomeController> logger, IBeerServices beerService)
        {
            _logger = logger;
            _beerService = beerService ?? throw new ArgumentNullException("BeerService can not be null.");
        }

        public IActionResult Index()
        {
            var homeModel = new HomeIndexViewModel();
            homeModel.AllBeers = this._beerService.GetAllBeers()
                .Select(x => new BeerViewModel
                {
                    Name = x.Name,
                    BeerType = x.BeerType.ToString(),
                    Brewery = x.Brewery,
                    AlcoholByVolume = x.AlcoholByVolume,
                })
                .ToList();
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotFound404 ()
        {
            return View();
        }
    }
}
