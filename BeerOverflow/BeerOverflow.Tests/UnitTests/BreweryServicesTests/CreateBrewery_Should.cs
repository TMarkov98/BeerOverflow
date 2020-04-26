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
    public class CreateBrewery_Should
    {
        [TestMethod]
        public void ReturnCorrectBrewery_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBrewery_WhenParamsAreValid));
            var breweryDTO = TestsModelsSeeder.Seed_BreweryDTO();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                var act = sut.CreateBrewery(breweryDTO);
                var result = assertContext.Breweries.FirstOrDefault(brewery => brewery.Name == breweryDTO.Name);
                Assert.AreEqual(breweryDTO.Id, result.Id);
                Assert.AreEqual(breweryDTO.Name, result.Name);
                Assert.AreEqual(breweryDTO.Country, result.Country.Name);
            }
        }
        [TestMethod]
        public void Throw_WhenBreweryAlreadyExists()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenBreweryAlreadyExists));
            var breweryDTO = TestsModelsSeeder.Seed_BreweryDTO();
            var brewery = TestsModelsSeeder.Seed_Brewery();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.CreateBrewery(breweryDTO));
            }
        }
    }
}