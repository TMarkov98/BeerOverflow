using System.Collections.Generic;

namespace BeerOverflow.Models.Contracts
{
    public interface ICountry
    {
        string Code { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}