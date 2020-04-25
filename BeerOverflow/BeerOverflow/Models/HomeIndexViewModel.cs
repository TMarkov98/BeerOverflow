using BeerOverflow.Web.Models.ApiViewModels;
using System.Collections.Generic;

namespace BeerOverflow.Web.Models
{
    public class HomeIndexViewModel
    {
        public List<BeerViewModel> AllBeers { get; set; }
    }
}
