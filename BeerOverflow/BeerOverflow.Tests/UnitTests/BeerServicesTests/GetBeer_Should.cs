using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class GetBeer_Should
    {
        [TestMethod]
        public void ReturnCurrectBeer_When_ParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCurrectBeer_When_ParamsAreValid));

            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
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
