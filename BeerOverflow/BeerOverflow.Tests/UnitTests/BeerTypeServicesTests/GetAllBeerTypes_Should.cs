using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.BeerTypeServicesTests
{
    [TestClass]
    public class GetAllBeerTypes_Should
    {
        [TestMethod]
        public void ReturnCorrectList_WhenDataIsPresent()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectList_WhenDataIsPresent));
            var beerType1 = TestsModelsSeeder.SeedBeerType();
            var beerType2 = TestsModelsSeeder.SeedBeerType2();
            var beerType3 = TestsModelsSeeder.SeedBeerType3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType1);
                arrangeContext.BeerTypes.Add(beerType2);
                arrangeContext.BeerTypes.Add(beerType3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var result = sut.GetAllBeerTypes().ToList();
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(beerType1.Name, result[0].Name);
                Assert.AreEqual(beerType2.Name, result[1].Name);
                Assert.AreEqual(beerType3.Name, result[2].Name);
            }
        }
    }
}