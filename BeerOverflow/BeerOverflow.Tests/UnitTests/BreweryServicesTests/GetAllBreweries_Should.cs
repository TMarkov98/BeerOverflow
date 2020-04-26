using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.BreweryServicesTests
{
    [TestClass]
    public class GetAllBreweries_Should
    {
        [TestMethod]
        public void ReturnCorrectList_WhenDataIsPresent()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectList_WhenDataIsPresent));
            var brewery1 = TestsModelsSeeder.Seed_Brewery();
            var brewery2 = TestsModelsSeeder.Seed_Brewery_v2();
            var brewery3 = TestsModelsSeeder.Seed_Brewery_v3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery1);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.Breweries.Add(brewery3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var result = sut.GetAllBreweries().ToList();
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(brewery1.Name, result[0].Name);
                Assert.AreEqual(brewery2.Name, result[1].Name);
                Assert.AreEqual(brewery3.Name, result[2].Name);
            }
        }
    }
}