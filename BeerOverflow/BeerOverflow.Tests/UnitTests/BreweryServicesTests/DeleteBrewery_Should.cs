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
    public class DeleteBrewery_Should
    {
        [TestMethod]
        public void DeleteBrewery_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(DeleteBrewery_WhenIdIsCorrect));
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
                var act = sut.DeleteBrewery(brewery.Id);
                var result = assertContext.Breweries.FirstOrDefault(b => b.Name == brewery.Name).IsDeleted;
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void ReturnTrue_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenIdIsCorrect));
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
                var result = sut.DeleteBrewery(brewery.Id);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void ReturnFalse_WhenIdIsIncorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_WhenIdIsIncorrect));
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
                var result = sut.DeleteBrewery(brewery.Id + 1);
                Assert.IsFalse(result);
            }
        }
    }
}