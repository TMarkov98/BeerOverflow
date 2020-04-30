using BeerOverflow.Web.Models.ApiViewModels;
using System.Collections.Generic;

namespace BeerOverflow.Web.Areas.Admin.Models
{
    public class HomeIndexViewModel
    {
        public List<BeerViewModel> AllBeers { get; set; }
    }
}
