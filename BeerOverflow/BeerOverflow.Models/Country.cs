using BeerOverflow.Models.Contracts;

namespace BeerOverflow.Models
{
    public class Country : ICountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
