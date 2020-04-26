using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class GetBeer_Should
    {
        [TestMethod]
        public void ReturnCorrectBeer_When_ParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBeer_When_ParamsAreValid));
            var country = TestsModelsSeeder.SeedCountry();
            var beerType = TestsModelsSeeder.SeedBeerType();
            var brewery = TestsModelsSeeder.SeedBrewery();
            var beer = TestsModelsSeeder.SeedBeer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var result = sut.GetBeer(1);
                Assert.AreEqual(beer.Name, result.Name);
                Assert.AreEqual(beer.Brewery.Name, result.Brewery);
                Assert.AreEqual(beer.AlcoholByVolume, result.AlcoholByVolume);
                Assert.AreEqual(beer.Type.Name, result.BeerType);

            }
        }
        [TestMethod]
        public void ThrowArgumentNullException_When_BeerMissing()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumentNullException_When_BeerMissing));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBeer(1));
            }
        }
    }
}
