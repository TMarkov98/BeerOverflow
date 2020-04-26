using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.BreweryServicesTests
{
    [TestClass]
    public class UpdateBrewery_Should
    {
        [TestMethod]
        public void CorrectlyUpdate_WhenDataIsValid()
        {
            var options = Utils.GetOptions(nameof(CorrectlyUpdate_WhenDataIsValid));
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
                var act = sut.UpdateBrewery(2, "NewBrewery", "Bulgaria");
                var result = sut.GetBrewery(2);
                Assert.AreEqual("NewBrewery", result.Name);
                Assert.AreEqual("Bulgaria", result.Country);
            }
        }
        [TestMethod]
        public void Throw_WhenCountryIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenCountryIsInvalid));
            var brewery1 = TestsModelsSeeder.SeedBrewery();
            var brewery2 = TestsModelsSeeder.SeedBrewery2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery1);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateBrewery(2, "NewBrewery", "Svazilend"));
            }
        }
        [TestMethod]
        public void Throw_WhenBreweryIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenBreweryIdIsInvalid));
            var brewery1 = TestsModelsSeeder.SeedBrewery();
            var brewery2 = TestsModelsSeeder.SeedBrewery2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery1);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateBrewery(5, "NewBrewery", "Bulgaria"));
            }
        }
    }
}