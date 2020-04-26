using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.CountryServicesTests
{
    [TestClass]
    public class GetCountry_Should
    {
        [TestMethod]
        public void ReturnCurrectCountry_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCurrectCountry_When_ParamsValid));
            var country = TestsModelsSeeder.SeedCountry();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryServices(assertContext);
                var result = sut.GetCountry(1);
                Assert.AreEqual(country.Name, result.Name);
                Assert.AreEqual(country.Code, result.CountryCode);
            }
        }
        [TestMethod]
        public void ThrowArgumenNullException_When_CountryMissing()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumenNullException_When_CountryMissing));
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetCountry(1));
            }
        }
    }
}
