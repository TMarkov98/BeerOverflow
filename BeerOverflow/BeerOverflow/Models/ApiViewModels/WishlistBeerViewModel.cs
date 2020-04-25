using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class WishlistBeerApiViewModel
    {
        //TODO Why has Id, Name, AlcoholByVolume
        public WishlistBeerApiViewModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholByVolume { get; set; }
    }
}
