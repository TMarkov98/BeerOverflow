using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.BeerTypeServicesTests
{
    [TestClass]
    public class GetAllBeerTypes_Should
    {
        [TestMethod]
        public void ReturnCorrectList_WhenDataIsPresent()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectList_WhenDataIsPresent));
            var beerType1 = TestsModelsSeeder.Seed_BeerType();
            var beerType2 = TestsModelsSeeder.Seed_BeerType_v2();
            var beerType3 = TestsModelsSeeder.Seed_BeerType_v3();

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