using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.BeerTypeServicesTests
{
    [TestClass]
    public class UpdateBeerType_Should
    {
        [TestMethod]
        public void CorrectlyUpdateBeerType_WhenDataIsValid()
        {
            var options = Utils.GetOptions(nameof(CorrectlyUpdateBeerType_WhenDataIsValid));
            var beerType1 = TestsModelsSeeder.SeedBeerType();
            var beerType2 = TestsModelsSeeder.SeedBeerType2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType1);
                arrangeContext.BeerTypes.Add(beerType2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var act = sut.UpdateBeerType(2, "newBeerType");
                var result = sut.GetBeerType(2);
                Assert.AreEqual("newBeerType", result.Name);
            }
        }
        [TestMethod]
        public void Throw_WhenBeerTypeIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenBeerTypeIdIsInvalid));
            var beerType1 = TestsModelsSeeder.SeedBeerType();
            var beerType2 = TestsModelsSeeder.SeedBeerType2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType1);
                arrangeContext.BeerTypes.Add(beerType2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateBeerType(5, "newBeerType"));
            }
        }
    }
}