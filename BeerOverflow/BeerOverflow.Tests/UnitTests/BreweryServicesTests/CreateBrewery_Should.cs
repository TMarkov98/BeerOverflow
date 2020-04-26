using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BreweryServicesTests
{
    [TestClass]
    public class CreateBrewery_Should
    {
        [TestMethod]
        public void ReturnCorrectBrewery_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBrewery_WhenParamsAreValid));
            var breweryDTO = TestsModelsSeeder.SeedBreweryDTO();
            var country = TestsModelsSeeder.SeedCountry();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var act = sut.CreateBrewery(breweryDTO);
                var result = assertContext.Breweries.FirstOrDefault(brewery => brewery.Name == breweryDTO.Name);
                Assert.AreEqual(breweryDTO.Id, result.Id);
                Assert.AreEqual(breweryDTO.Name, result.Name);
                Assert.AreEqual(breweryDTO.Country, result.Country.Name);
            }
        }
        [TestMethod]
        public void Throw_WhenBreweryAlreadyExists()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenBreweryAlreadyExists));
            var breweryDTO = TestsModelsSeeder.SeedBreweryDTO();
            var brewery = TestsModelsSeeder.SeedBrewery();
            var country = TestsModelsSeeder.SeedCountry();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.CreateBrewery(breweryDTO));
            }
        }
    }
}