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
    public class CreateBeerType_Should
    {
        [TestMethod]
        public void ReturnCorrectBeerType_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBeerType_WhenParamsAreValid));
            var beerTypeDTO = TestsModelsSeeder.Seed_BeerTypeDTO();

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var act = sut.CreateBeerType(beerTypeDTO);
                var result = assertContext.BeerTypes.FirstOrDefault(beerType => beerType.Name == beerTypeDTO.Name);
                Assert.AreEqual(beerTypeDTO.Id, result.Id);
                Assert.AreEqual(beerTypeDTO.Name, result.Name);
            }
        }
        [TestMethod]
        public void Throw_When_BeerTypeAlreadyExists()
        {
            var options = Utils.GetOptions(nameof(Throw_When_BeerTypeAlreadyExists));
            var beerTypeDTO = TestsModelsSeeder.Seed_BeerTypeDTO();
            var beerType = TestsModelsSeeder.Seed_BeerType();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.CreateBeerType(beerTypeDTO));
            }
        }
    }
}