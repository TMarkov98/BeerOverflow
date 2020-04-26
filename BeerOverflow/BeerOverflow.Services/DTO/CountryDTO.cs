using BeerOverflow.Services.DTO.Contracts;

namespace BeerOverflow.Services.DTO
{
    public class CountryDTO : ICountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
