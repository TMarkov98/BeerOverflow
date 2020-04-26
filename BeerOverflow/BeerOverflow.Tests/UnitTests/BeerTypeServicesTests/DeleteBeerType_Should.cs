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
    public class DeleteBeerType_Should
    {
        [TestMethod]
        public void DeleteBeerType_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(DeleteBeerType_WhenIdIsCorrect));
            var beerType = TestsModelsSeeder.Seed_BeerType();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var act = sut.DeleteBeerType(beerType.Id);
                var result = assertContext.BeerTypes.FirstOrDefault(bt => bt.Name == beerType.Name).IsDeleted;
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void ReturnTrue_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenIdIsCorrect));
            var beerType = TestsModelsSeeder.Seed_BeerType();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var result = sut.DeleteBeerType(beerType.Id);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void ReturnFalse_WhenIdIsIncorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_WhenIdIsIncorrect));
            var beerType = TestsModelsSeeder.Seed_BeerType();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var result = sut.DeleteBeerType(beerType.Id + 1);
                Assert.IsFalse(result);
            }
        }
    }
}