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
    public class GetBrewery_Should
    {
        [TestMethod]
        public void ReturnCorrectBrewery_WhenIdIsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBrewery_WhenIdIsValid));
            var brewery1 = TestsModelsSeeder.Seed_Brewery();
            var brewery2 = TestsModelsSeeder.Seed_Brewery_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery1);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var result = sut.GetBrewery(2);
                Assert.AreEqual(brewery2.Id, result.Id);
                Assert.AreEqual(brewery2.Name, result.Name);
                Assert.AreEqual(brewery2.Country.Name, result.Country);
            }
        }
        [TestMethod]
        public void Throw_WhenIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenIdIsInvalid));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBrewery(1));
            }
        }
    }
}