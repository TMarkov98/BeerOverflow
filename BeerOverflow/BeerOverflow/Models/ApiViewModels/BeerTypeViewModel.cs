using BeerOverflow.Services.DTO;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class BeerTypeViewModel
    {
        public BeerTypeViewModel()
        {

        }
        public BeerTypeViewModel(IBeerTypeDTO beerTypeDTO)
        {
            this.Id = beerTypeDTO.Id;
            this.Name = beerTypeDTO.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
