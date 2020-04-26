using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class AddToBeersDrank_Should
    {
        [TestMethod]
        public void AddBeerCorrectly_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(AddBeerCorrectly_WhenParamsAreValid));
            var user = TestsModelsSeeder.Seed_User();
            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var act = sut.AddToBeersDrank(1, 1);
                var result = assertContext.Users.FirstOrDefault(u => u.UserName == user.UserName).BeersDrank.ToList();
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(beer.Id, result[0].BeerId);
            }
        }
        [TestMethod]
        public void ReturnTrue_WhenBeerAddedCorrectlyToBeersDrank()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenBeerAddedCorrectlyToBeersDrank));
            var user = TestsModelsSeeder.Seed_User();
            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var result = sut.AddToWishlist(1, 1);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void Throw_WhenBeersDrankUserIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenBeersDrankUserIdIsInvalid));
            var user = TestsModelsSeeder.Seed_User();
            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.AddToBeersDrank(2, 1));
            }
        }
        [TestMethod]
        public void Throw_WhenBeersDrankBeerIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenBeersDrankBeerIdIsInvalid));
            var user = TestsModelsSeeder.Seed_User();
            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.AddToWishlist(1, 2));
            }
        }
    }
}