using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class CreateBeer_Should
    {
        [TestMethod]
        public void ReturnCorrectBeer_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBeer_When_ParamsValid));
            var beertype = TestsModelsSeeder.SeedBeerType();
            var brewery = TestsModelsSeeder.SeedBrewery();
            var beerDTO = TestsModelsSeeder.SeedBeerDTO();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beertype);
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var act = sut.CreateBeer(beerDTO);
                var result = assertContext.Beers.FirstOrDefault(beer => beer.Name == beerDTO.Name);
                Assert.AreEqual(beerDTO.Id, result.Id);
                Assert.AreEqual(beerDTO.Name, result.Name);
                Assert.AreEqual(beerDTO.AlcoholByVolume, result.AlcoholByVolume);
                Assert.AreEqual(beerDTO.Brewery, result.Brewery.Name);
            }
        }
        [TestMethod]
        public void ThrowArgumentException_When_BeerAlreadyExists()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumentException_When_BeerAlreadyExists));
            var beerDTO = TestsModelsSeeder.SeedBeerDTO();
            var beer = TestsModelsSeeder.SeedBeer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);

            }
        }
    }
}
//public IBeerDTO CreateBeer(IBeerDTO beerDTO)
//{
//    var beer = new Beer
//    {
//        Name = beerDTO.Name,
//        Type = _context.BeerTypes.FirstOrDefault(t => t.Name == beerDTO.BeerType) ?? throw new ArgumentNullException("Beer Type not found."),
//        Brewery = _context.Breweries.FirstOrDefault(b => b.Name == beerDTO.Brewery) ?? throw new ArgumentNullException("Brewery not found."),
//        //new Brewery
//        //{
//        //    Name = beerDTO.Name,
//        //    Country = _context.Countries.FirstOrDefault(c => c.Name == beerDTO.BreweryCountry)
//        //},
//        AlcoholByVolume = beerDTO.AlcoholByVolume
//    };

//    _context.Beers.Add(beer);
//    _context.SaveChanges();
//    return beerDTO;
//}