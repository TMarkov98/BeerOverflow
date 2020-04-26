using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class UpdateBeer_Should
    {
        [TestMethod]
        public void UpdateCurrectBeer_When_ParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(UpdateCurrectBeer_When_ParamsAreValid));
            var beer = TestsModelsSeeder.Seed_Beer();
            var brewery = TestsModelsSeeder.Seed_Brewery();
            var country = TestsModelsSeeder.Seed_Country();
            var beer2 = TestsModelsSeeder.Seed_Beer_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(beer);
                arrangeContext.Beers.Add(beer2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var act = sut.UpdateBeer(1, "NewBeerName", beer2.Type.Name, brewery.Name, 6);
                var result = sut.GetBeer(1);
                Assert.AreEqual("NewBeerName", result.Name);
                Assert.AreEqual(beer2.Type.Name, result.BeerType);
                Assert.AreEqual(brewery.Name, result.Brewery);
                Assert.AreEqual(6, result.AlcoholByVolume);
            }
        }
        [TestMethod]
        public void ThrowArgumentException_When_UpdatedBeerExists()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumentException_When_UpdatedBeerExists));
            var beer = TestsModelsSeeder.Seed_Beer();
            var beer2 = TestsModelsSeeder.Seed_Beer_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(beer);
                arrangeContext.Beers.Add(beer2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.UpdateBeer(1, beer2.Name, beer2.Type.Name, beer2.Brewery.Name, 6));
            }
        }
    }
}
