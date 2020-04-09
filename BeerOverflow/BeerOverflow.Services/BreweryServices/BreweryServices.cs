using BeerOverflow.Models;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.BreweryServices
{
    public class BreweryServices : IBreweryServices
    {
        public IBreweryDTO CreateBrewery(IBreweryDTO breweryDTO)
        {
            var brewery = new Brewery(breweryDTO.Name,
                breweryDTO.BreweryCountry);

            Database.Database.Breweries.Add(brewery);
            brewery.Id = Database.Database.Breweries.Count;
            return breweryDTO;
        }
        public IBreweryDTO Get(int id)
        {
            var brewery = Database.Database.Breweries.FirstOrDefault(i => i.Id == id);
            if (brewery == null)
                throw new ArgumentNullException("Brewery can NOT be null.");

            var breweryDTO = new BreweryDTO(brewery.Id, brewery.Name, brewery.BreweryCountry.ToString());
            return breweryDTO;
        }
        public ICollection<BreweryDTO> GetAll()
        {
            var breweries = Database.Database.Breweries
                .Select(x => new BreweryDTO
                (
                    x.Id,
                    x.Name,
                    x.BreweryCountry.ToString()
                )).ToList();
            return breweries;
        }
    }
}

//public IBeerDTO CreateBeer(IBeerDTO beerDTO)
//{
//    var beer = new Beer(beerDTO.Name,
//        (BeerType)Enum.Parse(typeof(BeerType), beerDTO.BeerType, true),
//        new Brewery(beerDTO.Brewery, beerDTO.BreweryCountry),
//        (Country)Enum.Parse(typeof(Country), beerDTO.Country, true),
//        beerDTO.AlcoholByVolume);

//    Database.Database.Beers.Add(beer);
//    beer.Id = Database.Database.Beers.Count;
//    return beerDTO;
//}