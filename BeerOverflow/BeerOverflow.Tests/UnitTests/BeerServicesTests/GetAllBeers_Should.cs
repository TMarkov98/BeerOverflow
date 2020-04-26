using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class GetAllBeers_Should
    {
        [TestMethod]
        public void ReturnCorrectBeers_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBeers_When_ParamsValid));
            var country = TestsModelsSeeder.SeedCountry();
            var beerType = TestsModelsSeeder.SeedBeerType();
            var brewery = TestsModelsSeeder.SeedBrewery();
            var beer = TestsModelsSeeder.SeedBeer();
            var beer2 = TestsModelsSeeder.SeedBeer2();
            var beer3 = TestsModelsSeeder.SeedBeer3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.Add(beer);
                arrangeContext.Add(beer2);
                arrangeContext.Add(beer3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var result = sut.GetAllBeers().ToList();
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(beer.Name, result[0].Name);
                Assert.AreEqual(beer2.Name, result[1].Name);
                Assert.AreEqual(beer3.Name, result[2].Name);
            }
        }
    }
}
//public ICollection<BeerDTO> GetAllBeers()
//{
//    var beers = _context.Beers
//        .Select(x => new BeerDTO
//        {
//            Id = x.Id,
//            Name = x.Name,
//            BeerType = x.Type.Name,
//            Brewery = x.Brewery.Name,
//            BreweryCountry = x.Brewery.Country.Name,
//            AlcoholByVolume = x.AlcoholByVolume,
//        })
//        .ToList();

//    return beers;
//}