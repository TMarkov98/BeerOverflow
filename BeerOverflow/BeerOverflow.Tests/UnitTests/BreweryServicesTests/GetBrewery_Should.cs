using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.BreweryServicesTests
{
    [TestClass]
    public class GetBrewery_Should
    {
        [TestMethod]
        public void ReturnCorrectBrewery_WhenIdIsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBrewery_WhenIdIsValid));
            var country = TestsModelsSeeder.SeedCountry();
            var brewery1 = TestsModelsSeeder.SeedBrewery();
            var brewery2 = TestsModelsSeeder.SeedBrewery2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Breweries.Add(brewery1);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var result = sut.GetBrewery(2);
                Assert.AreEqual(brewery2.Id, result.Id);
                Assert.AreEqual(brewery2.Name, result.Name);
                Assert.AreEqual(brewery2.Country.Name, result.Country);
            }
        }
        [TestMethod]
        public void Throw_WhenIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenIdIsInvalid));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBrewery(1));
            }
        }
    }
}