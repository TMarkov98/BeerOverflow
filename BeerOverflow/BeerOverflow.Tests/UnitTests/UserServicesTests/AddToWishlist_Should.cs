using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class AddToWishlist_Should
    {
        [TestMethod]
        public void AddCorrectly_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(AddCorrectly_WhenParamsAreValid));
            var user = TestsModelsSeeder.SeedUser();
            var beer = TestsModelsSeeder.SeedBeer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var act = sut.AddToWishlist(1, 1);
                var result = assertContext.Users.FirstOrDefault(u => u.UserName == user.UserName).Wishlist.ToList();
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(beer.Id, result[0].BeerId);
            }
        }
        [TestMethod]
        public void ReturnTrue_WhenBeerAddedCorrectlyToWishlist()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenBeerAddedCorrectlyToWishlist));
            var user = TestsModelsSeeder.SeedUser();
            var beer = TestsModelsSeeder.SeedBeer();

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
        public void Throw_WhenWishlistUserIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenWishlistUserIdIsInvalid));
            var user = TestsModelsSeeder.SeedUser();
            var beer = TestsModelsSeeder.SeedBeer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.AddToWishlist(2, 1));
            }
        }
        [TestMethod]
        public void Throw_WhenWishlistBeerIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenWishlistBeerIdIsInvalid));
            var user = TestsModelsSeeder.SeedUser();
            var beer = TestsModelsSeeder.SeedBeer();

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