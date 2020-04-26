using BeerOverflow.Services.DTO.Contracts;

namespace BeerOverflow.Services.DTO
{
    public class BreweryDTO : IBreweryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
