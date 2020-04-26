using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BreweryServicesTests
{
    [TestClass]
    public class GetAllBreweries_Should
    {
        [TestMethod]
        public void ReturnCorrectList_WhenDataIsPresent()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectList_WhenDataIsPresent));
            var country = TestsModelsSeeder.SeedCountry();
            var brewery1 = TestsModelsSeeder.SeedBrewery();
            var brewery2 = TestsModelsSeeder.SeedBrewery2();
            var brewery3 = TestsModelsSeeder.SeedBrewery3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Breweries.Add(brewery1);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.Breweries.Add(brewery3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var result = sut.GetAllBreweries().ToList();
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(brewery1.Name, result[0].Name);
                Assert.AreEqual(brewery2.Name, result[1].Name);
                Assert.AreEqual(brewery3.Name, result[2].Name);
            }
        }
    }
}