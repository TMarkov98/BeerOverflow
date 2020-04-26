using BeerOverflow.Services.DTO.Contracts;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class WishlistBeerViewModel
    {
        public WishlistBeerViewModel(IBeerDTO beerDTO)
        {
            this.Id = beerDTO.Id;
            this.Name = beerDTO.Name;
            this.AlcoholByVolume = beerDTO.AlcoholByVolume;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholByVolume { get; set; }
    }
}
