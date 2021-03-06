﻿using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.BeerTypeServicesTests
{
    [TestClass]
    public class GetBeerType_Should
    {
        [TestMethod]
        public void ReturnCorrectBeerType_WhenIdIsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectBeerType_WhenIdIsValid));
            var beerType1 = TestsModelsSeeder.SeedBeerType();
            var beerType2 = TestsModelsSeeder.SeedBeerType2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType1);
                arrangeContext.BeerTypes.Add(beerType2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                var result = sut.GetBeerType(2);
                Assert.AreEqual(beerType2.Id, result.Id);
                Assert.AreEqual(beerType2.Name, result.Name);
            }
        }
        [TestMethod]
        public void Throw_WhenIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenIdIsInvalid));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypeServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBeerType(1));
            }
        }
    }
}