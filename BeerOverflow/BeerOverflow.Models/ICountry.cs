namespace BeerOverflow.Models
{
    public interface ICountry
    {
        string CountryCode { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}