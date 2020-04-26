using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.CountryServicesTests
{
    [TestClass]
    public class GetAllCountries_Should
    {
        [TestMethod]
        public void ReturnCurrectCountries_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCurrectCountries_When_ParamsValid));
            var country = TestsModelsSeeder.SeedCountry();
            var country2 = TestsModelsSeeder.SeedCountry2();
            var country3 = TestsModelsSeeder.SeedCountry3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.Countries.Add(country2);
                arrangeContext.Countries.Add(country3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = sut.GetAllCountries().ToList();
                Assert.AreEqual(3, result.Count());
                Assert.AreEqual(country.Name, result[0].Name);
                Assert.AreEqual(country2.Name, result[1].Name);
                Assert.AreEqual(country3.Name, result[2].Name);
            }
        }
    }
}
