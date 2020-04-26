using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BreweryServicesTests
{
    [TestClass]
    public class DeleteBrewery_Should
    {
        [TestMethod]
        public void DeleteBrewery_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(DeleteBrewery_WhenIdIsCorrect));
            var brewery = TestsModelsSeeder.SeedBrewery();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var act = sut.DeleteBrewery(brewery.Id);
                var result = assertContext.Breweries.FirstOrDefault(b => b.Name == brewery.Name);
                Assert.IsTrue(result.IsDeleted);
            }
        }
        [TestMethod]
        public void ReturnTrue_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenIdIsCorrect));
            var brewery = TestsModelsSeeder.SeedBrewery();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var result = sut.DeleteBrewery(brewery.Id);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void ReturnFalse_WhenIdIsIncorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_WhenIdIsIncorrect));
            var brewery = TestsModelsSeeder.SeedBrewery();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var result = sut.DeleteBrewery(brewery.Id + 1);
                Assert.IsFalse(result);
            }
        }
    }
}