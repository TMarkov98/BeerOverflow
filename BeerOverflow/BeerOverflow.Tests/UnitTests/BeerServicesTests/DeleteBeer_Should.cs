using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class DeleteBeer_Should
    {
        [TestMethod]
        public void ChangeCurrect_IsDelete_ToTrue()
        {
            var options = Utils.GetOptions(nameof(ChangeCurrect_IsDelete_ToTrue));
            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var act = sut.DeleteBeer(1);
                Assert.IsTrue(assertContext.Beers.FirstOrDefault(beer => beer.Id == 1).IsDeleted);
            };
        }
        [TestMethod]
        public void ReturnFalse_When_BeerToDeleteMissing()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_When_BeerToDeleteMissing));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var result = sut.DeleteBeer(1);
                Assert.IsFalse(result);
            };
        }
        [TestMethod]
        public void ReturnFalse_When_BeerToDelete_AlreadyDeleted()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_When_BeerToDelete_AlreadyDeleted));

            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var act = sut.DeleteBeer(1);
                var result = sut.DeleteBeer(1);
                Assert.IsFalse(result);
            };
        }
    }
}