using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class DeleteBeer_Should
    {
        [TestMethod]
        public void ChangeCorrect_IsDelete_ToTrue()
        {
            var options = Utils.GetOptions(nameof(ChangeCorrect_IsDelete_ToTrue));
            var beer = TestsModelsSeeder.SeedBeer();

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

            var beer = TestsModelsSeeder.SeedBeer();

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