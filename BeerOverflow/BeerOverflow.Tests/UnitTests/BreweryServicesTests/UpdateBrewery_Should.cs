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
    public class UpdateBrewery_Should
    {
        [TestMethod]
        public void CorrectlyUpdate_WhenDataIsValid()
        {
            var options = Utils.GetOptions(nameof(CorrectlyUpdate_WhenDataIsValid));
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
                var act = sut.UpdateBrewery(2, "NewBrewery", "Bulgaria");
                var result = sut.GetBrewery(2);
                Assert.AreEqual("NewBrewery", result.Name);
                Assert.AreEqual("Bulgaria", result.Country);
            }
        }
        [TestMethod]
        public void Throw_WhenCountryIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenCountryIsInvalid));
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
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateBrewery(2, "NewBrewery", "Svazilend"));
            }
        }
        public void Throw_WhenIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenIdIsInvalid));
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
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateBrewery(5, "NewBrewery", "Bulgaria"));
            }
        }
    }
}