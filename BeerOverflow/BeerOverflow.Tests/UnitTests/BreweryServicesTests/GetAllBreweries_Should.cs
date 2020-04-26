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
            var breweryDTO = TestsModelsSeeder.Seed_BreweryDTO();
            var country = TestsModelsSeeder.Seed_Country();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Countries.Add(country);
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
    }
}